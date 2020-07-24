<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <vaultForm />
    </div>
    <h1 class="border-bottom text-white text-center">My Keeps</h1>
    <div class="col">
      <div class="row">
        <keep
          class=" ml-5"
          v-for="keep in keeps"
          :key="keep.id"
          :keepData="keep"
        />
      </div>
      <h1 class="border-bottom text-white text-center">My Vaults</h1>
    </div>
    <div class="col-12">
      <vault
        class="ml-5"
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
import Keep from "@/components/keep.vue";
export default {
  mounted() {
    this.$store.dispatch("getMyVaults");
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    vaults() {
      return this.$store.state.myVaults;
    },
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.myKeeps;
    },
  },
  components: {
    vaultForm,
    Vault,
    Keep,
  },
};
</script>
<style></style>
