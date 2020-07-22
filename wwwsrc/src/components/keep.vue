<template>
  <div class="keep rounded">
    <div class="border shadow m-2 card-c">
      <div class="row">
        <div class="card text-left card-columns">
          <div>
            <i
              class="far fa-times-circle float-right pointer"
              @click="deleteKeep()"
            ></i>
            <div>
              <img
                class="card-img-top"
                :src="keepData.img"
                alt=""
                @click="
                  increaseKeepViews,
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
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    },
    increaseKeepViews() {
      editKeep.views = editKeep.view++;
      this.$store.dispatch("increaseKeeps", editKeep);
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
