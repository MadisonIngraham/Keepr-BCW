<template>
  <div class="vault">{{vault.title}}</div>
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