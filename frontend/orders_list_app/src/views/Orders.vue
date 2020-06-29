<template>
  <v-data-table
    v-model="selected"
    :headers="headers"
    :items="orders"
    :single-select="singleSelect"
    item-key="id"
    show-select
    class="elevation-1"
    show-expand
  >
    <template v-slot:top>
      <v-switch v-model="singleSelect" label="Single select" class="pa-3"></v-switch>
    </template>
    <template v-slot:expanded-item="{ item }">
      <v-row v-for="orderItem in item.orderItems" :key="orderItem.id">
        <v-col>
          <v-img :src="orderItem.photoUrl"></v-img>
        </v-col>
        <v-col>{{orderItem.name}}</v-col>
        <v-col>{{orderItem.id}}</v-col>
        <v-col>{{orderItem.price}}</v-col>
      </v-row>
    </template>
  </v-data-table>
</template>

<script>
export default {
  name: "Orders",
  components: {},
  methods: {},
  data: () => ({
    singleSelect: false,
    selected: [],
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
            photoUrl: "http://dummyimage.com/250x250.png/ff4444/ffffff"
          },
          {
            id: 2,
            name: "Apple",
            price: 31.2,
            photoUrl: "http://dummyimage.com/250x250.png/ff4444/ffffff"
          }
        ]
      }
    ],
    headers: [
      {
        text: "Order ID",
        align: "start",
        sortable: false,
        value: "id"
      },
      { text: "Created", value: "dateCreated" },
      { text: "Status", value: "status" },
      { text: "Total", value: "total" },
      { text: "Updated", value: "dateModified" }
    ]
  })
};
</script>
