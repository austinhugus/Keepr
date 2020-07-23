<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <vaultForm />
    </div>
    <div class="row ml-5">
      <vault
        class="col-3"
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
<style></style>
