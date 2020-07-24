<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col text-center">
        <h1 class="text-white">Welcome To KeepR</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <keepForm />
    </div>
    <div class="col-12">
      <div class="ml-5">
        <keep
          class="col-6"
          v-for="keep in keeps"
          :key="keep.id"
          :keepData="keep"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/keep";
import keepForm from "@/components/keepForm";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    Keep,
    keepForm,
  },
};
</script>

<style></style>
