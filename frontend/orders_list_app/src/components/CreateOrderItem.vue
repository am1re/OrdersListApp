<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template v-slot:activator="{ on, attrs }">
      <v-btn small fab dark color="indigo" style="margin-bottom: 20px" v-on="on" v-bind="attrs">
        <v-icon dark>mdi-plus</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">New Order Item</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="6">
              <v-text-field
                v-model="currentItem.productId"
                label="Product Id"
                type="number"
                hint="Тут должен быть выпадающий список :/, id[1..26]"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="6">
              <v-text-field
                v-model="currentItem.quantity"
                hide-details
                single-line
                type="number"
                label="Quantity"
              />
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-progress-circular v-if="loading" indeterminate color="primary"></v-progress-circular>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="close" :disabled="loading">Cancel</v-btn>
        <v-btn color="blue darken-1" text @click="add" :disabled="loading">Create</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "CreateOrderItem",
  computed: {
    ...mapState({
      statusesNames: state => state.statuses.statuses.map(a => a.name)
    })
  },
  props: {
    showSnackBar: Function,
    item: Object
  },
  data: () => ({
    dialog: false,
    loading: false,
    currentItem: {
      quantity: "",
      productId: ""
    }
  }),
  methods: {
    close() {
      this.dialog = false;
      this.statusName = "";
    },
    async add() {
      this.loading = true;

      this.currentItem.orderId = this.item.id;
      try {
        await this.$store.dispatch("orders/addOrderItem", this.currentItem);
      } catch (err) {
        this.showSnackBar(err);
      }

      this.loading = false;
      this.close();
    }
  }
};
</script>

<style scoped>
</style>