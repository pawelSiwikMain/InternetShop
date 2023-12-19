<template>
  <div class="container col-md-6 mx-auto text-center">
    <h2>Order Summary</h2>
    <hr>
    <h5>Items in Cart</h5>
    <div v-for="item in cartItems" :key="item.id" class="cart-item">
      <p> {{ item.name }} - Quantity: {{ item.quqntityInCart }} </p>
    </div>

    <div v-if="deliveryAddress">
      <hr>
      <h5>Delivery Address</h5>
      <p><strong>Street: </strong>{{ deliveryAddress.street }}</p>
      <p><strong>Local Number: </strong>{{ deliveryAddress.localNumber }}</p>
      <p><strong>postCode: </strong>{{ deliveryAddress.postCode }}</p>
      <p><strong>City: </strong>{{ deliveryAddress.city }}</p>
      <button class="btn btn-lg btn-primary" @click="changeAddress">Change address</button>
    </div>

    <div>
      <hr>
      <button class="btn btn-lg btn-primary" @click="payACard">Pay a card</button>
    </div>

    <div v-if="option === 1">
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

    <div v-if="option === 2">
      <form class="form-signin">
        <hr>
        <h1 class="h3 mb-3 font-weight-normal">Payment</h1>

        <label for="expirationDate">Amount</label>
        <input v-model="Amount" class="form-control" placeholder="Amount" required>

        <label for="cardDetails">Card Details</label>
        <div class="d-flex">
          <input v-model="CardNumber" class="form-control mr-2" placeholder="CardNumber" required>
          <input v-model="Cvv" class="form-control" placeholder="Cvv" required>
        </div>

        <label for="expirationDate">Expiration Date</label>
        <div class="d-flex">
          <select v-model="expirationMonth" class="form-control mr-2" id="expirationMonth" required>
            <option value="" disabled selected>Select Month</option>
            <option v-for="month in 12" :key="month" :value="month">{{ month }}</option>
          </select>
          <select v-model="expirationYear" class="form-control" id="expirationYear" required>
            <option value="" disabled selected>Select Year</option>
            <option v-for="year in 11" :key="year" :value="2023 + year">{{ 2023 + year }}</option>
          </select>
        </div>

        <label for="expirationDate">Card type</label>
        <select v-model="CardType" class="form-control" required>
          <option value="" disabled selected>Card Type</option>
          <option value="Visa">Visa</option>
          <option value="MasterCard">MasterCard</option>
        </select>

        <button class="btn btn-lg btn-primary btn-block" type="button" @click="payAndOrder">Pay and order</button>

      </form>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();

const userId = sessionStorage.getItem('userId');
const cartItems = ref([]);
const deliveryAddress = ref({});
const option = ref(0);

const street = ref('');
const city = ref('');
const postCode = ref('');
const localNumber = ref('');

const Amount = ref('');
const Cvv = ref('');
const CardNumber = ref('');
const CardType = ref('');

const expirationMonth = ref('');
const expirationYear = ref('');

const formattedExpirationDate = computed(() => {
  if (expirationMonth.value && expirationYear.value) {
    return `${String(expirationMonth.value).padStart(2, '0')}/${expirationYear.value}`;
  }
  return '';
});

const getUserAddress = async () => {
  try {
    const response = await fetch(`https://localhost:44396/api/Addresses/user/${userId}`);

    if (response.ok) {
      const responseData = await response.text();

      if (responseData) {
        const addressData = JSON.parse(responseData);
        deliveryAddress.value = addressData;
        street.value = addressData.street;
        city.value = addressData.city;
        postCode.value = addressData.postCode;
        localNumber.value = addressData.localNumber;
        sessionStorage.setItem('addressId', addressData.id);
      } else {
        goToAddressFormView();
      }
    } else {
      console.error('Failed to fetch user address');
    }
  } catch (error) {
    console.error('Error fetching user address:', error);
  }
};


const fetchCartItems = async () => {
    const response = await fetch("https://localhost:44396/api/ShopCarts/userId/"+userId);
    if (response.ok) {
      const responseData = await response.json();

      if (responseData) {
        cartItems.value = responseData;
      }
    }
}


const updateAddress = async () => {
  const addressId = sessionStorage.getItem('addressId');

  const requestData = {
    id: addressId,
    userId: userId,
    street: street.value,
    city: city.value,
    postCode: postCode.value,
    localNumber: localNumber.value,
  };

  const requestOptions = {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(requestData),
  };

  try {
    const response = await fetch(`https://localhost:44396/api/Addresses`, requestOptions);

    if (!response.ok) {
      throw new Error('Failed to update address');
    }
    option.value = 0;
    await getUserAddress();
  } catch (error) {
    console.error('Error updating address:', error);
  }
};

const payAndOrder = async () => {
  const requestData = {
    Amount: Amount.value,
    Cvv: Cvv.value,
    ExpirationDate: formattedExpirationDate.value,
    CardNumber: CardNumber.value,
    CardType: CardType.value,
  };

  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(requestData),
  };

  try {
    const response = await fetch('https://localhost:44396/api/Payment', requestOptions);

    if (response.ok) {
      await createOrder();
    } else {
      console.error('Payment failed');
    }
  } catch (error) {
    console.error('Error during payment:', error);
  }
};

const createOrder = async () => {
  const orderData = {
    orderDto: {
      userId: sessionStorage.getItem('userId'),
      addressId: sessionStorage.getItem('addressId'),
    },
    items: cartItems.value.map((item) => ({
      name: item.name,
      quqntity: item.quqntityInCart,
    })),
  };

  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(orderData),
  };

  try {
    const response = await fetch('https://localhost:44396/api/Orders', requestOptions);

    if (response.ok) {
      alert('Order created successfully');
      router.push({ name: 'Home' });

    } else {
      console.error('Order creation failed');
    }
  } catch (error) {
    console.error('Error during order creation:', error);
  }
};

const goToAddressFormView = () => {
  router.push({ name: 'AddressForm' });
};

const changeAddress = () => {
  option.value = 1;
};

const payACard = () => {
  option.value = 2;
}

onMounted(() => {
  getUserAddress();
  fetchCartItems();
});
</script>

<style scoped>
</style>
