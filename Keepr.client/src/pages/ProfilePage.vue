<template>
  <section class="container-fluid profile-page">
    <div class="masonry-with-flex col-2" v-for="v in vault" :key="v.id">
      <VaultCard :vault="v" />
    </div>
    {{ profile?.name }}
    <img :src="profile?.coverImg" alt="">
    <img :src="profile?.picture" alt="">
  </section>
  <section class="container-fluid">
        <div class="masonry-with-flex col-2" v-for="k in keep" :key="k.id">
          <MyKeepsCard :profileKeep="k" /> 
        </div>
      </section>
</template>

<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { profilesService } from "../services/ProfilesService.js";
import Pop from "../utils/Pop.js";
import { useRoute } from "vue-router";
export default {
    setup() {
        onMounted(() => {
            getProfileVaults();
            getProfile();
            getKeepsByProfileId();
        });
        const route = useRoute();
        async function getProfile() {
            try {
                await profilesService.getProfileById(route.params.id);
                logger.log("GETTING PROFILE");
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getProfileVaults() {
            try {
                await profilesService.getProfileVaults(route.params.id);
                logger.log("PROFILE PAGE VAULTS?");
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getKeepsByProfileId() {
            try {
                await profilesService.getKeepsByProfileId(route.params.id);
                logger.log("PROFILE PAGE VAULTS?");
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            // vault: computed(() => AppState.vaults),
            profile: computed(() => AppState.activeProfile),
            vault: computed(() => AppState.profileVaults),
            keep: computed(() => AppState.profileKeeps),
        };
    },
    
}
</script>