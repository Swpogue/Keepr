import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)

    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyVaults(){
    const res = await api.get(`api/account/vaults`)
    AppState.myVaults = res.data.map(v => new Vault(v))
    logger.log("MY VAULTS GOT!")
  }

}

export const accountService = new AccountService()
