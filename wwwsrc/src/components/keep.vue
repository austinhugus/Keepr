<template>
  <div class="keep rounded">
    <div class="border shadow m-2">
      <div class="row">
        <div class="card text-left">
          <div>
            <i
              class="far fa-times-circle float-right pointer"
              @click="deleteKeep(keepData.id)"
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
            </div>
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
  computed: {
    keep() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    },
    // increaseKeepViews() {
    //   editKeep.views = editKeep.view + 1;
    //   this.$store.dispatch("increaseKeepViews", keepId);
    // },
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
@media (min-width: 576px) {
  .card-columns {
    column-count: 2;
  }
}

@media (min-width: 768px) {
  .card-columns {
    column-count: 3;
  }
}

@media (min-width: 992px) {
  .card-columns {
    column-count: 4;
  }
}

@media (min-width: 1200px) {
  .card-columns {
    column-count: 5;
  }
}
</style>
