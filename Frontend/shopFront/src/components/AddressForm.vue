<template>
  <form class="form-signin" @submit.prevent="addAddress">
    <img src="../assets/logo.png" alt="Logo">
    <h1 class="h3 mb-3 font-weight-normal">Please add your address</h1>
    <input v-model="street" class="form-control" placeholder="Street" pattern="[A-Za-z0-9\s]{1,50}" required>
    <input v-model="city" class="form-control" placeholder="City" pattern="[A-Za-z\s]{1,50}" required>
    <input v-model="postCode" class="form-control" placeholder="Post Code ex. 01-123" pattern="[0-9]{2}-[0-9]{3}" required>
    <input v-model="localNumber" class="form-control" placeholder="Local Number" pattern="[0-9]{1,5}">
    <button class="btn btn-lg btn-primary btn-block" type="submit">Add address</button>
  </form>
</template>

<script setup>
import {useRouter} from 'vue-router';
import {ref} from 'vue';

const router = useRouter();
const userId = sessionStorage.getItem("userId");
const street = ref('');
const city = ref('');
const postCode = ref('');
const localNumber = ref('');

const addAddress = () => {

    const requestData = {
      userId: userId,
      street: street.value,
      city: city.value,
      postCode: postCode.value,
      localNumber: localNumber.value,
    };

    const requestOptions = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(requestData),
    };

    fetch("https://localhost:44396/api/addresses", requestOptions)
        .then(response => response.json())
        .then(() => {
          alert("Your address is successfully added");
          router.push('/OrderDetail');
        })
        .catch(error => console.error('Error:', error));
};
</script>

<style scoped>
.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
}
</style>
