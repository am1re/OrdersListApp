<template>
  <v-container fluid>
    <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
      <v-col cols="12" sm="6" md="2">
        <v-img :src="orderItem.photoUrl" max-height="120px"></v-img>
        <v-divider class="mx-4" inset vertical></v-divider>
      </v-col>
      <v-col cols="12" sm="6" md="3">
        <p>
          Product Name :
          <strong>{{orderItem.name}}</strong>
        </p>
      </v-col>
      <!-- <v-col cols="12" sm="6" md="2">
        <p>
          Product Id :
          <strong>{{orderItem.productId}}</strong>
        </p>
      </v-col>-->
      <v-col cols="12" sm="6" md="3">
        <p>
          Product Price :
          <strong>{{orderItem.productPrice}}</strong>
        </p>
      </v-col>
      <v-col cols="12" sm="6" md="3">
        Product Quantity :
        <v-text-field
          v-if="editingItemId == item.id"
          v-model="orderItem.quantity"
          hide-details
          single-line
          type="number"
        />
        <strong v-else>{{orderItem.quantity}}</strong>
      </v-col>
      <v-col cols="12" sm="6" md="1">
        <v-icon
          v-if="editingItemId == item.id"
          small
          @click="deleteOrderItem(item.id, orderItem.id)"
        >mdi-delete</v-icon>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  props: {
    item: Object,
    editingItemId: Number,
    deleteOrderItem: Function
  }
};
</script>

<style scoped>
</style>