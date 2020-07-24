import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let _api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true,
});

export default new Vuex.Store({
  state: {
    keeps: [],
    myKeeps: [],
    privateKeeps: [],
    vaults: [],
    myVaults: [],
    myVaultKeeps: [],
    activeKeep: {},
    activeVault: {},
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setKeep(state, keep) {
      state.activeKeep = keep;
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps;
    },
    setNewKeep(state, keep) {
      state.myKeeps.push(keep);
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
    removeKeep(state, id) {
      state.keeps = state.keeps.filter((k) => k.id != id);
    },
    setVault(state, vault) {
      state.activeVault = vault;
    },
    setMyVault(state, vault) {
      state.myVaults = vault;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setNewVault(state, vault) {
      state.myVaults = vault;
    },
    removeVault(state, id) {
      state.vaults = state.vaults.filter((v) => v.id != id);
    },
    setActiveVault(state, vault) {
      state.activeKeep = vault;
    },
    setVaultKeeps(state, vaults) {
      state.myVaultKeeps = vaults;
    },
  },
  actions: {
    setBearer({}, bearer) {
      _api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      _api.defaults.headers.authorization = "";
    },
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await _api.get("keeps");
        commit("setKeeps", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getMyKeeps({ commit }) {
      let res = await _api.get("keeps/user");
      commit("setMyKeeps", res.data);
    },
    async getKeep({ commit }, keepId) {
      try {
        let res = await _api.get("keeps/" + keepId);
        console.log("getKeep", res.data);
        commit("setKeep", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getVaults({ commit }) {
      try {
        let res = await _api.get("vaults");
        console.log("getVault", res.data);
        commit("setVaults", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async createKeep({ commit, dispatch }, newKeep) {
      try {
        let res = await _api.post("keeps", newKeep);
        commit("setNewKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ dispatch }, id) {
      try {
        await _api.delete("keeps/" + id);
        router.push({ name: "keeps" });
        console.log("deleted");
      } catch (e) {
        console.error(e);
      }
    },
    async createVault({ commit, state }, newVault) {
      try {
        let res = await _api.post("vaults", newVault);
        let vaults = [...state.vaults, res.data];
        commit("setNewVault", vaults);
      } catch (e) {
        console.error(e);
      }
    },
    async deleteVault({ dispatch }, id) {
      try {
        await _api.delete("vaults/" + id);
        router.push({ name: "vaults" });
      } catch (e) {
        console.error(e);
      }
    },
    async addKeepToVault({ dispatch }, newVaultKeep) {
      try {
        let res = await _api.post("/vaultkeeps", newVaultKeep, newVaultKeep);
        dispatch("getMyVaultKeeps");
      } catch (err) {
        console.error(err);
      }
    },
    async removeKeepFromVault({ dispatch }, vaultKeep) {
      try {
        let res = await _api.delete("/vaultkeeps", vaultKeep);
        dispatch("setVaultKeeps", res.data);
      } catch (err) {
        console.error(err);
      }
    },
    async increasekeepKeeps({ dispatch, commit }, editKeep) {
      try {
        let res = await _api.put("keeps" + editKeep.id, editKeep);
        editKeep.keeps++;
        commit("setKeep", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async increaseKeepViews({ dispatch, commit }, editKeep) {
      try {
        let res = await _api.put("keeps" + editKeep.id, editKeep);
        editKeep.views + 1;
        commit("setKeep", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getKeepsByVaultId({ commit }, vaultId) {
      try {
        let res = await _api.get("vaults/" + vaultId + "/keeps");
        console.log("setVaultKeeps", res.data);
        commit("setVaultKeeps", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getVaultById({ commit, dispatch }, id) {
      try {
        let res = await _api.get("vaults/" + id);
        commit("setActiveVault", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getVault({ commit, dispatch }) {
      try {
        let res = await _api.get("vaults");
        commit("setMyVault", res.data);
      } catch (e) {
        console.error(e);
      }
    },
  },
});
