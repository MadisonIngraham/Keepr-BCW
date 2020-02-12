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
    keeps: []
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
    }
  }
});
