<template>
  <div class="ProductsTable">
  <div>
    <hr>
    <h5>Products in Shop</h5>
    <hr>

    <div class="Add">
      <button @click="openAddProductForm" class="btn btn-primary">Add Product</button>
    </div>

    <div v-if="isAddProductFormOpen" class="AddProductForm">
      <input required v-model="name" class="form-control mb-2" placeholder="Name">
      <input required v-model="description" class="form-control mb-2" placeholder="Description">
      <input required v-model="category" class="form-control mb-2" placeholder="Category">
      <input required v-model="price" class="form-control mb-2" placeholder="Price">
      <input required v-model="quqntityInStorage"  class="form-control mb-2" placeholder="Quantity">
      <input required v-model="urlToPicture"  class="form-control mb-2" placeholder="urlToPicture">
      <button @click="addProduct" class="btn btn-success">Save</button>
      <button @click="closeAddProductForm" class="btn btn-secondary">Cancel</button>
    </div>

    <hr>
    <table class="table table-bordered table-hover text-center">
      <thead class="thead-dark">
      <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Description</th>
        <th>Category</th>
        <th>Price</th>
        <th>Quantity</th>
        <th>urlToPicture</th>
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="product in products" :key="product.id">
        <td>{{ product.id }}</td>
        <td>{{ product.name }}</td>
        <td>{{ product.description }}</td>
        <td>{{ product.category }}</td>
        <td>{{ product.price }}</td>
        <td>{{ product.quqntityInStorage }}</td>
        <td class="url-column">{{ product.urlToPicture }}</td>
        <td>
          <button @click="editProduct(product)" class="btn btn-warning mr-2">Edit</button>
          <button @click="deleteProduct(product.id)" class="btn btn-danger">Delete</button>

        </td>
      </tr>
      </tbody>
    </table>
  </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

const isAddProductFormOpen = ref(false);

const products = ref([]);
const name = ref('');
const description = ref('');
const category = ref('');
const price = ref('');
const quqntityInStorage = ref('');
const urlToPicture = ref('');
const openAddProductForm = () => {
  isAddProductFormOpen.value = true;
};

const closeAddProductForm = () => {
  isAddProductFormOpen.value = false;
};
const fetchProducts = async () => {
  try {
    const response = await fetch("https://localhost:44396/api/Products");
    if (response.ok) {
      const responseData = await response.json();
      if (responseData) {
        products.value = responseData;
      }
    }
  } catch (error) {
    console.error('Error fetching products:', error);
  }
};

onMounted(() => {
  fetchProducts();
});

const addProduct = async () => {
  try {
    const requestData = {
      name: name.value,
      description: description.value,
      category: category.value,
      price: price.value,
      quqntityInStorage: quqntityInStorage.value,
      urlToPicture: urlToPicture.value,
    };

    const response = await fetch("https://localhost:44396/api/Products", {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(requestData),
    });

    if (response.ok) {
      fetchProducts();
      name.value = '';
      description.value = '';
      category.value = '';
      price.value = '';
      quqntityInStorage.value = '';
      urlToPicture.value = '';
      closeAddProductForm();
    } else {
      throw new Error('Failed to add product');
    }
  } catch (error) {
    console.error('Error adding product:', error);
  }
};


const editProduct = (product) => {
  console.log('Editing product:', product);
};

const deleteProduct = (productId) => {
  fetch("https://localhost:44396/api/Products/" + productId, {
    method: 'DELETE',
  })
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to remove product');
        }
        console.log('Successfully removed product');
        fetchProducts();
      })
      .catch(error => console.error('Error:', error));
};
</script>

<style scoped>
.ProductsTable{
  display: flex;
  justify-content: center;
  align-items: center;
}

.Add {
  display: flex;
  justify-content: center;
  align-items: center;
}

.url-column {
  max-width: 150px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.Add button{
  width: 100%;
}

h5{
  text-align: center;
  padding: 10px;
}
</style>
