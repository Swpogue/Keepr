namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth)
  {
    _keepsService = keepsService;
    _auth = auth;
  }


  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Keep>> createKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.createKeep(keepData);
      return new ActionResult<Keep>(Ok(keep));
    }
     catch (Exception e)
        {
            return BadRequest(e.Message);
        }
  }

    [HttpGet]
    public ActionResult<List<Keep>> getAllKeeps()
    {
        try
        {
            List<Keep> keeps = _keepsService.getAllKeeps();
            return Ok(keeps);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
      [HttpGet("{keepId}")]
    public ActionResult<Keep> getKeepById(int keepId)
    {
        try
        {
            Keep keep = _keepsService.getKeepById(keepId);
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
  [HttpDelete("{keepId}")]
    [Authorize]

    public async Task<ActionResult<string>> deleteKeep(int keepId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        _keepsService.deleteKeep(keepId, userInfo.Id);
        return Ok("Keep Deleted");
      }
      catch (Exception e)
      {
        
        return BadRequest(e.Message);
      }
    }

   [HttpPut("{keepId}")]
   [Authorize]
  public async Task<ActionResult<Keep>> updateKeep(int keepId, [FromBody] Keep updateData)
  {
    try 
    {
      updateData.Id = keepId;
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.updateKeep(updateData,userInfo.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
