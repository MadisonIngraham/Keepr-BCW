<template>
  <div class="vaults container-fluid">
    <div class="row">
      <div class="col d-flex vault-col">
        <vault :vaultData="vault" v-for="vault in vaults" :key="vault.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "../components/Vault";
export default {
  name: "vaults",
  components: {
    Vault
  },
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  }
};
</script>

<style scoped>
.vault-col {
  flex-wrap: wrap;
}
</style>