namespace Keepr.Services;

  public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly VaultsService _vaultsService;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
      _repo = repo;
      _vaultsService = vaultsService;
    }

    internal VaultKeep createVaultKeep(VaultKeep vaultKeepData, string userId)
    {
      Vault vault = _vaultsService.getVaultById(vaultKeepData.VaultId, userId);
      if (vault.CreatorId != userId) throw new Exception("Something Went Wrong");
      VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
      return vaultKeep;
    }

    internal void deleteVaultKeep(int vaultKeepId, string id)
    {
      throw new NotImplementedException();
    }
  }


