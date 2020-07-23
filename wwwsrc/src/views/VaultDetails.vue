<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <h1 class="text-center">{{ vault.name }}</h1>
        <h3 class="text-center">{{ vault.description }}</h3>
        <div>
          <img class="card-img-right col " :src="vault.img" alt="" />
          <button
            type="button"
            class="btn btn-danger m-2"
            @click="deleteKeep(keepId)"
          >
            Delete
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
      newVaultKeep: {},
    };
  },
  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
    vault() {
      return this.$store.state.activeVault;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    addKeepToVault(vaultId) {
      this.$store.dispatch(
        "addKeepToVault",
        (this.newVaultKeep = {
          keepId: this.keep.id,
          vaultId: vaultId,
        })
      );
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    },
  },

  components: {
    Vault,
    Keep,
  },
};
</script>

<style scoped></style>
