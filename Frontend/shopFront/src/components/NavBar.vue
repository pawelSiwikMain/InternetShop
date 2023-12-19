<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const isLoggedIn = ref(sessionStorage.getItem('isLoggedIn') === 'true');
const router = useRouter();

const logout = () => {
  isLoggedIn.value = false;
  sessionStorage.setItem('isLoggedIn', `${false}`);
  sessionStorage.removeItem('isLoggedIn');
  sessionStorage.removeItem('userId');
  sessionStorage.removeItem('addressId');
  router.push('/login');
};
</script>

<template>
  <nav class="navbar navbar-expand-md navbar-dark bg-dark mb-4">
    <div class="container-fluid">
      <router-link to="/" class="navbar-brand">
        <img src="@/assets/logo.png" alt="Company Logo" width="50" height="50">Home</router-link>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarNav">
        <div class="ml-auto">
          <ul class="navbar-nav">
            <li v-if="!isLoggedIn" class="nav-item">
              <router-link to="/login" class="nav-link" data-toggle="collapse" data-target=".navbar-collapse.show">Login</router-link>
            </li>
            <li v-if="!isLoggedIn" class="nav-item">
              <router-link to="/register" class="nav-link" data-toggle="collapse" data-target=".navbar-collapse.show">Register</router-link>
            </li>
            <li v-if="isLoggedIn" class="nav-item">
              <router-link to="/cart" class="nav-link" data-toggle="collapse" data-target=".navbar-collapse.show">Cart</router-link>
            </li>
            <li v-if="isLoggedIn" class="nav-item">
              <router-link to="/" class="nav-link" @click="logout" data-toggle="collapse" data-target=".navbar-collapse.show">Logout</router-link>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>
