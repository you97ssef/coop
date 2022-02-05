import Vue from "vue";
import VueRouter from "vue-router";
import Register from "../views/user/register.vue";
import Login from "../views/user/login.vue";
import Members from "../views/user/members.vue";
import Member from "../views/user/member.vue";
import Conversations from "../views/conversation/conversations.vue";
import NewConversation from "../views/conversation/newConversation.vue";
import UpdateConversation from "../views/conversation/updateConversation.vue";
import Conversation from "../views/conversation/conversation.vue";
import Message from "../views/conversation/message.vue";

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Conversations",
        component: Conversations,
    },
    {
        path: "/register",
        name: "Creation compte",
        component: Register,
    },
    {
        path: "/login",
        name: "Login",
        component: Login,
    },
    {
        path: "/new-conversation",
        name: "new-conversation",
        component: NewConversation,
    },
    {
        path: "/conversation/:id",
        name: "conversation",
        component: Conversation,
    },
    {
        path: "/update-conversation/:id",
        name: "update-conversation",
        component: UpdateConversation,
    },
    {
        path: "/members",
        name: "Members",
        component: Members,
    },
    {
        path: "/member/:id",
        name: "Member",
        component: Member,
    },
    {
        path: "/conversation/:conversation/messsage/:id",
        name: "Message",
        component: Message,
    }
];

const router = new VueRouter({
    routes,
});

export default router;
