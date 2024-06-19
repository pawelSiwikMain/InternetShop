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
          <p><strong>Quantity:</strong> {{ product.quqntityInStorage }}</p>

          <div class="mt-3" v-if="addToCartMessage">
            <p class="text-success">{{ addToCartMessage }}</p>
          </div>

          <div class="mt-5">
            <button v-if="isLoggedIn" @click="addToCart" class="btn btn-primary">Add to Cart</button>
            <h4 v-else class="mt-3">
              Please <router-link :to="{ name: 'LoginView' }">log in</router-link> to add to cart.
            </h4>
          </div>

        </div>
        <div class="mt-3 mb-3">
          <button class="btn btn-primary ml-3" @click="goToHomePage">Back to home</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';

const product = ref(null);
const route = useRoute();
const router = useRouter();
const id = route.params.id;
const isLoggedIn = sessionStorage.getItem('isLoggedIn') === 'true'; // Konwertujemy na boolean

const addToCartMessage = ref('');

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
          addToCartMessage.value = 'Product added to cart successfully!';
        } else {
          console.error("Error adds product to cart", response.statusText);
          addToCartMessage.value = 'Failed to add product to cart';
        }
      } catch (error) {
        console.error("Error adds product to cart", error);
        addToCartMessage.value = 'Failed to add product to cart';
      }
    }
  }
};

const goToHomePage = () => {
  router.push({ name: 'Home' })
}

onMounted(() => {
  fetchProductDetails();
});
</script>

<style scoped>
.product-image {
  text-align: center;
  margin-bottom: 20px;
}

.img-fluid {
  max-width: 400px;
  max-height: 400px;
}

.product-details {
  padding: 20px;
}
</style>
