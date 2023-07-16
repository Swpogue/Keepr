import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{
  async getKeeps(){
    const res = await api.get(`api/keeps`)
    AppState.keeps = res.data.map(k=> new Keep(k))
    logger.log("KEEPS!", res.data)
  }
  async createKeep(formData){
    const res = await api.post(`api/keeps`, formData)
    AppState.keeps.unshift(new Keep(res.data))
  }


}

export const keepsService = new KeepsService()