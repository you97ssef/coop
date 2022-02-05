<template>
    <div>
        <figure class="has-text-centered">
            <vue-letter-avatar class="" v-if="conversation.label" :name='conversation.label' />
        </figure>
        <h1 class="title has-text-centered">{{ conversation.label }}</h1>
        <nav class="level">
            <div class="level-left">
                <div class="level-item">
                    <h5 class="title is-5 has-text-info">{{ conversation.topic }}</h5> 
                </div>
            </div>
            <div class="level-right">
                <div class="level-item">
                    <button @click="toggleEdit()" class="button is-warning">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                        </svg>
                    </button>
                </div>
            </div>
        </nav>
        <div class="has-text-centered" v-if="edit">
            <button @click="remove()" class="m-1 button is-danger">Supprimer Conversation</button>
            <router-link :to="'/update-conversation/' + conversation.id" class="m-1 button is-warning">Modifier Conversation</router-link>
        </div>
        <div class="mt-5" v-for="msg in messages" :key="msg.id">
            <Message :message="msg" :edit="edit" :conversation="conversation.id"/>
        </div>
        <form @submit.prevent="send()" class="box mt-5">
            <div class="field">
                <label class="label">Message</label>
                <textarea class="textarea is-link" v-model="message" rows="2" placeholder="Hello world"></textarea>
            </div>
            <div class="field">
                <button type="submit" class="button is-link">Envoyer message</button>
            </div>    
        </form>
    </div>
</template>

<script>
import Message from '../../components/messageCard.vue'
export default {
    components:{
        Message
    },
    data() {
        return {
            conversation:{},
            messages:{},
            edit: false,
            message: "Hello world",
            member_id: ""
        }
    },
    created() {
        this.member_id = this.$store.state.member.id
        this.$isLoading(true) // show loading screen
        this.$api.get('channels/' + this.$route.params.id)
            .then(response => {
                if(response.data === null) this.$router.push('/') // 404
                this.conversation = response.data
                
                this.$api.get('channels/' + this.$route.params.id + '/posts')
                .then(response => {
                    this.messages = response.data.reverse()
                })
            }).finally(() => {
                this.$isLoading(false) // hide loading screen
            })
    },
    methods:{
        remove(){
            this.$api.delete('channels/' + this.conversation.id)
            .then(() => {
                this.$router.push('/')
            })
            .catch(err => alert(err.response.data.message))
        },
        toggleEdit(){ 
            this.edit = !this.edit 
        },
        send(){
            this.$api.post('channels/' + this.$route.params.id + '/posts',{
                member_id: this.member_id,
                message: this.message
            }).then(response => {
                this.messages.push(response.data)
                this.message = ""
            })
        }
    }
}
</script>

<style>

</style>