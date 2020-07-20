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
    myFavKeeps: [],
    activeKeep: [],
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setKeep(state, keeps) {
      state.keeps.push(keeps);
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps;
    },
    setMyFavKeeps(state, keep) {
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
        alert(JSON.stringify(e));
      }
    },
    async getMyKeeps({ commit }) {
      let res = await _api.get("/keeps/user");
      commit("setMyKeeps", res.data);
    },

    async createKeep({ commit, dispatch }, newKeep) {
      try {
        let res = await _api.post("keeps", newKeep);
        commit("addKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ dispatch }, id) {
      try {
        await _api.delete("keeps/" + id);
        dispatch("getKeeps");
      } catch (e) {
        console.error(e);
      }
    },
    async addFav({ dispatch }, fav) {
      try {
        let res = await _api.post("/keepFavorites", fav);
        dispatch("getMyFavKeeps");
      } catch (err) {
        console.error(err);
      }
    },
    async removeFav({ dispatch }, favId) {
      try {
        let res = await _api.delete("/keepFavorites/" + favId);
        dispatch("getMyFavKeeps");
      } catch (err) {
        console.error(err);
      }
    },
  },
});
