namespace Keepr.Services;

  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault createVault(Vault vaultData)
    {
      Vault vault = _repo.createVault(vaultData);
      return vault;
    }

    internal Vault getVaultById(int vaultId, string userId)
    {
        Vault vault = _repo.getVaultById(vaultId);
        if (vault == null) throw new Exception("No Vault Here!");
        if (vault.IsPrivate == true && userId != vault.CreatorId) throw new Exception("Go AWAY!");
        return vault;
    }

     internal string deleteVault(int vaultId, string userId)
  {
    Vault vault = getVaultById(vaultId, userId);
    if (vault.CreatorId != userId) throw new Exception("Something went wrong");
    _repo.deleteVault(vaultId);
    return "Vault was deleted successfully.";
  }

   internal Vault updateVault(Vault updateData, string userId)
  {
    Vault original = getVaultById(updateData.Id, userId);
    if (original.CreatorId != userId) throw new Exception("Not your vault");
    original.Name = updateData.Name != null ? updateData.Name : original.Name;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;
    original.IsPrivate = updateData != null ? updateData.IsPrivate : original.IsPrivate;

    _repo.updateVault(original);
    return original;
  }

  internal List<Vault> getVaultByCreatorId(string id)
  {
    return _repo.getVaultByCreatorId(id);
  }

  internal List<Vault> getVaultsByProfileId(string profileId, string userId)
  {
    List<Vault> vaults = _repo.getVaultsByProfileId(profileId);
    return vaults;
  }
}
