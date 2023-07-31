import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService{


  async saveKeepToVault(formData, keepId)
  {
    logger.log(formData, keepId)
    const vaultKeepData = { 'vaultId': formData, 'keepId': keepId}
    // logger.log("VAULT KEEP DATA",vaultKeepData)
    const res = await api.post(`api/vaultKeeps`, vaultKeepData)
    AppState.vaultKeeps.unshift(new VaultKeep(res.data))
    logger.log('VAULT KEEP SAVED!!!!', res.data)
  }

  async deleteVaultKeep(vaultKeepId)
  {
    const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    const vIndex = AppState.vaultKeeps.findIndex(v=> v.vaultKeepId == vaultKeepId)
    AppState.vaultKeeps.splice(vIndex, 1)
    logger.log('[DELETED VAULT KEEP]', res.data)
  }

}

export const vaultKeepsService = new VaultKeepsService()