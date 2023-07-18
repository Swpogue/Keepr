<template>
  <section class="rounded elevation-5">
    <div class="text-center p-2 rounded-bottom text-black fw-bold">
      <img class="rounded-top" :src="keep.img" :alt="keep.name">
      
      <p class="m-0">Keep: {{ keep.name }}</p>
      <router-link :to="{name: 'Profile'}">
      <p>Created by: {{ keep.creator.name }}</p>
      <!-- TODO put Creator img here  -->
      <p><img :src="keep.creator.picture" alt="" class="creatorImg rounded"></p>
    </router-link>
    </div>
    <div>

      <button @click="deleteKeep()">delete</button>
    </div>
  </section>
</template>


<script>
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {

    return {
      async deleteKeep(){
        try {
          if (await Pop.confirm("You sure?")){
            const keepId = props.keep.id;
            await keepsService.deleteKeep(keepId);
            // logger.log(recipeId)
          }
        } catch (error) {
          Pop.error(error.message)
        }
      },
    }
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