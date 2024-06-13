<template>
  <div class="OrderManagement">
    <h1>Order Management (Manager View)</h1>

    <!-- Orders Table -->
    <table v-show="showOrdersTable" class="table table-bordered table-hover text-center mt-4">
      <thead class="thead-dark">
      <tr>
        <th>Order ID</th>
        <th>User</th>
        <th>Address</th>
        <th>Products</th>
        <th>Action</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="order in orders" :key="order.id">
        <td>{{ order.id }}</td>
        <td>
          <div v-if="order.user">{{ `${order.user.name} ${order.user.lastName}` }}</div>
        </td>
        <td>
          <div v-if="order.address">
            {{ `${order.address.street}/${order.address.localNumber}` }}
            <br>
            {{ `${order.address.postCode}, ${order.address.city}` }}
          </div>
        </td>
        <td>
          <div v-for="item in order.orderItemDtos" :key="item.id">
            {{ item && item.name }} (Quantity: {{ item && item.quqntity }})
          </div>
        </td>
        <td>
          <button @click="confirmOrderCompletion(order.id)" class="btn btn-success">Completed</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import {ref, onMounted} from "vue";

const orders = ref([]);
const showOrdersTable = ref(true);

const fetchOrders = async () => {
  try {
    const response = await fetch("https://localhost:44396/api/Orders");
    if (response.ok) {
      orders.value = await response.json();
      await loadAdditionalOrderDetails();
    } else {
      console.error("Error fetching orders:", response.statusText);
    }
  } catch (error) {
    console.error("Error fetching orders:", error);
  }
};

const loadAdditionalOrderDetails = async () => {
  for (const order of orders.value) {
    await loadUserAndAddressDetails(order);
  }
};

const loadUserAndAddressDetails = async (order) => {
  try {
    const userResponse = await fetch(`https://localhost:44396/api/Users/${order.userId}`);
    const addressResponse = await fetch(`https://localhost:44396/api/Addresses/${order.addressId}`);

    if (userResponse.ok && addressResponse.ok) {
      const userData = await userResponse.json();
      const addressData = await addressResponse.json();
      order.user = userData;
      order.address = addressData;
    } else {
      console.error("Error fetching user or address data");
    }
  } catch (error) {
    console.error("Error fetching user or address data:", error);
  }
};

const confirmOrderCompletion = async (orderId) => {
  try {
    const response = await fetch(`https://localhost:44396/api/Orders/${orderId}`, {
      method: "DELETE",
    });

    if (response.ok) {
      orders.value = orders.value.filter(order => order.id !== orderId);
    } else {
      console.error("Error deleting order:", response.statusText);
    }
  } catch (error) {
    console.error("Error deleting order:", error);
  }
};

onMounted(() => {
  fetchOrders();
});
</script>

<style scoped>
.OrderManagement {
  display: flex;
  flex-direction: column;
  align-items: center;
}

table {
  width: 80%;
  margin-top: 20px;
  text-align: center;
}

table th,
table td {
  padding: 8px;
  vertical-align: middle;
  text-align: center;
}
</style>
