<template>
  <div class="vault"></div>
</template>

<script>
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  }
};
</script>

<style scoped>
</style>