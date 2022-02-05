<template>
    <div>
        <div class="media mb-4">
            <div class="media-left">
                <figure class="image is-64x64">
                    <v-gravatar class="is-rounded" :email="member.email" />
                </figure>
            </div>
            <div class="media-content">
                <p class="title mt-2">{{ member.fullname }}</p>
            </div>
        </div>
        
        
        <div class="card mb-5 has-background-primary-light">
            <div class="card-content">
                <h3 class="subtitle is-6">
                    <b>Email: </b> {{ member.email }}
                </h3>
                <h3 class="subtitle is-6">
                    <b>Date de creation: </b> {{ member.created_at }}
                </h3>
                <div class="field" v-if="member.id !== this.$store.state.member.id">
                    <button @click="remove()" class="button is-danger">Supprimer le membre</button>
                </div>
            </div>
        </div>

        <div v-for="msg in messages" :key="msg.id">
            <Message :message="msg" :edit="true" :conversation="msg.conversation.id"/>
        </div>
    </div>
</template>

<script>import Message from '../../components/memberMessageCard.vue'
export default {
    components:{
        Message
    },
    data(){
        return{
            member: "",
            messages: []
        }
    },
    created(){
        this.$isLoading(true)
        this.$api.get('members')
        .then(response => {
            response.data.forEach(member => {
                if(member.id == this.$route.params.id){
                    this.member = member
                    this.$api.get("channels").then((response) => {
                        response.data.forEach(element => {
                            this.$api.get('channels/' + element.id + '/posts')
                            .then(response => {
                                response.data.forEach(m => {
                                    if(m.member_id == member.id){
                                        let msg = m;
                                        msg.conversation = element;
                                        this.messages.push(msg)
                                    }
                                })
                            }) 
                        });
                        this.messages = this.messages.reverse().slice(0,9)
                    })
                }
            })
            if(this.member === "") this.$router.push('/members') // 404
        })
        .finally(() => {
            this.$isLoading(false)
        })
    },
    methods:{
        remove(){
            if(this.$store.state.member.id == this.member.id) {
                alert("tu ne peux pas supprimer ton compte")
            } else {
                this.$isLoading(true)
                this.$api.delete('members/' + this.member.id)
                .then(response => {
                    alert(response.data.message)

                    this.$router.push('/members')
                })
                .catch(err => alert(err.response.data.message))
                .finally(() => {
                    this.$isLoading(false)
                })
            }
        }
    }
}
</script>

<style>

</style>