<template>
    <div>
        <h1 class="title has-text-centered">
            Liste des membres
        </h1>
        <div class="columns is-multiline is-mobile">
            <div class="column is-half-tablet is-one-third-desktop is-full-mobile" v-for="member in members" :key="member.id">
                <div class="card has-background-primary-light">
                    <div class="card-content">
                        <router-link class="media" :to="'/member/' + member.id">
                            <div class="media-left">
                                <figure class="image is-48x48">
                                    <v-gravatar class="is-rounded" :email="member.email" />
                                </figure>
                            </div>
                            <div class="media-content">
                                <p class="title is-4 has-text-primary">{{ member.fullname }}</p>
                                <p class="subtitle is-6">Membre depuis: {{ member.created_at }}</p>
                            </div>
                        </router-link>
                        <div class="content">
                            <b>Email: </b>{{ member.email }}
                        </div>

                        <!-- supprimer un membre depuis cette page -->
                        <!--
                            <div class="content">
                                <button @click="remove(member.id)" class="button is-danger">Supprimer le membre</button>
                            </div>
                        -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            members:[]
        }
    },
    created(){
        this.$isLoading(true)
        this.$api.get('members')
            .then(response => {
                this.members = response.data
            })
            .finally(() => {
                this.$isLoading(false)
            })
    },
    methods:{
        /*
        // supprimer un membre depuis cette page
        remove(id){
            if(this.$store.state.member.id == id) {
                alert("tu ne peux pas supprimer ton compte")
            } else {
                this.$api.delete('members/' + id)
                .then(response => {
                    alert(response.data.message)

                    let index = this.members.map(member => {
                        return member.Id;
                    }).indexOf(id);

                    this.members.splice(index, 1);
                })
                .catch(err => alert(err.response.data.message))
            }
        }
        */
    }
}
</script>

<style>

</style>