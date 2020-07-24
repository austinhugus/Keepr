<template>
  <div class="Vault rounded">
    <div class="border shadow m-2">
      <div class="row">
        <div class="card text-left">
          <div>
            <i
              class="far fa-times-circle float-right pointer"
              @click="deleteVault(vaultData.id)"
            ></i>
            <div>
              <button
                @click="
                  $router.push({
                    name: 'vaultDetails',
                    params: { vaultId: vaultData.id },
                  })
                "
              >
                Enter Vault
              </button>
              <img class="card-img-top" :src="vaultData.img" alt="" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyVault", this.$route.params.vaultId);
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
