import Vue from 'vue'
import Vuex from 'vuex'

import orders from './orders'
import products from './products'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    orders,
    products
  }
})

export default store