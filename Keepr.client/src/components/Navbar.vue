<template>
  <keep-form></keep-form>
  <vault-form></vault-form>
  <nav class="navbar navbar-expand-lg navbar-dark bg-secondary px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <button class="btn btn-outline-light w-15 text-dark">HOME</button>
      </div>
    </router-link> 
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false"
      aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div  class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li v-if="user.isAuthenticated">
          <button class="btn btn-outline-light w-15 text-dark" @click="openKeepFormModal()" aria-label="Create Keep">Create Keep</button>
          <button class="btn btn-outline-light w-15 mx-3 text-dark" @click="openVaultFormModal()" aria-label="Create Vault">Create Vault</button>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import { computed } from "vue";
import Login from './Login.vue';
import { AppState } from "../AppState.js";
import { Modal } from "bootstrap";
import KeepForm from "../components/KeepForm.vue";
import VaultForm from "../components/VaultForm.vue";
export default {
  components: { KeepForm, Login, VaultForm },
  setup() {
    return {
      keep: computed(() => AppState.keeps),
      user: computed(() => AppState.user),

      openKeepFormModal() {
        Modal.getOrCreateInstance('#createKeepModal').show()
      },
      openVaultFormModal() {
        Modal.getOrCreateInstance('#createVaultModal').show()
      }
    }
  },
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
