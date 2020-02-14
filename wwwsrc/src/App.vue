<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    await this.$auth.getUserData();
    this.$store.dispatch("setBearer", this.$auth.bearer);
    this.$store.dispatch("getUserVaults");
  },
  components: {
    Navbar
  }
};
</script>

<style>
#app {
  height: 100%;
  margin: 0;
}
</style>
