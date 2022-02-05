<template>
    <div class="box mb-2" :ref="message.id">
        <article class="media">
            <router-link :to="'/member/' + message.member_id" class="media-left">
                <figure class="image is-48x48">
                    <v-gravatar class="is-rounded" :email="email" />
                </figure>
            </router-link>
            <div class="media-content">
                <div>
                    <router-link class="subtitle is-5 has-text-link" :to="'/member/' + message.member_id">{{ fullname }} </router-link> -
                    <b v-if="message.created_at === message.modified_at">{{ message.created_at }}</b>
                    <b v-else>{{ message.modified_at }} (Modifié)</b> 
                    <span v-if="this.$store.state.member.id === message.member_id">
                    <router-link v-if="edit" :to="'/conversation/' + conversation + '/messsage/' + message.id" class="button mx-1 is-small is-danger is-light">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                        </svg>
                    </router-link>
                </span>
                </div>
                
                <p v-html="message.message"></p>
            </div>
        </article>
    </div>
</template>

<script>
export default {
    data(){
        return{
            fullname: "",
            email: ""
        }
    },
    props: ['message', 'edit', 'conversation'],
    created(){
        this.$api.get('members')
            .then(response => {
                response.data.map(member => {
                    if(this.message.member_id == member.id){
                        this.fullname = member.fullname
                        this.email = member.email
                    }
                    
                    if(this.member === "") this.$router.push('/members') // 404
                })
            })
    }
}
</script>

<style>

</style>