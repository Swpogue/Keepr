<template>
  <keep-modal></keep-modal>
  <img @click="getActiveKeep(keep.id)" class="rounded-top keepImg" title="Keep Details" :src="keep?.img" :alt="keep.name">
  <div class="text-center p-2 rounded-bottom text-black fw-bold cardGuts">
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
import KeepModal from "./KeepModal.vue";
export default {
  props: {
    keep: { type: Keep, required: true },

  },
  setup(props) {

    return {
      components: { KeepModal },
      async deleteKeep() {
        try {
          if (await Pop.confirm("You sure?")) {
            const keepId = props.keep.id;
            await keepsService.deleteKeep(keepId);
            // logger.log(keepId)
          }
        } catch (error) {
          Pop.error(error)
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
.icon {
  cursor: pointer;
}
</style>