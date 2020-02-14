<template>
  <div class="active-keep container-fluid">
    <div class="row" id="top-row">
      <div class="col">
        <div id="outside-edge">
          <div class="row">
            <div class="col">
              <img v-bind:src="keep.img" />
            </div>
          </div>
          <div class="row flex-column">
            <div class="col">
              <h2>{{keep.name}}</h2>
            </div>
            <div class="col">
              <h4>{{keep.description}}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "activeKeep",
  props: ["keepId"],
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>

<style scoped>
img {
  height: 60vh;
}
.container-fluid,
#top-row {
  height: 100%;
}
</style>