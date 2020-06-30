<template>
  <div class="about">
    <h1>This is a product page</h1>
    {{products.products}}
    {{statuses.statuses}}
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  computed: {
    ...mapState(["products","statuses"])
  },
  created() {
    this.$store.dispatch("products/fetchAll")
    this.$store.dispatch("statuses/fetchAll")
  },
}
</script>

<style scoped>

</style>