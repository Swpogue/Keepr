<template>
  <section class="container-fluid">
    <div class="row d-flex justify-content-center m-5">
      <ProfileForm />
    </div>
    <div class=" text-center">
      <h1>Welcome {{ account.name }}</h1>
      <img class="rounded m-2" :src="account.picture" alt="" />
      <img class="rounded m-2" :src="account.coverImg" alt="" />
    </div>
    <div class="row">
      <div class="col-2 pt-2" v-for="v in vault" :key="v.id">
        <VaultCard :vault="v" />
      </div>
    </div>
    
    <div class="body">
      <div class="masonry-with-flex">
        <div class="keepCards" v-for="k in keep" :key="k.id">
          <MyKeepsCard :profileKeep="k" />
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { logger } from "../utils/Logger.js";
export default {



  setup() {
   
    return {
      account: computed(() => AppState.account),
      vault: computed(() => AppState.myVaults),
      keep: computed(() => AppState.accountKeeps),
    }
  }
}
</script>

<style scoped lang="scss">
img {
  max-width: 100px;
}
.body {
  margin: 0;
  padding: 1rem;
  // width: 100%;
}

.masonry-with-flex {
  // display: flex;
  // flex-direction: row;
  // flex-wrap: wrap;
  // min-height: 400px;
  // max-height: 1300px;
  // width: 50vw;
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
