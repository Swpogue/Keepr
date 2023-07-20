<template>
  <img class="rounded-top keepImg" :src="profileKeep?.img" :alt="profileKeep.name">
  
  <div class="text-center p-2 rounded-bottom text-black fw-bold cardGuts">
    <router-link :to="{name: 'Profile', params: {id: profileKeep?.creatorId}}">
      <h5 class="m-0 text-white">{{ profileKeep.name }}</h5>
      <!-- <img :src="profileKeep.creator.picture" alt="" class="creatorImg rounded"> -->
    </router-link>
    </div>
    
</template>


<script>
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {
    profileKeep: { type: Keep, required: true },
    
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

.keepImg {
    // height: 350px;
    width: 100%;
    object-fit: cover;
    // aspect-ratio: 1/1;
    cursor: pointer;
  }
  .creatorImg {
    height: 30px;
    // aspect-ratio: 1/1;
    object-fit: cover;
    cursor: pointer;
    // position: relative;
  }

  .cardGuts {
    position: absolute;
    justify-content: space-between;
    // display: flex;
    align-items: center;
    bottom: 0px;
    // top: 50px;
    left: 0px;
    right: 0px;
  }

.icon {
  cursor: pointer;
}
</style>