<template>
  <div class="keep rounded">
    <div class="border shadow m-2">
      <div class="card text-left">
        <div>
          <i
            class="far fa-times-circle float-right pointer"
            @click="deleteKeep(keepId)"
          ></i>
          <div>
            <img
              class="card-img-top"
              :src="keepData.img"
              alt=""
              @click="
                $router.push({
                  name: 'keepDetails',
                  params: { keepId: keepData.id },
                })
              "
            />
            <i
              class="far fa-star fa-2x float-right pointer"
              style="padding-bottom: 0%;"
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
      this.$store.dispatch("deleteKeep", this.keepId);
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
/* .card-columns {
  @include media-breakpoint-only(s) {
    column-count: 5;
  }
  /* @include media-breakpoint-only(xl) {
    column-count: 5;
  }
  @include media-breakpoint-only(m) {
    column-count: 5;
  }
  @include media-breakpoint-only(s) {
    /* column-count: 5; */
</style>
