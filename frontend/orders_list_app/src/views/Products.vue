<template>
  <div class="about">
    <h1>This is a product page</h1>
    {{products.products}}
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  computed: {
    ...mapState(["products"])
  },
  created() {
    this.$store.dispatch("products/fetchAll")
  },
}
</script>

<style scoped>

</style>