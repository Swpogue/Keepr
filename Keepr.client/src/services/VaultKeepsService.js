import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService{


  async saveKeepToVault(formData){
    const res = await api.post(`api/vaultKeeps`, formData)
    AppState.vaultKeeps(new Vault(res.data))
    logger.log('VAULT KEEP SAVED!!!!')
  }

}

export const vaultKeepsService = new VaultKeepsService()