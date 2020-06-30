<template>
  <div>
    <v-data-table :headers="headers" :items="orders" item-key="id" show-expand>
      <template v-slot:expanded-item="{ item }">
        <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
          <v-col>
            <v-img :src="orderItem.photoUrl" max-height="120px"></v-img>
          </v-col>
          <v-col>
            <p>{{orderItem.name}}</p>
          </v-col>
          <v-col>
            <p>{{orderItem.id}}</p>
          </v-col>
          <v-col>
            <p>{{orderItem.productPrice}}</p>
          </v-col>
          <v-col>
            <v-text-field
              v-if="editingItemId == item.id"
              v-model="orderItem.quantity"
              hide-details
              single-line
              type="number"
            />
            <p v-else>{{orderItem.quantity}}</p>
          </v-col>
          <v-col>
            <v-icon
              v-if="editingItemId == item.id"
              small
              @click="deleteOrderItem(item.id, orderItem.id)"
            >mdi-delete</v-icon>
          </v-col>
        </v-row>
      </template>

      <template v-slot:item.status="props">
        <v-select
          v-if="editingItemId == props.item.id"
          :items="statusesNames"
          v-model="props.item.status"
          single-line
          dense
          autofocus
        ></v-select>
        <div v-else>{{ props.item.status }}</div>
      </template>

      <template v-slot:item.actions="{ item }">
        <div v-if="editingItemId == item.id">
          <v-icon small class="mr-2" @click="saveItem(item)">mdi-content-save</v-icon>
        </div>
        <div v-if="editingItemId == item.id">
          <v-icon small class="mr-2" @click="cancelEditItem(item)">mdi-close-circle</v-icon>
        </div>
        <div v-else>
          <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
          <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
        </div>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "Orders",
  computed: {
    ...mapState({
      orders: state => state.orders.orders,
      statuses: state => state.statuses.statuses,
      statusesNames(state) {
        return state.statuses.statuses.map(a => a.name);
      }
    })
  },
  created() {
    this.$store.dispatch("orders/fetchAll");
    this.$store.dispatch("statuses/fetchAll");
  },
  methods: {
    editItem: function(item) {
      this.cachedItem = JSON.parse(JSON.stringify(item));
      this.editingItemId = item.id;
    },
    saveItem: function(item) {
      let ids = item.orderItems.map(v => v.productId)
      let ids2 = this.cachedItem.orderItems.map(v => v.productId)
      let idsDeleted = ids2.filter(n => !(ids.indexOf(n) !== -1));
      idsDeleted.forEach(async id => {
        await this.$store.dispatch("orders/deleteOrderItem", { orderId: item.id, productId: id });
      });

      let itemStatus = this.$store.getters['statuses/getByName'](item.status);
      item.statusId = itemStatus.id;

      this.$store.dispatch("orders/updateItem", item).then(() => {
        console.log("k");
      });

      this.editingItemId = -1;
      this.cachedItem = null;
    },
    cancelEditItem: function(item) {
      let index = this.orders.findIndex(x => x.id === item.id);
      this.orders[index] = Object.assign(this.orders[index], this.cachedItem);

      this.editingItemId = -1;
      this.cachedItem = null;
    },
    deleteItem: function(item) {
      this.$store.dispatch("orders/deleteItem", item).then(() => {
        console.log("k2");
      });
    },
    deleteOrderItem: function(orderId, productId) {
      let orderIndex = this.orders.findIndex(x => x.id === orderId);
      let prodIndex = this.orders[orderIndex].orderItems.findIndex(
        x => x.id === productId
      );
      this.orders[orderIndex].orderItems.splice(prodIndex, 1);  // will be saved on saveItem(item)
    }
  },
  data: () => ({
    editingItemId: -1,
    cachedItem: null,
    headers: [
      {
        text: "Order ID",
        value: "id",
        align: "start"
      },
      { text: "Created", value: "dateCreated" },
      { text: "Status", value: "status" },
      { text: "Total", value: "total" },
      { text: "Updated", value: "dateModified" },
      { text: "Actions", value: "actions", sortable: false },
      { text: "", value: "data-table-expand" }
    ]
  })
};
</script>
