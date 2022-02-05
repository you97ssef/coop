<template>
    <div id="app">
        <Navbar :fullname="this.$store.state.member.fullname" @deconnect="deconnect" />
        <section class="section">
            <div class="container">
                <router-view />
            </div>
        </section>
    </div>
</template>

<style></style>

<script>
    import Navbar from "./components/navbar.vue";
    
    export default {
        components: {
            Navbar
        },
        mounted() {
            if (!this.$store.state.member) {
                this.$router.push("/login");
            }
            this.$isLoading(true)
            this.$api.get("members/" + this.$store.state.member.id + "/signedin")
            .then()
            .catch(() => {
                this.$store.commit("setToken", null);
                this.$store.commit("setMember", false);
                this.$router.push("/login");
            })
            .finally(() => {
                this.$isLoading(false)
            })
        },
        methods: {
            deconnect() {
                this.$isLoading(true)
                this.$api.delete("members/signout")
                .then(() => {
                    this.$store.commit("setToken", null);
                    this.$store.commit("setMember", false);
                    this.$router.push("/login");
                })
                .catch((err) => console.log(err.response.data.message))
                .finally(() => {
                    this.$isLoading(false)
                })
            },
        },
    };
</script>
