import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService{
  async createVault(formData){
    const res = await api.post(`api/vaults`, formData)
    AppState.vaults.unshift(new Vault(res.data))
    logger.log("Vault created!", res.data)
  }

  async getVaultById(id){
    const res = await api.get(`api/vaults/${id}`)
    AppState.activeVault = new Vault(res.data)
    logger.log("ONE VAULT!!", res.data )
  }
  
  async getVaultKeepsById(id){
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.vaultKeeps = res.data.map(v=> new Keep(v))
    logger.log("VAULT KEEPS!!", res.data )
  }


}

export const vaultsService = new VaultsService()