import Vue from "vue";
import Vuex from "vuex";
import VuexPersistence from "vuex-persist";

Vue.use(Vuex);

const vuexLocal = new VuexPersistence({
    storage: window.localStorage,
});

export default new Vuex.Store({
    state: {
        token: "",
        member: false,
    },
    mutations: {
        setToken(state, token) {
            state.token = token;
        },
        setMember(state, member) {
            state.member = member;
        },
    },
    actions: {},
    modules: {},
    plugins: [vuexLocal.plugin],
});
