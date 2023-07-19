export class VaultKeep{
  constructor(data){
    this.id = data.id
    this.creatorId = data.creatorId
    this.vaultId = data.vaultId
    this.keepId = data.keepId
    this.creator = data.creator
  }
}






// public class VaultKeep
// {
//   public int Id { get; set;}
//   public string CreatorId { get; set; }
//   public int VaultId { get; set; }
//   public int KeepId { get; set; }

//   public Profile Creator { get; set;}
//   public Keep Keep { get; set;}
// }