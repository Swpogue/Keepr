namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth;

  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Vault>> createVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.createVaultKeep(vaultKeepData, userInfo.Id);
      return Ok(vaultKeep);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpDelete("{vaultKeepId}")]
  [Authorize]

  public async Task<ActionResult<string>> deleteVaultKeep(int vaultKeepId)
  {
    try
    {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        _vaultKeepsService.deleteVaultKeep(vaultKeepId, userInfo.Id);
        return Ok("Keep Deleted from Vault");
    }
     catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
