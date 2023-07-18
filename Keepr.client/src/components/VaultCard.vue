<template>
    <section class="rounded elevation-5">
    <div class="text-center p-2 rounded-bottom text-black fw-bold">
      <img class="rounded-top" :src="vault.img" :alt="vault.name">
      <p class="m-0">Vault: {{ vault.name }}</p>
      <p>Created by: {{ vault.creator.name }}</p>
      <!-- TODO put Creator img here  -->
      <p><img :src="vault.creator.picture" alt="" class="creatorImg rounded"></p>
    </div>
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

</style>