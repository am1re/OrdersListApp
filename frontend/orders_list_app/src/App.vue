<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app clipped>
      <v-list>
        <v-list-item link router-link to="/orders">
          <v-list-item-action>
            <v-icon>mdi-clipboard-list</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Orders</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link router-link to="/products">
          <v-list-item-action>
            <v-icon>mdi-package</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Products</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar color="#2D68EA" dark app clipped-left>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>Orders List App</v-toolbar-title>
    </v-app-bar>

    <v-main>
      <v-container>
        <v-row align="start" justify="center">
          <v-col>
            <router-view></router-view>
          </v-col>
        </v-row>
      </v-container>
    </v-main>

    <v-footer color="#2D68EA" dark app>
      <v-icon>mdi-emoticon-happy</v-icon>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: "App",
  data: () => ({
    drawer: true
  })
};
</script>
