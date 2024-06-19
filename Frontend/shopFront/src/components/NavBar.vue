<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const isLoggedIn = ref(sessionStorage.getItem('isLoggedIn') === 'true');
const router = useRouter();

const role = sessionStorage.getItem('role');
const isAdmin = role === 'admin';

const logout = () => {
  sessionStorage.setItem('isLoggedIn', 'false');
  sessionStorage.removeItem('userId');
  sessionStorage.removeItem('addressId');
  sessionStorage.removeItem('role');
  router.push('/login');
};

const toggleNavbarCollapse = () => {
  const navbar = document.querySelector('.navbar-collapse');
  navbar.classList.toggle('show');
};
</script>

<template>
  <div class="d-flex flex-column min-vh-100">
    <nav class="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div class="container-fluid">
        <router-link to="/" class="navbar-brand">
          <img src="@/assets/logo.png" alt="Company Logo" width="50" height="50">Home
        </router-link>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation" @click="toggleNavbarCollapse">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse">
          <ul class="navbar-nav ml-auto">

            <!-- Niezalogowany użytkownik -->
            <li v-if="!isLoggedIn && !isAdmin" class="nav-item">
              <router-link to="/login" class="nav-link" @click="toggleNavbarCollapse">Login</router-link>
            </li>
            <li v-if="!isLoggedIn && !isAdmin" class="nav-item">
              <router-link to="/register" class="nav-link" @click="toggleNavbarCollapse">Register</router-link>
            </li>

            <!-- Zalogowany użytkownik -->
            <li v-if="isLoggedIn && !isAdmin" class="nav-item">
              <router-link to="/cart" class="nav-link" @click="toggleNavbarCollapse">Cart</router-link>
            </li>
            <li v-if="isLoggedIn && !isAdmin" class="nav-item">
              <router-link to="/" class="nav-link" @click="logout">Logout</router-link>
            </li>

            <!-- Opcje admina -->
            <li v-if="isLoggedIn && isAdmin" class="nav-item">
              <router-link to="/admin/products" class="nav-link" @click="toggleNavbarCollapse">Manage Products</router-link>
            </li>
            <li v-if="isLoggedIn && isAdmin" class="nav-item">
              <router-link to="/admin/orders" class="nav-link" @click="toggleNavbarCollapse">Manage Orders</router-link>
            </li>
            <li v-if="isLoggedIn && isAdmin" class="nav-item">
              <router-link to="/" class="nav-link" @click="logout" >Logout</router-link>
            </li>

          </ul>
        </div>
      </div>
    </nav>

    <div class="flex-grow-1">
      <slot></slot>
    </div>

    <footer class="bg-dark text-white text-center py-3 mt-auto">
      <div class="container">
        <p>&copy; 2024 MPK Furniture Store</p>
      </div>
    </footer>
  </div>
</template>
