<template>
  <vault-keep-modal></vault-keep-modal>
  <div class="">
    <img @click="getActiveVaultKeep(keep.id)" class="rounded-top keepImg" :src="keep?.img" :alt="keep.name">
    <div class="text-center  p-2 rounded-bottom text-black fw-bold cardGuts">
      <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
        <h3 class="m-0">{{ keep.name }}</h3>
      </router-link>
    </div>
  </div>
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
      async deleteKeep() {
        try {
          if (await Pop.confirm("You sure?")) {
            const keepId = props.keep.id;
            await keepsService.deleteKeep(keepId);
            // logger.log(recipeId)
          }
        } catch (error) {
          Pop.error(error)
        }
      },


      async getActiveVaultKeep(keepId) {
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
.keepImg {
  // height: 350px;
  width: 100%;
  // aspect-ratio: 1/1;
  // object-fit: fit;
  cursor: pointer;
}

.creatorImg {
  height: 30px;
  // aspect-ratio: 1/1;
  object-fit: cover;
  cursor: pointer;
}
.cardGuts {
    position: absolute;
    // justify-content: space-between;
    // display: flex;
    align-items: center;
    bottom: 70px;
    // top: 50px;
    left: 0px;
    right: 1550px;
  }

.icon {
  cursor: pointer;
}
</style>