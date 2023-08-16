<template>
   <keep-modal></keep-modal>
  <img @click="getActiveKeep(profileKeep.id)" title="Keep Details" class="rounded-top keepImg" :src="profileKeep?.img" :alt="profileKeep.name">
  
  <div class="text-center p-2 rounded-bottom text-black fw-bold cardGuts">
    <router-link :to="{name: 'Profile', params: {id: profileKeep?.creatorId}}">
      <h5 class="m-0 text-white" title="Profile Details">{{ profileKeep.name }}</h5>
      <!-- <img :src="profileKeep.creator.picture" alt="" class="creatorImg rounded"> -->
    </router-link>
    <div class="col-1">
      <button @click="deleteKeep(profileKeep.id)" aria-label="Delete Keep" title="Delete Keep">Delete</button>
    </div>
  </div>
    
</template>


<script>
import { Modal } from "bootstrap";
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
export default {
  props: {
    profileKeep: { type: Keep, required: true },
    
  },
  setup(props) {

    return {
      async deleteKeep(){
        try {
          if (await Pop.confirm("You sure?")){
            const keepId = props.profileKeep.id;
            logger.log(keepId)
            await keepsService.deleteKeep(keepId);
          }
        } catch (error) {
          Pop.error(error.message)
        }
      },

       async getActiveKeep(keepId) {
        try {
          await keepsService.getKeepById(keepId)
          Modal.getOrCreateInstance('#activeKeepModal').show()
        } catch (error) {
          Pop.error(error)
        }
      }

    }
  }
}
</script>


<style lang="scss" scoped>

.keepImg {
    width: 100%;
    object-fit: cover;
    cursor: pointer;
  }
  .creatorImg {
    height: 30px;
    aspect-ratio: 1/1;
    object-fit: cover;
    cursor: pointer;
    position: relative;
  }

  .cardGuts {
    position: absolute;
    align-items: center;
    bottom: 0px;
    left: 0px;
    right: 0px;
  }

  button{
    height: 25px;
  }

.icon {
  cursor: pointer;
}
</style>