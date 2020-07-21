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
    privateKeeps: [],
    myKeeps: [],
    myVaultKeeps: [],
    activeKeep: {},
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
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
    removeKeep(state, id) {
      state.keeps = state.keeps.filter((k) => k.id != id);
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
        let res = await _api.get("Keeps");
        commit("setKeeps", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async getMyKeeps({ commit }) {
      let res = await _api.get("/keeps/user");
      commit("setMyKeeps", res.data);
    },
    async getKeep({ commit }, keepId) {
      try {
        let res = await _api.get("keeps/" + keepId);
        console.log("getKeep:", res.data);
        commit("setKeep", res.data);
      } catch (e) {
        console.error(e);
      }
    },
    async createKeep({ commit, dispatch }, newKeep) {
      try {
        let res = await _api.post("keeps", newKeep);
        commit("addKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ dispatch, commit }, keepId) {
      try {
        await _api.delete("keeps/" + keepId);
        dispatch("getKeeps");
        commit("removeKeep", keepId);
        commit("setActiveKeep");
      } catch (e) {
        console.error(e);
      }
    },
    async addVaultKeep({ dispatch }) {
      try {
        let res = await _api.post("/vaults" + "id" + "/keeps");
        dispatch("getMyVaultKeeps");
      } catch (err) {
        console.error(err);
      }
    },
    async removeVaultKeep({ dispatch }) {
      try {
        let res = await _api.delete("/vaults" + "id" + "/keeps");
        dispatch("getMyVaultKeeps");
      } catch (err) {
        console.error(err);
      }
    },
    setActiveKeep({ commit }, keep) {
      commit("setActiveKeep", keep);
    },
  },
});
