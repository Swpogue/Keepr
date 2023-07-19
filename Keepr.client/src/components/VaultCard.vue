<template>
    <section class="rounded elevation-5">
      <router-link :to="{name: 'Vault', params: {id: vault.id }}">
    <div class="text-center p-2 rounded-bottom text-black fw-bold">
      <img class="rounded-top" :src="vault?.img" :alt="vault?.name">
      <p class="">{{ vault?.name }}</p>
    </div>
  </router-link>
    <div>

      <button @click="deleteVault()">delete</button>
    </div>
  </section>
</template>


<script>
import { Vault } from "../models/Vault.js"
export default {
  props: {
    vault: { type: Vault, required: true}
  },

  setup(){
    return {}
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