<template>
<div class="keep">
  <div class="card border-primary mb-3" style="max-width: 20rem;">
    <div class="card-header text-center">
      <img v-bind:src="keepData.img" />
    </div>
    <body class="card-body">
      <h4>{{ keepData.name }}</h4>
      <p>{{keepData.description}}</p>
    </body>
  </div>
</div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"]
};
</script>

<style scoped>
.border-primary {
  border-color: #eb6864 !important;
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
</style>