<template>
<div class="keep">
  <div id="div-outline">
    <div class="row text-center">
      <div class="col">
        <img v-bind:src="keepData.img" />
      </div>
    </div>
    <body class="card-body">
      <div class="row flex-column">
        <div class="col">
          <h4>{{ keepData.name }}</h4>
        </div>
        <div class="col">
          <p>{{keepData.description}}</p>
        </div>
      </div>
      <div class="row">
        <div class="col text-center">
          <button type="button" class="button">View</button>
          <p>{{keepData.views}}</p>
        </div>
        <div class="col text-center">
          <button type="button" class="button">Keep</button>
          <p>{{keepData.keeps}}</p>
        </div>
        <div class="col text-center">
          <button type="button" class="button">Share</button>
          <p>{{keepData.shares}}</p>
        </div>
      </div>
      <div class="row justify-content-end">
        <div class="col-3">
          <a
            class="nav-link dropdown-toggle"
            data-toggle="dropdown"
            role="button"
            aria-haspopup="true"
            aria-expanded="false"
          ></a>
          <div class="dropdown-menu" style>
            <a class="dropdown-item" href="#" @click="deleteKeep(keepData)">Delete</a>
          </div>
        </div>
      </div>
    </body>
  </div>
</div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  methods: {
    deleteKeep(keepData) {
      let keepId = keepData.id;
      if (this.$auth.user.sub != keepData.userId) {
        throw new Error("You can't delete what's not yours!");
      }
      this.$store.dispatch("deleteKeep", keepId);
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
.keep {
  margin: 5%;
}
img {
  height: 20vh;
}
.button {
  background-color: #eb6864;
  color: white;
  border-color: #eb6864;
  border-radius: 10%;
  margin-bottom: 5px;
}
.card-body {
  padding-bottom: 0rem;
}
</style>