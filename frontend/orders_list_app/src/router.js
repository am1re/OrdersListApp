import Vue from 'vue'
import VueRouter from 'vue-router'
import ViewDesign from 'view-design';

import Home from './views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
  }
]

const router = new VueRouter({
  routes
})

router.beforeEach((_to, _from, next) => {
  ViewDesign.LoadingBar.start();
  next();
});

router.afterEach(() => {
  ViewDesign.LoadingBar.finish();
  window.scrollTo(0, 0);
});

export default router