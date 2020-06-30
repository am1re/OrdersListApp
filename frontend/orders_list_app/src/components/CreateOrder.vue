<template>
  <v-dialog v-model="dialog" max-width="500px">
    <template v-slot:activator="{ on, attrs }">
      <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">New Item</v-btn>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">New Item</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-select
                :items="statusesNames"
                v-model="statusName"
                label="Order Status"
                :disabled="loading"
                solo
              ></v-select>
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
  name: "CreateOrder",
  computed: {
    ...mapState({
      statusesNames: state => state.statuses.statuses.map(a => a.name)
    })
  },
  props: {
    showSnackBar: Function
  },
  data: () => ({
    dialog: false,
    loading: false,
    statusName: ""
  }),
  methods: {
    close() {
      this.dialog = false;
      this.statusName = "";
    },
    async add() {
      this.loading = true;

      let item = {
        statusId: this.$store.getters["statuses/getByName"](this.statusName)?.id
      };

      try {
        await this.$store.dispatch("orders/addItem", item);
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