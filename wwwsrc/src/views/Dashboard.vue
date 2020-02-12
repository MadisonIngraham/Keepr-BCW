<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col">{{ publicKeeps }}</div>
      <div class="col-3">
        <div id="form-div">
          <h4>Create Keep</h4>
          <form @submit.prevent="createKeep" class="d-flex flex-column">
            <input type="text" placeholder="Title" id="name" v-model="newKeep.name" required />
            <input
              type="text"
              placeholder="Description"
              id="description"
              v-model="newKeep.description"
            />
            <input type="text" placeholder="Image URL" id="img" v-model="newKeep.img" required />
            <button class="btn" id="create-btn" type="submit">Go</button>
            <div class="bar"></div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: ""
      }
    };
  },
  methods: {
    createKeep() {
      let keep = { ...this.newKeep };
      this.$store.dispatch("createKeep", keep);
      this.newKeep.name = "";
      this.newKeep.description = "";
      this.newKeep.img = "";
    }
  }
};
</script>

<style scoped>
#create-btn {
  background-color: #eb6864;
  color: white;
}
</style>
