import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";
import loading from 'vuejs-loading-screen'
import Gravatar from 'vue-gravatar';
import VueLetterAvatar from 'vue-letter-avatar';
 

Vue.use(VueLetterAvatar);
Vue.component('v-gravatar', Gravatar);

Vue.use(loading)

Vue.prototype.$api = axios.create({
    baseURL: "https://localhost:7033/",
    params: {},
    headers: { ApiKey: "CoopSecretKey" },
});

Vue.prototype.$api.interceptors.request.use(function (config) {
    if (store.state.token) {
        config.params.token = store.state.token;
    }
    return config;
});

Vue.config.productionTip = false;

new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount("#app");
