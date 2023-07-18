<template>
  <section class="container-fluid">
    <div class="masonry-with-flex col-2" v-for="v in vault" :key="v.id">
      <VaultCard :vault="v" />
    </div>
  </section>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
export default {
  setup() {


    return {
      vault: computed(() => AppState.vaults),
    }
  }
}
</script>