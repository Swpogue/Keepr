<template>
  <!-- <keep-form></keep-form> -->
  
    
      <section class="container-fluid">
        <div class="masonry-with-flex col-2" v-for="k in keep" :key="k.id">
          <KeepCard :keep="k" />
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
section {
  margin: 0;
  padding: 1rem;
}
.masonry-with-flex {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  max-height: 1000px;
  div {
    width: 150px;
    background: #EC985A;
    color: white;
    margin: 0 1rem 1rem 0;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  } 
  @for $i from 1 through 36 { 
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}


.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}</style>
