<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <div class="my-keeps">
    <MyKeepsCard v-for="k in keeps" :key="k=id" :keep="k" />
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {


  
  setup() {
    return {
      account: computed(() => AppState.account),
      keeps: computed(()=> AppState.myKeeps)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
