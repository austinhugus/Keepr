<template>
  <div class="dashboard">
    <h1 class="text-center border-bottom">WELCOME {{ user }}</h1>
    <div class="row justify-content-center">
      <vaultForm />
    </div>
    <vault
      class="col-3"
      v-for="vault in vaults"
      :key="vault.id"
      :vaultData="vault"
    />
  </div>
</template>

<script>
import vaultForm from "@/components/vaultForm.vue";
import Vault from "@/components/vault.vue";
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
  },
  components: {
    vaultForm,
    Vault,
  },
};
</script>
s
<style></style>
