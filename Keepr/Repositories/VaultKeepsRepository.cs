namespace Keepr.Repositories;

  public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

  internal VaultKeep createVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO vaultKeeps
    (creatorId, vaultId, keepId)
    VALUES
    (@CreatorId, @VaultId, @KeepId);
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
    vaultKeepData.Id = id;
    return vaultKeepData; 
  }

  internal int deleteVaultKeep(int vaultKeepId)
  {
    string sql = @"
    DELETE FROM vaultKeeps
    WHERE id = @vaultKeepId
    LIMIT 1
    ;";
    
    int rows = _db.Execute(sql, new { vaultKeepId });
    return rows;
  }

  internal VaultKeep getVaultKeepById(int vaultKeepId)
  {
    string sql = @"
    SELECT *
    FROM vaultKeeps
    WHERE vaultKeeps.id = @vaultKeepId
    ;";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new {vaultKeepId}).FirstOrDefault();
    return vaultKeep;
  }

  internal List<VaultKeepKeep> getVaultKeepsByVaultId(int vaultId)
  {
    string sql = @"
    SELECT
    keeps.*,
    creator.*,
    vaultKeeps.id
    FROM vaultKeeps
    JOIN keeps ON vaultKeeps.keepId = keeps.id
    JOIN accounts creator ON keeps.creatorId = creator.id
    WHERE vaultId = @vaultId
    ;";

    List<VaultKeepKeep> vaultKeeps = _db.Query<VaultKeepKeep, Profile, VaultKeep, VaultKeepKeep>(sql, (keeper, creator, vaultKeep)=>
    {
      keeper.Creator = creator;
      keeper.vaultKeepId = vaultKeep.Id;
      return keeper;

    },new {vaultId}).ToList();
    return vaultKeeps;
  }
}
