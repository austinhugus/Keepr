<template>
  <div class="vault rounded">
    <div class="border shadow m-2">
      <div class="row">
        <div class="card text-left">
          <div>
            <i
              class="far fa-times-circle float-right pointer"
              @click="deleteVault()"
            ></i>
            <div>
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
              <i
                class="far fa-star fa-2x float-right pointer"
                style="padding-bottom: 0%;"
              ></i>
            </div>
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
    vault() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vault.id);
    },
    increaseVaultViews() {
      editVault.views = editVault.view++;
      this.$store.dispatch("increaseVaults", editVault);
    },
  },
  components: {},
};
</script>

<style scoped>
.fa-star {
  color: rgb(213, 213, 92);
}

.fa-times-circle {
  color: red;
}

.pointer {
  cursor: pointer;
}
</style>
