<template>
  <v-data-table
    v-model="selected"
    :headers="headers"
    :items="orders"
    item-key="id"
    class="elevation-1"
    show-expand
  >
    <template v-slot:expanded-item="{ item }">
      <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
        <!-- <v-col>
          <v-img :src="orderItem.photoUrl"></v-img>
        </v-col>-->
        <v-col>{{orderItem.name}}</v-col>
        <v-col>{{orderItem.id}}</v-col>
        <v-col>{{orderItem.price}}</v-col>
        <v-col>
          <v-text-field v-model="orderItem.quantity" hide-details single-line type="number" />
          {{orderItem.quantity}}
        </v-col>
      </v-row>
    </template>

    <template v-slot:item.status="props">
      <v-edit-dialog :return-value.sync="props.item.status" large persistent>
        <div>{{ props.item.status }}</div>
        <template v-slot:input>
          <div class="mt-4 title">Update Status</div>
        </template>
        <template v-slot:input>
          <v-select :items="statuses" v-model="props.item.status" single-line dense autofocus></v-select>
        </template>
      </v-edit-dialog>
    </template>

    <template v-slot:item.actions="{ item }">
      <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
      <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
    </template>
  </v-data-table>
</template>

<script>
export default {
  name: "Orders",
  components: {},
  methods: {},
  data: () => ({
    selected: [],
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
