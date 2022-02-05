<template>
  <div class="card has-background-link-light">
        <div class="card-content">
            <router-link class="media" :to="'conversation/' + conversation.id">
                <div class="media-left">
                    <figure class="image is-48x48">
                        <vue-letter-avatar :name='conversation.label' />
                    </figure>
                </div>
                <div class="media-content">
                    <p class="title is-4 has-text-link">{{ conversation.label }}</p>
                    <p v-if="conversation.created_at === conversation.modified_at" class="subtitle is-6">{{ conversation.created_at }}</p>
                    <p v-else class="subtitle is-6">{{ conversation.modified_at }} - (Modifié)</p>
                </div>
            </router-link>
            <div class="content">
                {{ conversation.topic }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: ['conversation']
}
</script>

<style>

</style>