<template>
  <div class="dashboard container-fluid">
    <div class="row" id="top-row">
      <div class="col">
        <keep :keepData="keep" v-for="keep in keeps" :key="keep.id" />
      </div>
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
import keep from "../components/Keep";
export default {
  name: "dashboard",
  components: {
    keep
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
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
      this.newKeep.isPrivate = false;
    }
  }
};
</script>

<style scoped>
.container-fluid {
  height: 100%;
}
#create-btn {
  background-color: #eb6864;
  color: white;
}
#top-row {
  height: 100%;
}
</style>
