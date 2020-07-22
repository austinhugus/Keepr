<template>
  <div class="dashboard">
    <h1 class="text-center border-bottom">WELCOME TO YOUR DASHBOARD</h1>
    {{ userKeeps }}
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
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
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
