<template>
  <div class="keepForm">
    <form @submit.prevent="createKeep">
      <input
        type="text"
        name="name"
        placeholder="Name..."
        v-model="newKeep.name"
        required
      />
      <input
        type="text"
        name="description"
        placeholder="Description..."
        v-model="newKeep.description"
        required
      />
      <input
        type="text"
        name="imgUrl"
        placeholder="imgUrl..."
        v-model="newKeep.imgUrl"
        required
      />
      <button type="submit" class="btn btn-primary">Post</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "keepForm",
  data() {
    return {
      newKeep: {},
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    },
  },
  components: {},
};
</script>

<style scoped></style>
