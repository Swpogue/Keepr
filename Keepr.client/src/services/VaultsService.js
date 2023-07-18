import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService{
  async createVault(formData){
    const res = await api.post(`api/vaults`, formData)
    AppState.vaults.unshift(new Vault(res.data))
    logger.log("Vault created!", res.data)
  }


}

export const vaultsService = new VaultsService()