namespace Keepr.Services;

  public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly VaultsService _vaultsService;
        private readonly KeepsRepository _kRepo;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService, KeepsRepository kRepo)
  {
    _repo = repo;
    _vaultsService = vaultsService;
    _kRepo = kRepo;
  }

  internal VaultKeep createVaultKeep(VaultKeep vaultKeepData, string userId)
    {
      Vault vault = _vaultsService.getVaultById(vaultKeepData.VaultId, userId);
      if (vault.CreatorId != userId) throw new Exception("Something Went Wrong");
      VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
      Keep keep = _kRepo.getKeepById(vaultKeep.KeepId);
      keep.Kept++; _kRepo.updateKeep(keep);
      return vaultKeep;
    }

    internal void deleteVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = _repo.getVaultKeepById(vaultKeepId);
    if (vaultKeep.CreatorId != userId) throw new Exception("Not your Keep");
    int rows = _repo.deleteVaultKeep(vaultKeepId);
    if (rows > 1) new Exception("You deleted TOO hard!");
  }

  internal VaultKeep getVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _repo.getVaultKeepById(vaultKeepId);
    return vaultKeep;
  }

  internal List<VaultKeepKeep> getVaultKeepsByVaultId(int vaultId)
  {
    List<VaultKeepKeep> vaultKeeps = _repo.getVaultKeepsByVaultId(vaultId);
    if (vaultKeeps == null) throw new Exception("No keeps here");
    return vaultKeeps;
  }
}


