<template>
  <keep-form></keep-form>
  <section class="container-fluid">
    <button class="btn btn-outline-dark w-15" @click="openKeepFormModal()">Create</button>

    <div class="align-items-center justify-content-center col-md-3">
      <div v-for="k in keep" :key="k.id">
        <KeepCard :keep="k" />

      </div>
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from "vue";
// import { keepsService } from "../services/KeepsService.js"
// import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { Modal } from "bootstrap";
import KeepForm from "../components/KeepForm.vue";

export default {
  components: { KeepForm },
  setup() {
   


    return {
      keep: computed(() => AppState.keeps),

      openKeepFormModal(){
        Modal.getOrCreateInstance('#createKeepModal').show()
      }


    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
