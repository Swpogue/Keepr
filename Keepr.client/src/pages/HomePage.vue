<template>
  <section class="container-fluid">
    <div class="row overflow-hidden mt-2">
      <div class="masonry-with-flex">
        <div class="keepCards" v-for="k in keep" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {

    return {
      keep: computed(() => AppState.keeps),

    }
  }
}
</script>

<style scoped lang="scss">
// section {
//   margin: 0;
//   padding: 1rem;
// }

.masonry-with-flex {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  // min-height: 400px;
  max-height: 1300px;

  .keepCards {
    width: 150px;
    background: #EC985A;
    color: white;
    margin: 0 1rem 1rem 0;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 1rem;
    position: relative;
  }

  // @for $i from 1 through 36 {
  //   div:nth-child(#{$i}) {
  //     $h: (random(400) + 100)+px;
  //     height: $h;
  //     line-height: $h;
  //   }
  // }
}

</style>
