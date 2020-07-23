<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-6">
        <h1 class="text-center">{{ keep.name }}</h1>
        <h3 class="text-center">{{ keep.description }}</h3>
        <div>
          <img class="card-img-right col " :src="keep.img" alt="" />
        </div>
        <h3>Views:{{ keep.views }} | Keeps:{{ keep.keeps }}</h3>

        <!-- <div class="dropdown">
          <button onclick="addVaultKeep()" class="dropbtn">Dropdown</button>
          <div id="myDropdown" class="dropdown-content">
            <s href="#vault">{{ userId.vault }}/>
          </div>
        </div> -->
        <div>
          <div class="dropdown">
            <button
              class="btn btn-secondary dropdown-toggle"
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
                href="#"
                v-for="vault in vaults"
                :key="vault.id"
                :vaultData="vault"
                >{{ vault.name }}</a
              >
            </div>
          </div>
          <button
            type="button"
            class="btn btn-danger m-2"
            @click="deleteKeep()"
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
export default {
  name: "keepDetails",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
    vault() {
      return this.$store.state.vaults;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    addVaultKeep() {
      event.stopPropagation();
      this.$store.dispatch("", { keepId: this.keepData.id });
    },
  },

  components: {
    Vault,
  },
};
</script>

<style scoped></style>
