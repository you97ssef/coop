<template>
    <div>
        <h1 class="title has-text-centered">
            Modification de message
        </h1>
        <div class="box">
            <h6 v-if="message.created_at === message.modified_at" class="title is-6">
                <b>Date de message :</b> {{ message.created_at }}
            </h6>
            <h6 v-else class="title is-6">
                <b>Date de message :</b> {{ message.modified_at }} - (modifié)
            </h6>
            <h6 class="title is-6">
                <b>Message :</b> {{ message.message }}
            </h6>
            <div class="field">
                <label class="label">Message</label>
                <textarea class="textarea" v-model="message_text" rows="2" placeholder="Hello world"></textarea>
            </div>
            <div class="field">
                <div class="buttons">
                    <button @click="remove()" class="button is-danger">Supprimer Message</button>
                    <button @click="update()" class="button is-warning">Modifier Message</button>
                </div>
            </div>    
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            message: {},
            message_text : ""
        }
    },
    created() {
        this.$isLoading(true)
        this.$api.get('channels/' + this.$route.params.conversation + '/posts/' + this.$route.params.id)
        .then(response => {
            if(response.data.member_id !== this.$store.state.member.id) this.$router.push('/conversation/' + this.$route.params.conversation) // 404
            this.message = response.data
            this.message_text = this.message.message
        })
        .catch(err => {
            alert(err.response.data.message)
            this.$router.push('/')
        }).finally(() => {
            this.$isLoading(false)
        })
    },
    methods:{
        remove(){
            this.$isLoading(true)
            this.$api.delete('channels/' + this.$route.params.conversation + '/posts/' + this.$route.params.id)
            .then(() => {
                this.$router.push('/conversation/' + this.$route.params.conversation)
            }).finally(() => {
                this.$isLoading(false)
            })
        },
        update(){
            this.$isLoading(true)
            this.$api.put('channels/' + this.$route.params.conversation + '/posts/' + this.$route.params.id, {
                message : this.message_text
            })
            .then(() => {
                this.$router.push('/conversation/' + this.$route.params.conversation)
            }).finally(() => {
                this.$isLoading(false)
            })
        }
    }
}
</script>

<style>

</style>