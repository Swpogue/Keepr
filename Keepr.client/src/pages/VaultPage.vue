<template>
  <section class="container-fluid">
    <div class="row vaultImg">
      <div class="col-12 p-3 text-center">
        <img class="rounded" :src="vault?.img" alt="">
        <p class="pt-2">Keeps</p>
      </div>
    </div>
  </section>

  <section class="container-fluid mt-5">
    <div class="row  mt-2">
      <div class="masonry-with-flex ">
        <div class="keepsCards elevation-5 col-2" v-for="k in keep" :key="k.id">
          <VaultKeepCard :keep="k" />
        </div>
      </div>
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
      vault: computed(() => AppState.activeVault),
    }
  }
}
</script>

<style scoped lang="scss">
.vaultImg {
  justify-content: space-between;
  height: fit-content;
  align-items: center;
}

.masonry-with-flex {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  // min-height: 400px;
  max-height: 800px;

  .keepCards {
    width: 150px;
    background: #EC985A;
    color: white;
    margin: 0 1em 1em 0;
    text-align: center;
    // font-family: system-ui;
    // font-weight: 900;
    font-size: 1rem;
    position: relative;
  }

  //       @for $i from 1 through 40 {
  //     div:nth-child(#{$i}) {
  //       $h: (random(400) + 100)+px;
  //       height: $h;
  //       line-height: $h;
  //     }
  //   }
}
</style>
