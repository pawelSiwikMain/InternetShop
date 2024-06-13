<template>
  <form class="form-signin" @submit.prevent="submitForm">
    <img src="../assets/logo.png" alt="Logo">
    <h1 class="h3 mb-3 font-weight-normal">Please register</h1>
    <input required v-model="email" type="email" class="form-control mb-2" placeholder="Email">
    <input required v-model="name" class="form-control mb-2" placeholder="Name">
    <input required v-model="lastName" class="form-control mb-2" placeholder="LastName">
    <input required v-model="phone" type="tel" class="form-control mb-2" placeholder="Phone ex.123456789" pattern="[0-9]{9}">
    <input required v-model="password" type="password" class="form-control mb-2" placeholder="Password">
    <input required v-model="repassword" type="password" class="form-control mb-2" placeholder="Re-type password">
    <button class="btn btn-lg btn-primary btn-block" type="submit">Register</button>
  </form>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const email = ref('');
const name = ref('');
const lastName = ref('');
const phone = ref('');
const password = ref('');
const repassword = ref('');

const router = useRouter();

const submitForm = () => {
  if (password.value !== repassword.value) {
    alert("Password do not match.");
    return false;
  }

  // Min password length validation
  if (password.value.length >= 1 && password.value.length < 8) {
    alert("Password length must be at least 8 characters.");
    return false;
  }

  if ( email.value === '' || name.value === '' || lastName.value === '' || phone.value === '' || password.value !== repassword.value || password.value.length < 8 ) {
    alert("Enter the correct data.");
    return false;
  }

  register();
  return true;
};

const register = () => {
  const requestData = {
    email: email.value,
    name: name.value,
    lastName: lastName.value,
    phone: phone.value,
    password: password.value,
  };

  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(requestData),
  };

  fetch("https://localhost:44396/api/Authorization/signup", requestOptions)
      .then(response => response.json())
      .then(() => {
        alert("New user successfully added");
        router.push('/login');
      })
      .catch(error => console.error('Error:', error));
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
