namespace Keepr.Models;

public class VaultKeep
{
  public int Id { get; set;}
  public string CreatorId { get; set; }
  public int VaultId { get; set; }
  public int KeepId { get; set; }

  public Profile Creator { get; set;}
  public Keep Keep { get; set;}
}

// public class VaultKeepKeep : Keep
// {
//   public int vaultKeepId { get; set; }
// }

