<template>
  <div class="container col-md-4 mx-auto text-center">
    <div v-if="cartItems.length > 0">
      <div v-for="item in cartItems" :key="item.id">
        <div class="card">
          <div class="card-body d-flex align-items-center">
            <img :src="item.urlToOffer" class="card-img-left" alt="Product Image">
            <div class="ml-3 flex-grow-1">
              <h5 class="card-title">{{ item.name }}</h5>
              <p class="card-text">{{ item.price }} zł</p>
            </div>
            <button class="btn btn-danger" @click="removeItem(item.id)">Delete</button>
          </div>
        </div>
      </div>
      <div class="mt-3">
        <button class="btn btn-lg btn-primary" @click="goToOrderDetail">Go to Order</button>
      </div>
    </div>
    <div v-else>
      <p>Your cart is empty.</p>
    </div>
  </div>
</template>



<script setup>
import { ref, onMounted } from 'vue';
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
  } catch (error) {
    console.error("Error fetching cart items:", error);
  }
};

const goToOrderDetail = () => {
  router.push({ name: "OrderDetail" });
};

const removeItem = (itemId) => {
  fetch(`https://localhost:44396/api/ShopCarts/${itemId}`, {
    method: 'DELETE',
  })
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to remove item from the cart');
        }
        console.log('Successfully removed item from the cart');
        fetchCartItems();
      })
      .catch(error => console.error('Error:', error));
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
