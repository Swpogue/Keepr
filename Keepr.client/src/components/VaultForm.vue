<template>
  <div class="modal" tabindex="-1" id="createVaultModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Vault</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="createVault()">
          <div class="row modal-body">
            <section class="col-12">
              <div class="">
                <label for="Vault Name">Vault Name</label>
                <input type="text" id="VaultName" name="VaultName" class="form-control" required minlength="5" maxlength="25" aria-label="Vault Name"
                v-model="editable.name">
              </div>
              <div class="">
                <label for="imgUrl" class="mt-2">Image URL</label>
                <input type="url" id="imgUrl" name="imgUrl" class="form-control" required minlength="5" maxlength="500" aria-label="Image U R L"
                v-model="editable.img">
              </div>
              <div class="">
                <label for="description">Description</label>
                <input type="text" name="description" id="description" class="form-control" aria-label="Description" required minlength="5" maxlength="500"
                v-model="editable.description">
              </div>
            </section>
            </div>
            <div>
              <h6 class="ms-2">Only you can see private vaults</h6>
  
         <div class="form-check ms-2">
           <input class="form-check-input" type="checkbox" value="true" v-model="editable.isPrivate" id="privateCheckbox">
           <label class="form-check-label" for="IsPrivate">
             Make Vault Private
           </label>
         </div>
  
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Cancel</button>
            <button type="submit" class="btn btn-danger" aria-label="Submit">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from "vue"
import { vaultsService } from "../services/VaultsService.js"
import { logger } from "../utils/Logger.js"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop.js"
export default {
  setup() {
    
    const editable = ref({})
    return {
      editable,

      async createVault() {
        try {
          const formData = editable.value
          await vaultsService.createVault(formData)
          editable.value = {}
          Modal.getOrCreateInstance('#createVaultModal').hide()
          logger.log('CREATED Vault')
        } catch (error) {
          Pop.error(error)
        }
      },



    }
  }
}
</script>


<style lang="scss" scoped></style>