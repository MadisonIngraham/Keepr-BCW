<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col d-flex keep-col">
        <keep :keepData="keep" v-for="keep in keeps" :key="keep.id" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/Keep";
export default {
  name: "home",
  components: {
    keep
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style scoped>
.keep-col {
  flex-wrap: wrap;
}
</style> 
