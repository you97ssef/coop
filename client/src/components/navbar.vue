<template>
    <nav class="navbar" role="navigation" v-on:click="showNav = !showNav" v-bind:class="{ 'is-active' : showNav }" aria-label="main navigation">
        <div class="navbar-brand">
            <router-link to="/" class="navbar-item title m-0">
                COOP
            </router-link>
            <a role="button" class="navbar-burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample">
                <span aria-hidden="true"></span>
                <span aria-hidden="true"></span>
                <span aria-hidden="true"></span>
            </a>
        </div>

        <div id="navbarBasicExample" class="navbar-menu" v-bind:class="{ 'is-active' : showNav }" v-if="fullname">
            <div class="navbar-start">
                <router-link class="navbar-item" to="/">Conversations</router-link>
                <router-link to="/new-conversation" class="navbar-item">Nouvelle conversation</router-link>
                <router-link class="navbar-item" to="/members">Membres</router-link>
            </div>
            <div class="navbar-end">
                <div class="navbar-item">
                    <p>
                        Bonjour <b>{{ fullname }}</b>
                    </p>
                </div>
                <form class="navbar-item" @submit.prevent="deconnect()">
                    <button class="button is-danger">Se deconnecter</button>
                </form>
            </div>
        </div>
        <div id="navbarBasicExample" class="navbar-menu" v-bind:class="{ 'is-active' : showNav }" v-else>
            <div class="navbar-end">
                <div class="navbar-item">
                    <div class="buttons">
                        <router-link class="button is-primary" to="/register">Créer Compte</router-link>
                        <router-link class="button is-light" to="/login">Login</router-link>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        props: ['fullname'],
        data() {
            return {
                showNav: false
            }
        },
        methods: {
            deconnect() {
                this.$emit('deconnect');
            }
        }
    }
</script>

<style>

</style>