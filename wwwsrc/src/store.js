import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 5000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    activeUser: {},
    keeps: [],
    vaults: [],
    activeVault: {},
    activeKeep: {}
  },
  mutations: {
    setUser(state, user) {
      state.activeUser = user;
    },
    setKeeps(state, data) {
      state.keeps = data;
    },
    addKeep(state, data) {
      state.keeps.unshift(data);
    },
    addVault(state, data) {
      state.vaults.unshift(data);
    },
    setVaults(state, data) {
      state.vaults = data;
    },
    setActiveVault(state, vault) {
      state.activeVault = vault;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    setUser({ commit, dispatch }, user) {
      commit("setUser", user);
    },
    async getAllKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createKeep({ commit, dispatch }, data) {
      try {
        let res = await api.post("keeps", data);
        commit("addKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit, dispatch }, id) {
      try {
        await api.delete("keeps/" + id);
        dispatch("getAllKeeps");
      } catch (error) {
        console.error(error);
      }
    },
    async createVault({ commit, dispatch }, data) {
      try {
        let res = await api.post("vaults", data);
        commit("addVault", res.data);
        router.push({ name: "vaults" });
      } catch (error) {
        console.error(error);
      }
    },
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        console.log("from store", res);
        commit("setVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({ commit, dispatch }, id) {
      try {
        await api.delete("vaults/" + id);
        dispatch("getUserVaults");
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultById({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaults/" + id);
        commit("setActiveVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeepById({ commit, dispatch }, id) {
      try {
        let res = await api.get("keeps/" + id);
        commit("setActiveKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async increaseViews({ commit, dispatch }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId);
        console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async moveToVault({ commit, dispatch }, keepData) {
      let res = await api.post("vaultkeeps", keepData);
    }
  }
});
