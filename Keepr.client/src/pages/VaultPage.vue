<template>
  <section class="container-fluid">
    <div class="row vaultImg">
      <div class="col-12 p-3 text-center">
        <img class="rounded boxShadow" :src="vault?.img" alt="">
        <h4 class="pt-2">Keeps: {{ keep.length }}</h4>
      </div>
    </div>
 
    <div class=" mt-2">
      <div class="masonry-with-flex ">
        <div class="keepCards elevation-5" v-for="k in keep" :key="k.id">
          <VaultKeepCard :keep="k" />
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { useRoute, useRouter } from "vue-router";
import { computed, onMounted } from "vue";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { AppState } from "../AppState.js";
export default {
  setup() {
    const router = useRouter()
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
        router.push({name: 'Home'})
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
      vault: computed(() => AppState.activeVault),
    }
  }
}
</script>

<style scoped lang="scss">
.vaultImg {
  align-items: center;
  
}
.boxShadow {
  box-shadow: 10px 5px 5px rgb(97, 96, 96);
}

.masonry-with-flex {
  columns: 6 200px;
  column-gap: 1rem;

  .keepCards {
    width: 200px;
    background: #EC985A;
    color: white;
    margin: 0 1rem 1rem 0;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 1rem;
    position: relative;
    overflow: hidden;
  }

}
</style>
