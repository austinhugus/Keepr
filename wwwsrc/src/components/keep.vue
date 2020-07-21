<template>
  <div class="keep rounded">
    <div class="border shadow m-2">
      <div class="card text-left">
        <div>
          <i
            class="far fa-times-circle float-right pointer"
            @click.prevent="deleteKeep"
          ></i>
        </div>

        <img class="card-img-top" :src="keepData.img" alt="" />
        <div class="card-body">
          <h4 class="card-title">{{ keepData.name }}</h4>
          <p class="card-text">{{ keepData.description }}</p>
          <div>
            <i
              class="far fa-star fa-2x float-right"
              @submit.prevent="addFav"
            ></i>
          </div>
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
  mounted() {
    this.$store.dispatch("getKeeps", this.$route.params.keepId);
  },
  computed: {},
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    },
  },
  components: {},
};
</script>

<style scoped>
.fa-star {
  color: rgb(213, 213, 92);
}
.fa-times-circle {
  color: red;
}
.pointer {
  cursor: pointer;
}
.card-columns {
  @include media-breakpoint-only(lg) {
    column-count: 4;
  }
  @include media-breakpoint-only(xl) {
    column-count: 5;
  }
}
</style>
