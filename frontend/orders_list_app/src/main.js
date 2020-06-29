import Vue from 'vue'
import App from './App.vue'
import router from './router.js'
import store from './store.js'

import ViewDesign from 'view-design';
import 'view-design/dist/styles/iview.css';
Vue.use(ViewDesign);

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
