<template>
  <vault-keep-modal></vault-keep-modal>
  <section class="rounded elevation-5 col-2">
    <div class="text-center  p-2 rounded-bottom text-black fw-bold">
      <img @click="getActiveVaultKeep(keep.id)" class="rounded-top" :src="keep?.img" :alt="keep.name">
      
      <p class="m-0">Keep: {{ keep.name }}</p>
      <router-link :to="{name: 'Profile', params: {id: keep?.creatorId}}">
      <p>Created: {{ keep.creator.name }}</p>
      <!-- TODO put Creator img here  -->
      <p><img :src="keep.creator.picture" alt="" class="creatorImg rounded-pill"></p>
    </router-link>
    </div>
    <div> 

      <button @click="deleteKeep()">delete</button>
    </div>
  </section>
</template>


<script>
import { Modal } from "bootstrap";
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import VaultKeepModal from "./VaultKeepModal.vue";
export default {
  components: { VaultKeepModal },
  props: {
    keep: { type: Keep, required: true },
    
  },
  setup(props) {

    return {
      async deleteKeep(){
        try {
          if (await Pop.confirm("You sure?")){
            const keepId = props.keep.id;
            await keepsService.deleteKeep(keepId);
            // logger.log(recipeId)
          }
        } catch (error) {
          Pop.error(error)
        }
      },
 
        
      async getActiveVaultKeep(keepId){
        try {
          await keepsService.getKeepById(keepId)
          Modal.getOrCreateInstance('#activeVaultKeepModal').show()
        } catch (error) {
          Pop.error(error)
        }
      }
 
 
    }
  }
}
</script>


<style lang="scss" scoped>

img {
  height: 350px;
  width: 100%;
  // aspect-ratio: 1/1;
  object-fit: fit;
  cursor: pointer;
}
.creatorImg {
  height: 60px;
  aspect-ratio: 1/1;
  // object-fit: fit;
  cursor: pointer;
}

.icon {
  cursor: pointer;
}
</style>