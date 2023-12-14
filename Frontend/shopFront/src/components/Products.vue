<template>
  <div class="container mt-5">
    <div class="mb-3">
      <div class="d-flex align-items-center">
        <h3 class="me-3">Select Category</h3>
        <label for="category" class="form-label"></label>
      </div>
      <div class="d-flex align-items-center">
        <select v-model="selectedCategory" id="category" class="form-control custom-select" @change="fetchProductsByCategory">
          <option value="">All</option>
          <option v-for="category in categories" :key="category" :value="category">
            {{ category }}
          </option>
        </select>
      </div>
    </div>
    <div class="card-container row">
      <div v-for="product in products" :key="product.id" class="card col-md-4 mb-4" @click="goToProductDetails(product.id)">
        <div class="productcard card-body">
          <img :src="product.urlToPicture" class="card-img-top" alt="Product Image">
          <h5 class="card-title">{{ product.name }}</h5>
          <p class="card-text">{{ product.description }}</p>
          <p class="card-text">Category: {{ product.category }}</p>
          <p class="card-text">Price: {{ product.price }} zł</p>
          <p class="card-text">Quantity: {{ product.quantityInStorage }}</p>
        </div>
      </div>
    </div>
    <div v-if="products && products.length === 0">
      <p class="mt-3">No products available.</p>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();

const products = ref([]);
const selectedCategory = ref('');
const categories = ref([]);

const fetchProducts = async () => {
  try {
    const res = await fetch('https://localhost:44396/api/Products');
    const data = await res.json();
    products.value = data;
    categories.value = [...new Set(products.value.map((product) => product.category))];
  } catch (error) {
    console.error('Error fetching products:', error);
  }
};

const fetchProductsByCategory = async () => {
  try {
    const apiUrl = selectedCategory.value
        ? `https://localhost:44396/api/Products/category/${selectedCategory.value}`
        : 'https://localhost:44396/api/Products';

    const res = await fetch(apiUrl);
    const data = await res.json();
    products.value = data;
  } catch (error) {
    console.error('Error fetching products by category:', error);
  }
};

const goToProductDetails = (productId) => {
  router.push({ path: `/product/${productId}` });
};

onMounted(() => {
  fetchProducts();
});
</script>

<style scoped>
.card-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin-top: 20px;
}

.card {
  flex: 0 0 calc(20% - 20px);
  margin-bottom: 20px;
  box-sizing: border-box;
  transition: background-color 0.3s ease;
}

.card-body {
  text-align: center;
}

.productcard:hover {
  background-color: #e0e0e0;
}

.form-label {
  margin-bottom: 0;
}

.custom-select {
  width: 30%;
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  cursor: pointer;
  padding-right: 2.5rem;
  background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="16" height="16" fill="currentColor"><path d="M7 10l5 5 5-5z"/></svg>');
  background-repeat: no-repeat;
  background-position: right 0.7rem center;
  background-size: 1.5em auto;
}
</style>
