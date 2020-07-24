<template>
  <div class="VaultDetails container-fluid">
    <div class="row">
      <div class="col-6">
        <h1 class="text-center">{{ vault.name }}</h1>
        <h3 class="text-center">{{ vault.description }}</h3>
        <div>
          <keep
            class="col-6"
            v-for="keep in keeps"
            :key="keep.id"
            :keepData="keep"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "@/components/vault.vue";
import Keep from "@/components/keep.vue";
export default {
  name: "VaultDetails",
  props: ["vaultDetails"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    keeps() {
      return this.$store.state.myVaultKeeps;
    },
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    removeKeepFromVault(keepId) {
      this.$store.dispatch("setVaultKeeps", keepId);
    },
  },

  components: {
    Vault,
    Keep,
  },
};
</script>

<style scoped></style>
