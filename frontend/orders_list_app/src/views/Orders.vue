<template>
  <v-data-table :headers="headers" :items="orders" item-key="id" show-expand>
    <template v-slot:expanded-item="{ item }">
      <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
        <!-- <v-col>
          <v-img :src="orderItem.photoUrl"></v-img>
        </v-col>-->
        <v-col>
          <p>{{orderItem.name}}</p>
        </v-col>
        <v-col>
          <p>{{orderItem.id}}</p>
        </v-col>
        <v-col>
          <p>{{orderItem.price}}</p>
        </v-col>
        <v-col>
          <v-text-field
            v-if="editingItem == item.id"
            v-model="orderItem.quantity"
            hide-details
            single-line
            type="number"
          />
          <p v-else>{{orderItem.quantity}}</p>
        </v-col>
      </v-row>
    </template>

    <template v-slot:item.status="props">
      <v-select
        v-if="editingItem == props.item.id"
        :items="statuses"
        v-model="props.item.status"
        single-line
        dense
        autofocus
      ></v-select>
      <div v-else>{{ props.item.status }}</div>
    </template>

    <template v-slot:item.actions="{ item }">
      <div v-if="editingItem == item.id">
        <v-icon small class="mr-2" @click="editItem(item)">mdi-content-save</v-icon>
      </div>
      <div v-else>
        <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
        <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
      </div>
    </template>
    
  </v-data-table>
</template>

<script>
export default {
  name: "Orders",
  components: {},
  methods: {
    editItem: function(item) {
      this.editingItem = this.editingItem != item.id ? item.id : -1;
    },
    deleteItem: function(item) {
      console.log(item);
    }
  },
  data: () => ({
    editingItem: -1,
    statuses: [
      "Pending",
      "Processing",
      "On-hold",
      "Completed",
      "Cancelled",
      "Refunded",
      "Archive"
    ],
    orders: [
      {
        id: 5,
        status: "Pending",
        total: "$ 100.42",
        dateCreated: "27/01/2020",
        dateModified: "27/01/2020",
        orderItems: [
          {
            id: 1,
            name: "Potato",
            price: 54.3,
            photoUrl: "http://dummyimage.com/250x250.png/ff4444/ffffff",
            quantity: 5
          },
          {
            id: 2,
            name: "Apple",
            price: 31.2,
            photoUrl: "http://dummyimage.com/250x250.png/ff4444/ffffff",
            quantity: 1
          }
        ]
      }
    ],
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
