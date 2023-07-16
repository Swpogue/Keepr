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
}
