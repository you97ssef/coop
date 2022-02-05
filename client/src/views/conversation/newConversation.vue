<template>
    <div class="m-5 box">        
        <h2 class="title is-2 has-text-centered">New conversation</h2>
        <form class="m-3" @submit.prevent="submit()">
            <div class="field">
                <input class="input" type="text" required v-model="label">
            </div>
            <div  class="field">
                <input class="input" type="text" required v-model="topic">
            </div>
            <div class="field">
                <button class="button is-success">New conversation</button>
            </div>
        </form>
    </div>
</template>

<script>
export default {
    data () {  
        return {
            label :"Conversation",
            topic :"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vel luctus enim. Aliquam a nulla sit amet sem interdum luctus. Donec ac purus eget ex aliquam condimentum. Cras eget convallis tellus. Aenean volutpat, magna et tincidunt tincidunt, nisl nibh sollicitudin metus, quis efficitur risus tellus vitae tortor. Etiam nec turpis odio. Mauris venenatis felis nec hendrerit elementum. Ut pretium leo eget commodo posuere. Nulla et felis metus. Curabitur purus nisl, elementum a faucibus nec."
        }
    },
    methods:{
        submit() {
            this.$isLoading(true)
            this.$api.post('channels',{
                label :this.label,
                topic :this.topic
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