<template>
  <div class="container-fluid">
    <div class="row mb-3">
      <div class="col-12">
        <div class="description-card p-4">
          <div class="description-content">
            <img src="@/assets/logo.png" alt="Logo" class="description-logo">
            <div>
              <h1>Welcome to our MPK Furniture Store!</h1>
              <h6>
                We specialize in offering a diverse range of high-quality furniture.<br>
                We offer everything you need to furnish your home beautifully.<br>
                Our store has been proudly serving customers for over 20 years.
              </h6>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-md-2 bg-light p-4">

        <div class="mb-3">
          <h3>Select Category</h3>
          <label for="category" class="form-label"></label>
          <select v-model="selectedCategory" id="category" class="form-control custom-select" @change="fetchProductsByCategory">
            <option value="">All</option>
            <option v-for="category in categories" :key="category" :value="category">
              {{ category }}
            </option>
          </select>
        </div>

        <div class="mb-3">
          <h3>Filter by Price</h3>
          <input v-model.number="minPrice" type="number" class="form-control mb-2" placeholder="Min Price">
          <input v-model.number="maxPrice" type="number" class="form-control mb-2" placeholder="Max Price">
          <button @click="filterByPrice" class="btn btn-primary">Apply</button>
        </div>

        <div class="mb-3">
          <h3>Search Products</h3>
          <input v-model="searchTerm" type="text" class="form-control mb-2" placeholder="Search" list="productSuggestions">
          <datalist id="productSuggestions">
            <option v-for="suggestion in productSuggestions" :key="suggestion" :value="suggestion"></option>
          </datalist>
          <button @click="searchProducts" class="btn btn-primary">Search</button>
        </div>
      </div>

      <div class="col-md-10">
        <div class="row">
          <div v-for="product in filteredProducts" :key="product.id" class="col-12 col-md-4 col-lg-3 mb-4">
            <div class="card" @click="goToProductDetails(product)">
              <img :src="product.urlToPicture" class="card-img-top" alt="Product Image">
              <div class="card-body">
                <h5 class="card-title">{{ product.name }}</h5>
                <p class="card-text"><strong>Category:</strong> {{ product.category }}</p>
                <p class="card-text"><strong>Price:</strong> {{ product.price }} zł</p>
              </div>
            </div>
          </div>
        </div>

        <div v-if="filteredProducts && filteredProducts.length === 0">
          <p class="mt-3">No products available.</p>
        </div>
      </div>
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
const minPrice = ref(null);
const maxPrice = ref(null);
const searchTerm = ref('');
const filteredProducts = ref([]);
const productSuggestions = ref([]);

const fetchProducts = async () => {
  try {
    const res = await fetch('https://localhost:44396/api/Products');
    const data = await res.json();
    products.value = data;
    categories.value = [...new Set(products.value.map((product) => product.category))];
    filteredProducts.value = [...products.value];
    productSuggestions.value = [...new Set(products.value.map((product) => product.name.toLowerCase()))];
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
    filterByPrice();
    updateProductSuggestions();
  } catch (error) {
    console.error('Error fetching products by category:', error);
  }
};

const filterByPrice = () => {
  filteredProducts.value = products.value.filter(product => {
    const price = product.price;

    const minCondition = minPrice.value === null || price >= minPrice.value;
    const maxCondition = maxPrice.value === null || price <= maxPrice.value;

    return minCondition && maxCondition;
  });
};

const searchProducts = () => {
  const searchTermLower = searchTerm.value.toLowerCase();
  filteredProducts.value = products.value.filter(product =>
      product.name.toLowerCase().includes(searchTermLower) ||
      product.description.toLowerCase().includes(searchTermLower) ||
      product.category.toLowerCase().includes(searchTermLower)
  );
};

const goToProductDetails = (product) => {
  router.push({ name: 'ProductDetail', params: { id: product.id } });
};

const updateProductSuggestions = () => {
  productSuggestions.value = [...new Set(products.value.map((product) => product.name.toLowerCase()))];
};

onMounted(() => {
  fetchProducts();
});
</script>

<style scoped>

.btn-primary {
  width: 100%;
  margin-top: 10px;
}

.card {
  width: 100%;
  height: 100%;
  text-align: center;
  align-items: center;
}

.description-card {
  text-align: center;
  background: whitesmoke;
  border: 1px black solid;
}

.card-body {
  flex-grow: 1;
}

.card-img-top {
  max-height: 200px;
  max-width: 200px;
}

.description-content {
  display: flex;
  justify-content: center;
}

.description-logo {
  max-width: 150px;
  max-height: 150px;

}

</style>
