<template>
       <section class="container-fluid">
        <div class="masonry-with-flex col-2" v-for="k in keep" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </section>
</template>

<script>
import { useRoute } from "vue-router";
import { computed, onMounted } from "vue";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { AppState } from "../AppState.js";
export default {
  setup() {
    const route = useRoute();
    onMounted(() => {
      getVaultById();
      getVaultKeepsById();
      
    });
    async function getVaultById() {
      try {
        await vaultsService.getVaultById(route.params.id);
        logger.log("GETTING PROFILE")
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getVaultKeepsById() {
      try {
        await vaultsService.getVaultKeepsById(route.params.id);
        logger.log("GETTING PROFILE")
      }
      catch (error) {
        Pop.error(error);
      }
    }


    return {
      keep: computed(() => AppState.vaultKeeps),
    }
  }
}
</script>
