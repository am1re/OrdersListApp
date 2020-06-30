<template>
  <div>
    <v-data-table
      :loading="tableLoading"
      :headers="headers"
      :items="orders"
      item-key="id"
      show-expand
    >
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-spacer></v-spacer>
          <CreateOrder v-bind:showSnackBar="showSnackBar" />
        </v-toolbar>
      </template>

      <template v-slot:expanded-item="{ item }">
        <td :colspan="headers.length">
          <v-container fluid>
            <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
              <v-col cols="12" sm="6" md="2">
                <v-img :src="orderItem.photoUrl" max-height="120px"></v-img>
                <v-divider class="mx-4" inset vertical></v-divider>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <p>Item.Name : {{orderItem.name}}</p>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <p>Item.Id : {{orderItem.productId}}</p>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <p>Item.Price : {{orderItem.productPrice}}</p>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                Item.Quantity :
                <v-text-field
                  v-if="editingItemId == item.id"
                  v-model="orderItem.quantity"
                  hide-details
                  single-line
                  type="number"
                />
                <p v-else>{{orderItem.quantity}}</p>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <v-icon
                  v-if="editingItemId == item.id"
                  small
                  @click="deleteOrderItem(item.id, orderItem.id)"
                >mdi-delete</v-icon>
              </v-col>
            </v-row>
          </v-container>
        </td>
      </template>

      <template v-slot:item.status="props">
        <v-select
          v-if="editingItemId == props.item.id"
          :items="statusesNames"
          v-model="props.item.status"
          single-line
          dense
          solo
          eager
          style="max-width:141px;max-height: 40px;"
        ></v-select>
        <div v-else>{{ props.item.status }}</div>
      </template>

      <template v-slot:item.actions="{ item }">
        <div v-if="editingItemId == item.id">
          <v-icon small class="mr-2" @click="saveItem(item)">mdi-content-save</v-icon>
        </div>
        <div v-if="editingItemId == item.id">
          <v-icon small class="mr-2" @click="restoreEditItem(item)">mdi-close-circle</v-icon>
        </div>
        <div v-else>
          <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
          <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
        </div>
      </template>
    </v-data-table>

    <v-snackbar v-model="snackbar" :timeout="3000" color="error" dark>
      {{ snackbarMsg }}
      <template v-slot:action="{ attrs }">
        <v-btn color="white" text v-bind="attrs" @click="snackbar = false">Close</v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import { mapState } from "vuex";
import CreateOrder from "./CreateOrder";

export default {
  name: "Orders",
  components: {
    CreateOrder
  },
  computed: {
    ...mapState({
      orders: state => state.orders.orders,
      statusesNames: state => state.statuses.statuses.map(a => a.name)
    })
  },
  async created() {
    try {
      this.tableLoading = true;
      await this.$store.dispatch("orders/fetchAll");
      await this.$store.dispatch("statuses/fetchAll");
    } catch (err) {
      this.showSnackBar(err);
    } finally {
      this.tableLoading = false;
    }
  },
  methods: {
    editItem: function(item) {
      this.cachedItem = JSON.parse(JSON.stringify(item));
      this.editingItemId = item.id;
    },
    saveItem: async function(item) {
      this.tableLoading = true;

      let itemStatus = this.$store.getters["statuses/getByName"](item.status);
      item.statusId = itemStatus.id;

      let orderItemsIds = item.orderItems.map(v => v.productId);
      let cachedOrderItemsIds = this.cachedItem.orderItems.map(
        v => v.productId
      );
      let orderItemsIdsDeleted = cachedOrderItemsIds.filter(
        n => !(orderItemsIds.indexOf(n) !== -1)
      );

      const deleteOrderItems = orderItemsIdsDeleted.map(async id => {
        await this.$store.dispatch("orders/deleteOrderItem", {
          orderId: item.id,
          productId: id
        });
      });

      try {
        await Promise.all(deleteOrderItems);
        await this.$store.dispatch("orders/updateItem", item);
      } catch (err) {
        this.showSnackBar(err);
        this.restoreEditItem(item);
      }

      this.editingItemId = -1;
      this.cachedItem = null;
      this.tableLoading = false;
    },
    restoreEditItem: function(item) {
      let index = this.orders.findIndex(x => x.id === item.id);
      this.orders[index] = Object.assign(this.orders[index], this.cachedItem);

      this.editingItemId = -1;
      this.cachedItem = null;
    },
    deleteItem: async function(item) {
      this.tableLoading = true;
      try {
        await this.$store.dispatch("orders/deleteItem", item);
      } catch (err) {
        this.showSnackBar(err);
      }
      this.tableLoading = false;
    },
    deleteOrderItem: function(orderId, productId) {
      let orderIndex = this.orders.findIndex(x => x.id === orderId);
      let prodIndex = this.orders[orderIndex].orderItems.findIndex(
        x => x.id === productId
      );
      this.orders[orderIndex].orderItems.splice(prodIndex, 1); // will be saved on saveItem(item)
    },
    showSnackBar: function(msg) {
      this.snackbarMsg = msg;
      this.snackbar = true;
    }
  },
  data: () => ({
    editingItemId: -1,
    cachedItem: null,
    tableLoading: false,
    snackbar: false,
    snackbarMsg: "",
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
