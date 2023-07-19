import { AppState } from "../AppState.js"
import { Profile } from "../models/Profile.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {

  async getProfileById(id) {
    logger.log('[PROFILE]', id)
    const res = await api.get(`api/profiles/${id}`)
    AppState.activeProfile = new Profile(res.data)
    logger.log('[PROFILEs]', res.data)
  }
  
  async getProfileVaults(id){
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.profileVaults = res.data.map(v => new Vault(v))
    logger.log("PROFILE VAULTS GOT!", res.data)
  }


}

export const profilesService = new ProfilesService()