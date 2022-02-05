<template>
    <div class="m-5 box">
        <h2 class="title is-2 has-text-centered">Update conversation</h2>
        <form class="m-3" @submit.prevent="submit()">
            <div class="field">
                <input class="input" type="text" required v-model="conversation.label">
            </div>
            <div  class="field">
                <input class="input" type="text" required v-model="conversation.topic">
            </div>
            <div class="field">
                <button class="button is-warning">Modifier la conversation</button>
            </div>
        </form>
    </div>
</template>

<script>
export default {
    data () {  
        return {
            conversation: {}
        }
    },
    created() {
        this.$isLoading(true)
        this.$api.get('channels/' + this.$route.params.id)
            .then(response => {
                if(response.data === null) this.$router.push('/') // 404
                this.conversation = response.data
            })
            .finally(() => {
                this.$isLoading(false)
            })
    },
    methods:{
        submit() {
            this.$isLoading(true)
            this.$api.put('channels/' + this.conversation.id,{
                label :this.conversation.label,
                topic :this.conversation.topic
            })
            .then(() => {
                this.$router.push('/')
            })
            .catch(err => alert(err.response.data.message))
            .finally(() => {
                this.$isLoading(false)
            })
        }
    }
}
</script>

<style>

</style>