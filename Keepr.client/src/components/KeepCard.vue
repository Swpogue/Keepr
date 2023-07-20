<template>
  <keep-modal></keep-modal>
  <img @click="getActiveKeep(keep.id)" class="rounded-top keepImg" :src="keep?.img" :alt="keep.name">
  <div class="text-center p-2 rounded-bottom text-black fw-bold cardGuts">
    <router-link :to="{name: 'Profile', params: {id: keep?.creatorId}}">
      <h5 class="m-0 text-white"> {{ keep.name }}</h5>
          <img :src="keep.creator.picture" alt="" class="creatorImg rounded-pill">
      </router-link>
      </div>
      <!-- <div>  -->
  
        <!-- <button @click="deleteKeep()">delete</button> -->
      <!-- </div> -->
  </template>
  
  
  <script>
  import { Modal } from "bootstrap";
  import { Keep } from "../models/Keep.js"
  import { keepsService } from "../services/KeepsService.js";
  import Pop from "../utils/Pop.js";
  import KeepModal from "./KeepModal.vue";
  export default {
    props: {
      keep: { type: Keep, required: true },
      
    },
    setup(props) {
      
      return {
        components: { KeepModal },
        async deleteKeep(){
          try {
            if (await Pop.confirm("You sure?")){
              const keepId = props.keep.id;
              await keepsService.deleteKeep(keepId);
              // logger.log(recipeId)
            }
          } catch (error) {
            Pop.error(error)
          }
        },
        
        
        async getActiveKeep(keepId){
          try {
            await keepsService.getKeepById(keepId)
            Modal.getOrCreateInstance('#activeKeepModal').show()
          } catch (error) {
            Pop.error(error)
          }
        }
        
        
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