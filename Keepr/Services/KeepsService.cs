namespace Keepr.Services;

public class KeepsService
    {
        private readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository repo)
  {
    _repo = repo;
  }

  internal Keep createKeep(Keep keepData)
  {
    Keep keep = _repo.createKeep(keepData);
    return keep;
  }

  internal List<Keep> getAllKeeps()
  {
    List<Keep> keeps = _repo.getAllKeeps();
    return keeps;
  }

  internal Keep getKeepById(int keepId)
  {
  Keep keep = _repo.getKeepById(keepId);
  if (keep == null) throw new Exception("No Keep Here");
  return keep;
  }

  internal void deleteKeep(int keepId, string userId)
  {
    Keep keep = getKeepById(keepId);
    if (keep.CreatorId != userId) throw new Exception("Not your Keep");
    int rows = _repo.deleteKeep(keepId);
    if (rows > 1) new Exception("You deleted TOO hard!");
  }

  internal Keep updateKeep(Keep updateData, string userId)
  {
    Keep original = getKeepById(updateData.Id);
    if (original.CreatorId != userId) throw new Exception("Not your Keep");
    original.Name = updateData.Name != null ? updateData.Name : original.Name;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;
    
    _repo.updateKeep(original);
    return original;
  }

  internal List<Keep> getMyKeeps(string id)
  {
    return _repo.getMyKeeps(id);
  }
}
