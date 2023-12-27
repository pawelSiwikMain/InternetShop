<template>
  <div class="container mt-5" v-if="product">
    <div class="row">
      <div class="col-md-6">
        <div class="product-image">
          <img :src="product.urlToPicture" class="img-fluid" alt="Product Image">
        </div>
      </div>
      <div class="col-md-6">
        <div class="product-details">
          <h2>{{ product.name }}</h2>
          <p class="description">{{ product.description }}</p>
          <p><strong>Category:</strong> {{ product.category }}</p>
          <p><strong>Price:</strong> {{ product.price }} zł</p>
          <p><strong>Quantity:</strong> {{ product.quantityInStorage }}</p>
          <button v-if="auth" @click="addToCart" class="btn btn-primary">Add to Cart</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const product = ref(null);
const route = useRoute();
const id = route.params.id;
const auth = sessionStorage.getItem('isLoggedIn');

const fetchProductDetails = async () => {
  try {
    const response = await fetch(`https://localhost:44396/api/Products/${id}`);
    if (!response.ok) {
      throw new Error('Failed to fetch product details');
    }
    product.value = await response.json();
  } catch (error) {
    console.error('Error fetching product details:', error);
  }
};

const addToCart = async () => {
  if (product.value && product.value.id) {
    const userId = sessionStorage.getItem('userId');

    if (userId) {
      const cartItem = {
        userId: userId,
        productId: product.value.id,
        name: product.value.name,
        price: product.value.price,
        quqntityInCart: 1,
        urlToOffer: product.value.urlToPicture,
      };

      console.log('Add to cart:', cartItem);

      try {
        const response = await fetch('https://localhost:44396/api/ShopCarts', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(cartItem),
        });

        if (response.ok) {
          console.log('Successful add to cart');

        } else {
          console.error("Error adds product to cart", response.statusText);
          alert("Error ads product to cart");
        }
      } catch (error) {
        console.error("Error adds product to cart", error);
        alert("Error ads product to cart");
      }
    } else {
      console.error('No auth user');
      alert("Log in to place an order");
    }
  } else {
    console.error('Error: product or product.id is undefined');
  }
};

onMounted(() => {
  fetchProductDetails();
});
</script>

<style scoped>
.product-image {
  text-align: center;
  margin-bottom: 20px;
}

.product-details {
  padding: 20px;
}
</style>
