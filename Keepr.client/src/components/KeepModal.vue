<template>
  <section class="container-fluid card">
    <div class="row">
      <div class="col-12">
        
      </div>
    </div>

  </section>
</template>


<script>
import { Keep } from "../models/Keep.js"
export default {
  props:{
    keep: {type: Keep, required: true}
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>