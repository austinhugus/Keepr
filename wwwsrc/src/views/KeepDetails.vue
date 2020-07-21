<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-12">
        <h1 class="text-center">{{ keep.name }}</h1>
        <h3 class="text-center">{{ keep.description }}</h3>
        <div>
          <img class="card-img-right" :src="keep.img" alt="" />
        </div>
        <p>Views:{{ keep.views }} | Keeps:{{ keep.keeps }}</p>

        <button type="button" class="btn btn-success"">
          Add To Vault
        </button>
        <button
          type="button"
          class="btn btn-danger"
          @click="deleteKeep()"
          v-if="keep.userId == $auth.user.sub"
        >
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keepDetails",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {},
  
  components: {},
};
</script>

<style scoped></style>
