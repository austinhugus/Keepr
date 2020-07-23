<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <h1 class="text-center">{{ vault.name }}</h1>
        <h3 class="text-center">{{ vault.description }}</h3>
        <div>
          <img class="card-img-right col " :src="vault.img" alt="" />
          <vault
            class="col-3"
            v-for="vault in vaults"
            :key="vault.id"
            :vaultData="vault"
          />
          <button
            type="button"
            class="btn btn-danger m-2"
            @click="deleteKeep(keepId)"
          >
            Remove
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "@/components/vault.vue";
import Keep from "@/components/keep.vue";
export default {
  name: "vaultDetails",
  data() {
    return {
      vaultId,
    };
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.myVaultKeeps;
    },
    vaults() {
      return this.$store.state.myVaultKeeps;
    },
  },
  methods: {
    getKeepsByVaultId() {
      this.$store.dispatch("getKeepsByVaultId", { vaultId: this.vaultData.id });
    },
  },

  components: {
    Vault,
    Keep,
  },
};
</script>

<style scoped></style>
