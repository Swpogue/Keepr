<template>
  <vault-keep-modal></vault-keep-modal>
  <img @click="getActiveVaultKeep(keep.id)" class="rounded-top keepImg" :src="keep?.img" :alt="keep.name" title="Keep Details">
  <div class="text-center  p-2 rounded-bottom text-black fw-bold cardGuts">
    <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
      <aside class="" title="Profile Details">
        <h5 class="m-0 text-white"> {{ keep.name }} <span class="ps-1"><img :src="keep.creator.picture" alt="" class="creatorImg rounded-pill"></span></h5>
      </aside>
    </router-link>
  </div>
</template> 


<script>
import { Modal } from "bootstrap";
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import VaultKeepModal from "./VaultKeepModal.vue";
import { AppState } from "../AppState.js";
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
          }
        } catch (error) {
          Pop.error(error)
        }
      },


      async getActiveVaultKeep(keepId) {
        try {
          AppState.activeVaultKeep.vaultKeepId = props.keep.vaultKeepId
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
  object-fit: cover;
  // aspect-ratio: 1/1;
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
  // justify-content: end;
  align-items: center;
  bottom: 0px;
  // top: 0px;
  left: 0px;
  right: 0px;
}

.icon {
  cursor: pointer;
}
</style>