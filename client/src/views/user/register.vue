<template>
    <div class="m-5 box">
        <figure class="has-text-centered">
            <img src="@/assets/images/user.jpg" width="100" alt="img">
        </figure>
        <h2 class="title is-2 has-text-centered">Créer un compte</h2>
        <form class="m-3" @submit.prevent="validation()">
            <div class="field">
                <input class="input" type="text" required v-model="fullname">
            </div>
            <div class="field">
                <input class="input" type="email" required v-model="email">
            </div>
            <div class="field">
                <input class="input" type="password" required v-model="password">
            </div>
            <div class="field">
                <button class="button is-success">Créer compte</button>
            </div>
        </form>
        <div>
            <router-link class="m-3" to="login">Login</router-link>
        </div>
    </div>
</template>

<script>
export default {
    data (){  
        return{
            email :"user1@test.com",
            password :"password",
            fullname :"John Doe",
        }
    },
    methods:{
        validation() {
            this.$isLoading(true)
            this.$api.post('members',{
                email :this.email,
                password :this.password,
                fullname :this.fullname
            })
            .then(() => {
                alert('votre compte est crée vous pouvez vous connecter')
                // Router Redirect
                this.$router.push('/login')
            })
            .catch(err => console.log(err.response.data.message))
            .finally(() => {
                this.$isLoading(false)
            })
        }
    }
}
</script>

<style>

</style>