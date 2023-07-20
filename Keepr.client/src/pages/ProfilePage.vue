<template>
    <section class="container-fluid ">
        <div class="row profileName">
            <div class="col-4 p-3 text-center">
                <img class="rounded profileImg" :src="profile?.coverImg" alt="">
                <h3>{{ profile?.name }}</h3>
            </div>
            <div class="col-5 p-3 text-center">
                <img class="img-fluid rounded" :src="profile?.picture" alt="">
            </div>
        </div>
    </section>

    <section class="container-fluid profile-page mt-2">
        <div class="row vaultRow">
            <div class=" col-2" v-for="v in vault" :key="v.id">
                <VaultCard :vault="v" />
            </div>
        </div>
    </section>

    <section class="container-fluid mt-5">
        <div class="row  mt-2">
            <div class="masonry-with-flex col-12">
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
            // vault: computed(() => AppState.vaults),
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

.profileImg{
    width: 100%;
}
.profileName {
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