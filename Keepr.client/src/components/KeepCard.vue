<template>
  <div class="rounded elevation-5">
    <div class="text-center p-2 rounded-bottom text-black fw-bold">
      <img class="rounded-top" :src="keep.img" :alt="keep.name">
      <p class="m-0">Keep: {{ keep.name }}</p>
      <p>Created by: {{ keep.creator.name }}</p>
      <!-- TODO put Creator img here  -->
      <p><img :src="keep.creator.picture" alt="" class="creatorImg rounded"></p>
    </div>
  </div>
</template>


<script>
import { Keep } from "../models/Keep.js"
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 350px;
  width: 100%;
  aspect-ratio: 1/1;
  // object-fit: fit;
  cursor: pointer;
}
.creatorImg {
  height: 50px;
  aspect-ratio: 1/1;
  // object-fit: fit;
  cursor: pointer;
}

.icon {
  cursor: pointer;
}
</style>