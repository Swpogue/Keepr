namespace Keepr.Services;

public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal Profile getProfileById(string profileId)
    {
        Profile profile = _repo.getProfileById(profileId);
        return profile;
    }

  }
