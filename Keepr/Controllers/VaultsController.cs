namespace Keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth;

  public VaultsController(VaultsService vaultsService, Auth0Provider auth, VaultKeepsService vaultKeepsService)
  {
    _vaultsService = vaultsService;
    _auth = auth;
    _vaultKeepsService = vaultKeepsService;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Vault>> createVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.createVault(vaultData);
      vault.Creator = userInfo;
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}")]

  public async Task<ActionResult<Keep>> getVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.getVaultById(vaultId, userInfo?.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<string>> deleteVault(int vaultId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      _vaultsService.deleteVault(vaultId, userInfo?.Id);
      return Ok("Vault Deleted!");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{vaultId}")]
  [Authorize]
  
  public async Task<ActionResult<Vault>> updateVault(int vaultId, [FromBody] Vault updateData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      updateData.Id = vaultId;
      Vault vault = _vaultsService.updateVault(updateData, userInfo.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

[HttpGet("{vaultId}/keeps")]
public async Task<ActionResult<List<VaultKeepKeep>>> getVaultKeepsByVaultId(int vaultId)
{
  try
  {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    Vault vault = _vaultsService.getVaultById(vaultId, userInfo?.Id);
    List<VaultKeepKeep> vaultKeeps = _vaultKeepsService.getVaultKeepsByVaultId(vaultId);
    return Ok(vaultKeeps);
  }
   catch (Exception e)
    {
      return BadRequest(e.Message);
    }
}
}
