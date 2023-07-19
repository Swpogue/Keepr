<template>
   <div class="row d-flex justify-content-center m-5">
    <ProfileForm />
  </div>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <img class="rounded" :src="account.coverImg" alt="" />
  </div>
  <section class="container-fluid">
    <div class="masonry-with-flex col-2" v-for="v in vault" :key="v.id">
      <VaultCard :vault="v" />
    </div>
    <section class="container-fluid">
        <div class="masonry-with-flex col-2" v-for="k in keep" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </section>
  </section>
  <!-- <div class="my-keeps">
    <MyKeepsCard v-for="k in keeps" :key="k=id" :keep="k" />
  </div> -->
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from "../utils/Pop.js";
import { accountService } from "../services/AccountService.js";
import { logger } from "../utils/Logger.js";
export default {


  
  setup() {
    onMounted(()=> {getMyVaults(); })

    async function getMyVaults(){
      try {
        logger.log("ACCOUNT PAGE VAULTS?")
        await accountService.getMyVaults();
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      account: computed(() => AppState.account),
      // keeps: computed(()=> AppState.myKeeps),
      vault: computed(() => AppState.myVaults),
      keep: computed(() => AppState.keeps),
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
