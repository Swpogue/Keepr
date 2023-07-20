<template>
  <div class="modal" id="activeVaultKeepModal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="btn-close col-1" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()"></button>
        </div>
        <div class="row p-1">
          <img class="rounded-top" :src="keep?.img" alt="">
          <h4 class="modal-title col-10"> {{ keep?.name }}</h4>
          <h5> <span>{{ keep?.description }}</span></h5>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Close</button>
          <button type="button" class="btn btn-danger" aria-label="Delete">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue"
import { AppState } from "../AppState.js"
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep),

      clearActive() {
        AppState.activeKeep = {}
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>