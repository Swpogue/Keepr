<template>
    <section class="container-fluid body ">
        <div class="row profileName">
            <div class="col-4 p-3 text-center">
                <img class="rounded profileImg" :src="profile?.coverImg" alt="">
                <h3>{{ profile?.name }}</h3>
            </div>
            <div class="col-5 p-3 text-center">
                <img class="img-fluid rounded" :src="profile?.picture" alt="">
                <h4>Keeps: {{ keep.length }} Vaults: {{ vault.length }}</h4>
            </div>
        </div>

        <div class="row vaultRow">
            <div class=" col-2 mt-3" v-for="v in vault" :key="v.id">
                <VaultCard :vault="v" />
            </div>
        </div>

        <div class="mt-5">
            <div class="masonry-with-flex">
                <div class="keepCards elevation-5" v-for="k in keep" :key="k.id">
                    <MyKeepsCard :profileKeep="k" />
                </div>
            </div>
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
            profile: computed(() => AppState.activeProfile),
            vault: computed(() => AppState.profileVaults),
            keep: computed(() => AppState.profileKeeps),
        };
    },

}
</script>

<style scoped lang="scss">
.vaultRow {
    flex-direction: row;
    flex-wrap: wrap;
}

.body {
  margin: 0;
  padding: 1rem;
}
.profileImg{
    width: 100%;
}
.profileName {
    justify-content: space-between;
    height: fit-content;
    align-items: center;
}

.masonry-with-flex {
    columns: 6 200px;
  column-gap: 1rem;

    .keepCards {
        width: 200px;
        background: #EC985A;
        color: white;
        margin: 0 1em 1em 0;
        text-align: center;
        font-family: system-ui;
        font-weight: 900;
        font-size: 1rem;
        position: relative;
        overflow: hidden;
    }
}
</style>