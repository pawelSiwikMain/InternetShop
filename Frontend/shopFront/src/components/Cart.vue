<template>
  <div class="container col-md-4 mx-auto text-center">
    <div v-if="cartItems.length > 0">
      <div v-for="(item) in cartItems" :key="item.id">
        <div class="card">
          <div class="card-body d-flex align-items-center">
            <img :src="item.urlToOffer" class="card-img-left" alt="Product Image">
            <div class="ml-3 flex-grow-1">
              <h5 class="card-title">{{ item.name }}</h5>
              <p class="card-text">{{ item.price }} zł</p>
            </div>
            <div>
              <button @click="MinusQuantity(item)" class="btn btn-secondary mr-2">-</button>
              <label class="form-label mr-2"> {{item.quqntityInCart}} </label>
              <button @click="PlusQuantity(item)" class="btn btn-secondary mr-2" >+</button>
            </div>
            <button class="btn btn-danger" @click="removeItem(item.id)">Delete</button>
          </div>
        </div>
      </div>
      <div class="mt-3">
        <p>Total Order Price: <strong>{{ totalOrderPrice }} zł</strong></p>
      </div>
      <div class="mt-3">
        <button class="btn btn-lg btn-primary" @click="goToOrderDetail">Go to Order</button>
      </div>
      <div class="mt-3">
        <button class="btn btn-lg btn-primary" @click="goToHomePage">Back to home</button>
      </div>
    </div>
    <div v-else>
      <p>Your cart is empty.</p>
      <div class="mt-3">
        <button class="btn btn-lg btn-primary" @click="goToHomePage">Back to home</button>
      </div>
    </div>
  </div>
</template>



<script setup>
import {ref, onMounted, computed} from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const userId = sessionStorage.getItem("userId");
const cartItems = ref([]);

const fetchCartItems = async () => {
  try {
    const response = await fetch("https://localhost:44396/api/ShopCarts/userId/"+userId);
    if (!response.ok) {
      throw new Error("Failed to fetch cart items");
    }
    cartItems.value = await response.json();
    saveTotalOrderPriceToLocalStorage();
  } catch (error) {
    console.error("Error fetching cart items:", error);
  }
};

const goToOrderDetail = () => {
  router.push({ name: "OrderDetail" });
};

const goToHomePage = () => {
  router.push({ name: "Home"})
}

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
    saveTotalOrderPriceToLocalStorage();
  } catch (error) {
    console.error('Error:', error);
  }
};

const updateQuantity = async (item) => {
  const userId = sessionStorage.getItem('userId');

  const requestData = {
    id: item.id,
    userId: userId,
    productId: item.productId,
    name: item.name,
    price: item.price,
    quqntityInCart: item.quqntityInCart,
    urlToOffer: item.urlToOffer,
  };

  const requestOptions = {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(requestData),
  };

  try {
    const response = await fetch(`https://localhost:44396/api/ShopCarts`, requestOptions);

    if (!response.ok) {
      throw new Error('Failed to update address');
    }

    await fetchCartItems();
    saveTotalOrderPriceToLocalStorage();
  } catch (error) {
    console.error('Error updating address:', error);
  }
};


const PlusQuantity = (item) => {
  item.quqntityInCart++;
  updateQuantity(item);
}

const MinusQuantity = (item) => {
  if (item.quqntityInCart > 0) {
    item.quqntityInCart--;
    updateQuantity(item);
  }
}

const totalOrderPrice = computed(() => {
  let total = 0;
  cartItems.value.forEach(item => {
    total += item.price * item.quqntityInCart;
  });
  return total.toFixed(2);
});

const saveTotalOrderPriceToLocalStorage = () => {
  sessionStorage.setItem('totalOrderPrice', totalOrderPrice.value);
};

onMounted(() => {
  fetchCartItems();
});
</script>

<style scoped>
.card-img-left{
  width: 50px;
  height: 50px;
}
</style>
