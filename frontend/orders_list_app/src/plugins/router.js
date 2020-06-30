import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/orders',
    name: 'Orders',
    component: () => import('@/views/Orders.vue')
  },
  {
    path: '*',
    redirect: '/orders'
  }
]

const router = new VueRouter({
  routes
})

export default router