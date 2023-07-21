<template>
  <div class="modal" tabindex="-1" id="createKeepModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Keep</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="createKeep()">
          <div class="row modal-body">
            <div class="col-12">
              <label for="Keep Name">Keep Name</label>
              <input type="text" id="keepName" name="keepName" class="form-control" required minlength="5" maxlength="25" aria-label="Keep Name"
                v-model="editable.name">
            </div>
            <div class="col-12">
              <label for="imgUrl" class="mt-2">Image URL</label>
              <input type="url" id="KeepImgUrl" name="imgUrl" class="form-control" required minlength="5" maxlength="500" aria-label="Image U R L"
                v-model="editable.img">
            </div>
            <div class="col-12">
              <label for="description">Description</label>
              <input type="text" name="description" id="KeepDescription" class="form-control" aria-label="Description" required minlength="5" maxlength="500"
                v-model="editable.description">
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
import { keepsService } from "../services/KeepsService.js"
import Pop from "../utils/Pop.js"
import { logger } from "../utils/Logger.js"
import { Modal } from "bootstrap"
export default {
  setup() {

    const editable = ref({})
    return {
      editable,


      async createKeep() {
        try {
          const formData = editable.value
          await keepsService.createKeep(formData)
          editable.value = {}
          Modal.getOrCreateInstance('#createKeepModal').hide()
          logger.log('CREATED KEEP')
        } catch (error) {
          Pop.error(error)
        }
      },


    }
  }
}
</script>


<style lang="scss" scoped></style>