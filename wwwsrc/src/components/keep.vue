<template>
  <div class="keep rounded">
    <div class="border shadow m-2">
      <div class="card text-left">
        <img class="card-img-top" :src="keepData.img" alt="" />
        <div class="card-body">
          <h4 class="card-title">{{ keepData.name }}</h4>
          <p class="card-text">{{ keepData.description }}</p>
          <button type="button" @submit.prevent="addFav">
            <i class="far fa-star fa-2x float-right"></i>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
};
</script>

<style scoped>
.fa-star {
  color: rgb(213, 213, 92);
}
</style>
