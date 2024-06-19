<template>
  <form class="form-payment" @submit.prevent="Process">
    <hr>
    <h1 class="h3 mb-3 font-weight-normal">Payment</h1>

    <label for="amount">Amount</label>
    <input v-model="Amount" class="form-control" placeholder="Amount" required readonly>

    <hr>
    <div class="d-flex">
      <div class="col-md-8">
        <label for="CardNumber" class="form-label">Card Number</label>
        <input v-model="CardNumber" id="CardNumber" class="form-control" placeholder="Card Number" pattern="[0-9]{16}" maxlength="16" required>
      </div>
      <div class="col-md-4">
        <label for="Cvv" class="form-label">CVV</label>
        <input v-model="Cvv" id="Cvv" class="form-control" placeholder="CVV" pattern="[0-9]{3}" maxlength="3" required>
      </div>
    </div>

    <hr>
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

    <hr>
    <label for="cardType">Card Type</label>
    <select v-model="CardType" class="form-control" required>
      <option value="" disabled selected>Card Type</option>
      <option value="Visa">Visa</option>
      <option value="MasterCard">MasterCard</option>
    </select>

    <button class="btn btn-lg btn-primary btn-block mt-3" type="submit">Pay and order</button>

  </form>
</template>

<script setup>
import { ref, computed} from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const userId = sessionStorage.getItem("userId");

const Amount = sessionStorage.getItem("totalOrderPrice");

const Cvv = ref("");
const CardNumber = ref("");
const CardType = ref("");

const expirationMonth = ref("");
const expirationYear = ref("");

const formattedExpirationDate = computed(() => {
  if (expirationMonth.value && expirationYear.value) {
    return `${String(expirationMonth.value).padStart(2, '0')}/${expirationYear.value}`;
  }
  return "";
});

const payAndOrder = async () => {
  const requestData = {
    "amount": Amount,
    "cvv": Cvv.value,
    "expirationDate": formattedExpirationDate.value,
    "cardNumber": CardNumber.value,
    "cardType": CardType.value
  };

  try {
    const response = await fetch('https://localhost:44396/api/Payment', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(requestData),
    });

    const responseData = await response.json();

    console.log('Response:', response.status, response.headers, responseData);

    if (response.status === 200) {
      console.log('Success:', responseData);
    } else {
      console.error('Payment failed:', responseData);
    }

    return responseData;
  } catch (error) {
    console.error('Error during payment:', error);
    throw error;
  }
};

const Process = async () => {
  try {
    const orderItems = [];
    const response = await payAndOrder();

    if (response.success) {
      const cartsItems = await fetchCartItems();
      cartsItems.forEach(function callback(currentValue) {
        const obj = {
          name: currentValue.name,
          quqntity: currentValue.quqntityInCart,
        };
        orderItems.push(obj);
        removeItem(currentValue.id);
      });
      await createOrder(orderItems);
      alert("Order placed successfully");
      await router.push({ name: "Home" });
    } else {
      alert("Failed to complete the purchase");
      await router.push({ name: "Cart" });
    }
  } catch (error) {
    console.error('Error processing the order:', error);
  }
};

const removeItem = async (itemId) => {
  try {
    const response = await fetch(`https://localhost:44396/api/ShopCarts/${itemId}`, {
      method: 'DELETE',
    });

    if (!response.ok) {
      throw new Error('Failed to remove item from the cart');
    }

    console.log('Successfully removed item from the cart');
    await fetchCartItems();
  } catch (error) {
    console.error('Error:', error);
  }
};

const fetchCartItems = async () => {
  try {
    const response = await fetch(`https://localhost:44396/api/ShopCarts/userId/${userId}`);

    if (response.ok) {
      return response.json();
    }
  } catch (error) {
    console.error('Error fetching cart items:', error);
    throw error;
  }
};

const createOrder = async (obj) => {
  try {
    const addressId = sessionStorage.getItem('addressId');

    if (!userId || !addressId) {
      console.error('Invalid userId or addressId');
      return;
    }

    const orderData = {
      orderDto: {
        userId: userId,
        addressId: addressId,
      },
      items: obj,
    };

    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(orderData),
    };

    const response = await fetch('https://localhost:44396/api/Orders', requestOptions);

    if (response.ok) {
      alert('Order created successfully');
      await router.push({name: 'Home'});
    } else {
      console.error('Order creation failed');
    }
  } catch (error) {
    console.error('Error during order creation:', error);
    throw error;
  }
};

</script>

<style scoped>
.form-payment {
  width: 100%;
  max-width: 330px;
  margin: auto;
  text-align: center;
  align-items: center;
}

label {
  text-transform: uppercase;
  font-size: 10px;
  letter-spacing: 2px;
  padding-left: 5px;
}

</style>
