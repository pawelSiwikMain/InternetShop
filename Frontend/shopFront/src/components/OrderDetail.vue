<template>
  <div class="container col-md-6 mx-auto text-center">
    <h2>Order Summary</h2>
    <hr>
    <h5>Items in Cart</h5>
    <div v-for="item in cartItems" :key="item.id" class="cart-item">
      <p>
        {{ item.name }} - Quantity: {{ item.quqntityInCart }}
      </p>
    </div>
    <div>
      <hr>
      <h5>Delivery Address</h5>
      <p v-if="deliveryAddress">{{ deliveryAddress.street }}, {{ deliveryAddress.city }}, {{ deliveryAddress.postCode }}</p>
      <button class="btn btn-lg btn-primary" @click="ChangeAddress">Change address</button>
    </div>
    <div v-if="Change === 1">
      <form class="form-signin">
        <img src="../assets/logo.png" alt="Logo">
        <h1 class="h3 mb-3 font-weight-normal">Update address</h1>
        <input v-model="street" class="form-control" placeholder="Street" required>
        <input v-model="city" class="form-control" placeholder="City" required>
        <input v-model="postCode" class="form-control" placeholder="Post Code" required>
        <input v-model="localNumber" class="form-control" placeholder="Local Number" required>
        <button class="btn btn-lg btn-primary btn-block" type="button" @click="updateAddress">Update address</button>
      </form>
    </div>
    <div class="mt-3">
      <hr>
      <button class="btn btn-lg btn-primary" @click="goToPayment">Proceed to Payment</button>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const userId = sessionStorage.getItem("userId");
const cartItems = ref([]);
const deliveryAddress = ref({});
const Change = ref(0);
const street = ref('');
const city = ref('');
const postCode = ref('');
const localNumber = ref('');

const getUserAddress = async () => {
  try {
    const response = await fetch(`https://localhost:44396/api/Addresses/user/${userId}`);

    if (response.ok) {
      const responseData = await response.json();

      if (responseData) {
        deliveryAddress.value = responseData;
        street.value = responseData.street;
        city.value = responseData.city;
        postCode.value = responseData.postCode;
        localNumber.value = responseData.localNumber;
        sessionStorage.setItem("addressId", responseData.id);
      } else {
        goToAddressFormView();
      }
    } else {
      goToAddressFormView();
    }
  } catch (error) {
    console.error('Error fetching user address:', error);
  }
};

const updateAddress = async () => {
  const addressId = sessionStorage.getItem("addressId");

  const requestData = {
    id: addressId,
    userId: userId,
    street: street.value,
    city: city.value,
    postCode: postCode.value,
    localNumber: localNumber.value,
  };

  const requestOptions = {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(requestData),
  };

  try {
    const response = await fetch(`https://localhost:44396/api/Addresses`, requestOptions);

    if (!response.ok) {
      throw new Error('Failed to update address');
    }
    Change.value = 0;
    await getUserAddress();
  } catch (error) {
    console.error('Error updating address:', error);
  }
};




const goToAddressFormView = () => {
  router.push({ name: 'AddressForm' });
};

const goToPayment = () => {
  router.push({ name: "Payment" });
};

const ChangeAddress = () => {
  Change.value = 1;
};

onMounted(() => {
  getUserAddress();
});
</script>

<style scoped>
</style>
