<template>
<div class="vault">
  <div id="div-outline">
    <body class="card-body">
      <router-link id="router-link" :to="{name: 'vault', params: { vaultId: vaultData.id}}">
        <div class="row flex-column">
          <div class="col">
            <h4>{{ vaultData.name }}</h4>
          </div>
          <div class="col">
            <p>{{vaultData.description}}</p>
          </div>
        </div>
      </router-link>
      <div class="row justify-content-end">
        <div class="col-4">
          <a
            class="nav-link dropdown-toggle"
            data-toggle="dropdown"
            role="button"
            aria-haspopup="true"
            aria-expanded="false"
          ></a>
          <div class="dropdown-menu" style>
            <a class="dropdown-item" href="#" @click="deleteVault(vaultData)">Delete</a>
          </div>
        </div>
      </div>
    </body>
  </div>
</div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultData"],
  methods: {
    deleteVault(vaultData) {
      let vaultId = vaultData.id;
      if (this.$auth.user.sub != vaultData.userId) {
        throw new Error("You can't delete what's not yours!");
      }
      this.$store.dispatch("deleteVault", vaultId);
    }
  }
};
</script>

<style scoped>
#div-outline {
  border: 1px solid #eb6864;
}
.card-header {
  background-color: #eb6864;
}
.vault {
  margin: 5%;
}
.card-body {
  padding-bottom: 0rem;
}
#router-link {
  color: black;
}
</style>