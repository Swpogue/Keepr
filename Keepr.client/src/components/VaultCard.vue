<template>
    <section class="rounded elevation-5">
      <router-link :to="{name: 'Vault', params: {id: vault.id }}">
    <div class="text-center p-2 rounded-bottom text-black fw-bold">
      <img class="rounded-top" :src="vault?.img" :alt="vault?.name">
      <p class="">{{ vault?.name }}</p>
    </div>
  </router-link>
    <div v-if="account?.id == vault.creatorId">
      <button @click="deleteVault()">delete</button>
    </div>
    <div v-if="vault.isPrivate == true">
      <i class="mdi mdi-lock ps-2" aria-label="Private"></i>
    </div>


  </section>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js"
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {
    vault: { type: Vault, required: true}
  },

  setup(props){
    return {
      account: computed(() => AppState.account),
      async deleteVault(){
        try {
          if (await Pop.confirm("You sure?")){
            const vaultId = props.vault.id;
            await vaultsService.deleteVault(vaultId);
            // logger.log(recipeId)
          }
        } catch (error) {
          Pop.error(error)
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 350px;
  width: 100%;
  // aspect-ratio: 1/1;
  object-fit: fit;
}
</style>