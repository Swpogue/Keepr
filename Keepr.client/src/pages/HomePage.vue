<template>
  <section class="container-fluid body">
    <div class="overflow-hidden mt-2">
      <div class="masonry-with-flex">
        <div class="keepCards elevation-5" v-for="k in keep" :key="k.id">
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
.body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-flex {
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
