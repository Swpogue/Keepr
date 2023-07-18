namespace Keepr.Repositories;

  public class KeepsRepository
    {
        private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

      internal Keep createKeep(Keep keepData)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, views, creatorId)
      VALUES
      (@name, @description, @img, @views, @creatorId);

      SELECT
      keeps.*,
      creator.*
      FROM keeps
      JOIN accounts creator ON keeps.creatorId = creator.id
      WHERE keeps.id = LAST_INSERT_ID();";

      Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator)=>{
        keep.Creator = creator;
        return keep;
      }, keepData).FirstOrDefault();
      return keep;
    }

internal List<Keep> getAllKeeps()
{
    string sql = @"
    SELECT
    keeps.*,
    creator.*
    FROM keeps
    JOIN accounts creator ON keeps.creatorId = creator.id;
    ";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }

internal Keep getKeepById(int keepId)
  {
    string sql = @"
    SELECT
    keeps.*,
    creator.*
    FROM keeps
    JOIN accounts creator ON keeps.creatorId = creator.id
    WHERE keeps.id = @keepId;
    ";
    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new { keepId }).FirstOrDefault();
    return keep;
  }
   internal int deleteKeep(int keepId)
  {
    string sql = @"
    DELETE FROM keeps
    WHERE id = @keepId
    LIMIT 1;";
    int rows = _db.Execute(sql, new { keepId });
    return rows;
  }
 internal void updateKeep(Keep updateData)
  {
    string sql = @"
    UPDATE keeps SET
    name = @name,
    description = @description,
    img = @img,
    views = @views
    WHERE id = @id;";
    _db.Execute(sql, updateData);
  }

  internal List<Keep> getMyKeeps(string id)
   {
    string sql = @"
      SELECT * FROM keeps 
      JOIN accounts act ON keeps.creatorId = act.id
      WHERE keeps.creatorId = @id
    ;";
    return _db.Query<Keep, Account, Keep>(sql, (keep, act) =>
    {
      keep.Creator = act;
      return keep;
    }, new { id }).ToList();


  }

  internal List<Keep> getKeepsByProfileId(string profileId)
  {
    string sql = @"
    SELECT
    keeps.*,
    creator.*,
    COUNT(vaultKeeps.id) AS Kept
    FROM keeps
    JOIN accounts creator ON keeps.creatorId = creator.id
    LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
    WHERE keeps.creatorId = @profileId
    GROUP BY(keeps.id);
    ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator)=>
    {
      keep.Creator = creator;
      return keep;
    }, new {profileId}).ToList();
    return keeps;
  }

}