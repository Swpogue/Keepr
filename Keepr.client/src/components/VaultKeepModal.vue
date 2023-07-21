<template>
  <div class="modal" id="activeVaultKeepModal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="btn-close col-1" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()"></button>
        </div>

        <section class="container-fluid">
          <div class="row p-1">
            <div class="col-6 image-fluid">
              <img class="rounded-top" :src="keep?.img" alt="">
              <p>VIEWED: {{ keep?.views }} Kept: {{ keep?.kept }}</p>
            </div>
            <div class="col-6">
              <h4 class="modal-title"> {{ keep?.name }}</h4>
              <h5> <span>{{ keep?.description }}</span></h5>
            </div>
          </div>
        </section>

        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Close</button>
          <div v-if="account?.id == vault?.creatorId">
            <button type="button" class="btn btn-danger" aria-label="Delete" @click="deleteVaultKeep()">Delete</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue"
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js"
import { vaultKeepsService } from "../services/VaultKeepsService.js"
import { logger } from "../utils/Logger.js"
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      vaultKeep: computed(() => AppState.activeVaultKeep),
      vault: computed(()=> AppState.activeVault),


      async deleteVaultKeep() {
        try {
          if (await Pop.confirm("You sure?")) {

            const vaultKeepId = AppState.activeVaultKeep.vaultKeepId;
            await vaultKeepsService.deleteVaultKeep(vaultKeepId);
            logger.log(vaultKeepId)
          }
        } catch (error) {
          Pop.error(error)
        }
      },

      clearActive() {
        AppState.activeKeep = {}
      }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  width: 100%;
  object-fit: cover;
}
</style>