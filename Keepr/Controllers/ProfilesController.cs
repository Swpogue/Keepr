namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;
  private readonly VaultsService _vaultsService;

  public ProfilesController(ProfilesService profilesService, KeepsService keepsService, Auth0Provider auth, VaultsService vaultsService)
  {
    _profilesService = profilesService;
    _keepsService = keepsService;
    _auth = auth;
    _vaultsService = vaultsService;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> getProfileById(string profileId)
  {
    try
    {
      Profile profile = _profilesService.getProfileById(profileId);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public ActionResult<Profile> getKeepsByProfileId(string profileId)
  {
    try
    {
      List<Keep> keeps = _keepsService.getKeepsByProfileId(profileId);
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Profile>>> getVaultsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.getVaultsByProfileId(profileId, userInfo?.Id);
      return Ok(vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}




