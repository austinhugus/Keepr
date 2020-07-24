<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <h1 class="text-center text-white">{{ keep.name }}</h1>
        <h3 class="text-center text-white">{{ keep.description }}</h3>
        <div>
          <img class="card-img-right col " :src="keep.img" alt="" />
        </div>
        <h3 class="text-white">
          Views:{{ keep.views }} | Keeps:{{ keep.keeps }}
        </h3>

        <!-- <div class="dropdown">
          <button onclick="addVaultKeep()" class="dropbtn">Dropdown</button>
          <div id="myDropdown" class="dropdown-content">
            <s href="#vault">{{ userId.vault }}/>
          </div>
        </div> -->
        <div>
          <div class="dropdown">
            <button
              class="btn btn-outline-success dropdown-toggle"
              type="button"
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >
              Add To Vault
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <a
                class="dropdown-item"
                v-for="vault in vaults"
                :key="vault.id"
                :vaultData="vault"
                @click="addKeepToVault(vault.id)"
                href="#"
                >{{ vault.name }}</a
              >
            </div>
          </div>
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
  name: "keepDetails",
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
      return this.$store.state.myVaults;
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
