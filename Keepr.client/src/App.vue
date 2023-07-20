<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
 
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import { keepsService } from "./services/KeepsService.js"
import Pop from "./utils/Pop.js"
import { accountService } from "./services/AccountService.js"
import { logger } from "./utils/Logger.js"

export default {
  setup() {

 onMounted(() => { 
  // getMyVaults();
  getKeeps(); });


    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      } catch (error) {
        Pop.error(error);
      }
    }

    async function getMyVaults() {
      try {
        logger.log("ACCOUNT PAGE VAULTS?")
        await accountService.getMyVaults();
      } catch (error) {
        Pop.error(error)
      }
    }


    return {
      appState: computed(() => AppState),
      profile: computed(()=> AppState.profile)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>