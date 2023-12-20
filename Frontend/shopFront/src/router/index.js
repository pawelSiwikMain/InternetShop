import { createRouter, createWebHistory } from 'vue-router'

import Home from "@/views/Home.vue";

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/register',
    name: 'RegisterView',
    component: () => import('../views/RegisterView.vue')
  },
  {
    path: '/login',
    name: 'LoginView',
    component: () => import('../views/LoginView.vue')
  },
  {
    path: '/product/:id',
    name: 'ProductDetail',
    component: () => import('../views/ProductDetailView.vue')
  },
  {
    path: '/cart',
    name: 'Cart',
    component: () => import('../views/CartView.vue')
  },
  {
    path: '/orderdetail',
    name: 'OrderDetail',
    component: () => import('../views/OrderDetailView.vue')
  },
  {
    path: '/addressform',
    name: 'AddressForm',
    component: () => import('../views/AddressFormView.vue')
  },
  {
    path: '/admin/products',
    name: 'ManageProducts',
    component: () => import('../views/ManageProductsView.vue')
  },
  {
    path: '/admin/orders',
    name: 'ManageOrders',
    component: () => import('../views/ManageOrdersView.vue')
  },
  {
    path: '/payment',
    name: 'Payment',
    component: () => import('../views/PaymentView.vue')
  },

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
