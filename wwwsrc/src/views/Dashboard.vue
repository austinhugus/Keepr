<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <vaultForm />
    </div>
    <h1 class="border-bottom text-white text-center">My Keeps</h1>
    <keep
      class="col-4 ml-5"
      v-for="keep in keeps"
      :key="keep.id"
      :keepData="keep"
    />
    <h1 class="border-bottom text-white text-center">My Vaults</h1>
    <div class="row">
      <vault
        class="col-4 ml-5"
        v-for="vault in vaults"
        :key="vault.id"
        :vaultData="vault"
      />
    </div>
  </div>
</template>

<script>
import vaultForm from "@/components/vaultForm.vue";
import Vault from "@/components/vault.vue";
import MyKeep from "@/components/myKeeps.vue";
export default {
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.statea.myKeeps;
    },
  },
  components: {
    vaultForm,
    Vault,
    MyKeep,
  },
};
</script>
<style></style>
