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
          <MyKeepsCard :profileKeep="k" /> 
        </div>
      </section>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from "../utils/Pop.js";
import { accountService } from "../services/AccountService.js";
import { logger } from "../utils/Logger.js";
import { profilesService } from "../services/ProfilesService.js";
export default {


  
  setup() {
    onMounted(()=> {
      getMyVaults(); 
      getKeepsByAccountId();
    })
    async function getMyVaults(){
      try {
        logger.log("ACCOUNT PAGE VAULTS?")
        await accountService.getMyVaults();
      } catch (error) {
        Pop.error(error)
      }
    }
    async function getKeepsByAccountId() {
            try {
              const id = AppState.account.id
                await profilesService.getKeepsByAccountId(id);
                logger.log("ACCOUNT KEEPS BY ID?");
            }
            catch (error) {
                Pop.error(error);
            }
        }
    return {
      account: computed(() => AppState.account),
      vault: computed(() => AppState.myVaults),
      keep: computed(() => AppState.accountKeeps),
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
