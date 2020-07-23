<template>
  <div class="vault rounded">
    <div class="border shadow m-2">
      <div class="row">
        <div class="card" style="width: 18rem;">
          <img
            class="card-img-top"
            :src="vaultData.img"
            alt=""
            @click="
              $router.push({
                name: 'vaultDetails',
                params: { vaultId: vaultData.id },
              })
            "
          />
          <div class="card-body">
            <h5 class="card-title">{{ vaults.name }}</h5>
            <p class="card-text">
              {{ vaults.description }}
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultData"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults", this.$route.params.vaultId);
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    },
    // increaseVaultViews() {
    //   editVault.views = editVault.view++;
    //   this.$store.dispatch("increaseVaults", editVault);
    // },
  },
  components: {},
};
</script>

<style scoped>
.fa-times-circle {
  color: red;
}

.pointer {
  cursor: pointer;
}
</style>
