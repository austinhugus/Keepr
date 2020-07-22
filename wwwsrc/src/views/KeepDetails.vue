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
          <button
            type="button"
            class="btn btn-danger"
            @click="deleteKeep()"
            v-if="keep.userId == $auth.user"
          >
            Delete
          </button>
          <div>
            <div class="dropdown">
              <button
                class="btn btn-secondary dropdown-toggle"
                type="button"
                id="dropdownMenu2"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                Add To Vaults
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                <button class="dropdown-item" type="button">Action</button>
                <button class="dropdown-item" type="button">
                  Another action
                </button>
                <button class="dropdown-item" type="button">
                  Something else here
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
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
  },
  methods: {
    addVaultKeep() {
      event.stopPropagation();
      this.$store.dispatch("", { keepId: this.keepData.id });
    },
  },

  components: {},
};
</script>

<style scoped></style>
