<template>
  <div class="my-keep">
    <div class="card text-left">
      <img class="card-img-top" src="holder.js/100px180/" alt="" />
      <div class="card-body">
        <h4 class="card-title">Title</h4>
        <p class="card-text">Body</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MyKeep",
  props: ["mykeep"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    getMyKeeps() {
      this.$store.dispatch("getMyKeeps");
    },
  },
  components: {},
};
</script>

<style scoped></style>
