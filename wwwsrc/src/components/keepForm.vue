<template>
  <div class="keep-form">
    <form @submit.prevent="createKeep">
      <div class="form-group">
        <input
          type="text"
          name="name"
          placeholder="Name..."
          v-model="newKeep.name"
          required
        />
      </div class="form-group">
      <div class="form-group">
        <input
          type="text"
          name="description"
          placeholder="Description..."
          v-model="newKeep.description"
          required
        />
      </div class="form-group">
      <div class="form-group">
        <input
          type="text"
          name="Img"
          placeholder="Img..."
          v-model="newKeep.Img"
          required
          />
      </div>
          <div class="form-group">
            <div class="form-check">
              <input type="checkbox" class="form-check-input" id="exampleCheck1" v-model="newKeep.isPrivate">
              <label class="form-check-label" for="exampleCheck1">Check to make Private</label>
            </div class="form-group">
            <button type="submit" class="btn btn-primary">Post</button>
          </div>
          
          </form>
  </div>
</template>

<script>
export default {
  name: "keepForm",
  data() {
    return {
      newKeep: {
        isPrivate: false
      },
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
       user() {
      return this.$store.state.user;
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
