<template>
  <form class="card elevation-1 col-6" @submit.prevent="submitEdit">

<div class="card-body">
  <div class="form-floating mb-3">
    <input name="name" class="form-control" placeholder="Name" type="text" required v-model="editable.name">
    <label for="name">Name:</label>
  </div>
  <div class="form-floating mb-3">
    <input name="picture" class="form-control" placeholder="Profile Picture" type="url" required
      v-model="editable.picture">
    <label for="picture">Picture:</label>
  </div>
  <div class="form-floating mb-3">
    <input name="cover-img" class="form-control" placeholder="cover Image" type="url" 
      v-model="editable.coverImg">
    <label for="cover-img">Cover Image:</label>
  </div>
  <div class="form-floating mb-3">
    <input name="email" class="form-control" placeholder="email" type="text" v-model="editable.email">
    <label for="email">Email:</label>
  </div>

  <!-- <div class="input-text">
    <input v-model="editable.graduated" type="checkbox">
      <label class="px-3" for="graduated">Graduated?</label>
  </div> -->
</div>
<div class="card-footer text-end">
  <button class="btn btn-outline-primary text-dark" type="submit">Save Profile</button>
</div>


</form>
</template>


<script>
import { ref, watchEffect } from "vue"
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js"
import { accountService } from "../services/AccountService.js"


export default {
  setup(){
    const editable = ref({})
    
    watchEffect(()=> {
      editable.value = { ...AppState.account}
    })

    return {
     editable,
     async submitEdit(){
      try {
        await accountService.submitEdit(editable.value)
      } catch (error) {
        Pop.error(error, 'Editing Profile')
      }
     }

    }
  }
}
</script>


<style lang="scss" scoped>
.card{
  width: 30em;
}
</style>