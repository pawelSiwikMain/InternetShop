<template>
  <form class="form-signin">
    <img src="../assets/logo.png" alt="Logo">
    <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
    <input v-model="userEmail" type="email" class="form-control mb-2" placeholder="Email" required>
    <input v-model="password" type="password" class="form-control mb-2" placeholder="Password" required>
    <button class="btn btn-lg btn-primary btn-block" type="button" @click="logIn">Sign in</button>
  </form>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const userEmail = ref('');
const password = ref('');

const logIn = () => {
  if (userEmail.value.length < 3) {
    alert("Enter the correct data");
    return;
  }

  const requestData = {
    userEmail: userEmail.value,
    password: password.value,
  };

  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(requestData),
  };

  fetch("https://localhost:44396/api/Authorization/signin", requestOptions)
      .then(response => {
        if (response.ok) {
          return response.json();
        }
      })
      .then(data => {
        if (data && data.userEgzist === false || data && data.passwordCorect === false) {
          alert("Email or password does not match");
        }
          if (data.userIsAdmin === true) {
            sessionStorage.setItem('role', 'admin');
            sessionStorage.setItem('isLoggedIn', 'true');
            console.log('User is an admin.');
          } else {
            console.log('User is a regular user.');
            const userId = data.userId;
            sessionStorage.setItem('isLoggedIn', 'true');
            sessionStorage.setItem('userId', userId);
          }
          router.push('/');
      })
      .catch(error => {
        console.log('error', error);
      });
};
</script>

<style scoped>
.form-signin {
  width: 100%;
  max-width: 330px;
  margin: auto;
  text-align: center;
  align-items: center;
}

</style>
