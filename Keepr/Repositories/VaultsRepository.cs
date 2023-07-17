namespace Keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Vault createVault(Vault vaultData)
  {
    string sql = @"
      INSERT INTO vaults
      (name, description, img, isPrivate, creatorId)
      VALUES
      (@Name, @Description, @Img, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID()
      ;";

    int id = _db.ExecuteScalar<int>(sql, vaultData);
    vaultData.Id = id;
    return vaultData;
  }

  internal Vault getVaultById(int vaultId)
  {
    string sql = @"
    SELECT
    vaults.*,
    creator.*
    From vaults
    JOIN accounts creator ON creator.id = vaults.creatorId
    WHERE vaults.id = @vaultId
    ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, new { vaultId }).FirstOrDefault();
    return vault;
  }

 internal void deleteVault(int vaultId)
  {
    string sql = @"
    DELETE FROM vaults 
    WHERE id = @vaultId 
    LIMIT 1;";
    int rows = _db.Execute(sql, new { vaultId });
  }
 internal void updateVault(Vault updateData)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";

    _db.Execute(sql, updateData);
  }

  internal List<Vault> getVaultByCreatorId(string id)
  {
    string sql = @"
    SELECT 
    vaults.*,
    creator.*
    FROM vaults
    JOIN accounts creator ON vaults.creatorId = creator.id
    WHERE vaults.creatorId = @id
    ;";

    List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, creator)=>
    {
      vault.Creator = creator;
      return vault;
    }, new {id}).ToList();
    return vaults;
  }

  internal List<Vault> getVaultsByProfileId(string profileId)
  {
    string sql = @"
    SELECT *
    FROM vaults
    WHERE vaults.creatorId = @profileId
    ;";

    List<Vault> vaults = _db.Query<Vault>(sql, new {profileId}).ToList();
    return vaults;
  }
}
