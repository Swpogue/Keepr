<template>
  <form @submit.prevent="handleSubmit">
  <div class="modal" id="activeKeepModal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="btn-close col-1" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()"></button>
        </div>
        <section class="container-fluid">
          <div class=" p-1 row">
            <div class="col-6">
              <img class="rounded-top" :src="keep?.img" alt="">
              <p>VIEWED: {{ keep?.views }}</p>
            </div>
            <div class="text-center col-6">
              <h4 class="modal-title col-10"> {{ keep?.name }}</h4>
              <h5> {{ keep?.description }}</h5>
            </div>
          </div>
        </section>
        <div class="form-group">
          <select name="keep" class="form-control" v-model="editable.keepId">
            <option disabled selected value="">Select Keep</option>
            <option v-for="k in keep" :key="k.id" :value="k.id">{{ k.name}}</option>
          </select>
          <select name="vault" class="form-control" v-model="editable.vaultId">
            <option disabled selected value="">Please Select a Vault</option>
            <option v-for="v in vaults" :key="v.id" :value="v.id">{{ v.name }}</option>
          </select>
        </div>
      <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Close</button>
      <button  class="btn btn-primary" type="submit">Save Keep!</button>
    </div>
  </div>
</div>
</form>
</template>


<script>
import { computed, ref } from "vue"
import { AppState } from "../AppState.js"
import { vaultKeepsService } from "../services/VaultKeepsService.js"
import Pop from "../utils/Pop.js"
import { logger } from "../utils/Logger.js"
export default {
  setup() {

    const editable = ref({ vaultId: '', keepId: '' })
    return {
    editable,

    async handleSubmit() {
      try {
        logger.log("[DID YOU SAVE VAULT KEEP?]", editable.value )
        await vaultKeepsService.saveKeepToVault(editable.value)
        editable.value = { vaultId: '', keepId: '' }
      } catch (error) {
        Pop.error(error, '[DID NOT SAVE KEEP]')
      }
    },
    
      keep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.myVaults),

      clearActive() {
        AppState.activeKeep = {}
      }
  }
}
}

</script>

<style lang="scss" scoped>
img{
  width: 100%;
  object-fit: cover;
}
// .modal-content{
// display: flex;
// flex-direction: row;

// }

</style>