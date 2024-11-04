const baseUri = "https://jsonplaceholder.typicode.com/todos"

Vue.createApp({
    data() {
        return {
            todos: [],
            error: null,
            userId: ""
        }
    },

    async created() {
        // created() is a life cycle method, not an ordinary method
        // created() is called automatically when the page is loaded
        console.log("created method called")
        this.getTodos()
    },

    methods: {
        async getTodos(userId = null) {
            const uri = userId ? `${baseUri}?userId=${userId}` : baseUri;
            try {
                const response = await axios.get(uri)
                this.todos = await response.data
                this.error = null
            } 
            catch (ex) {
                this.todos = []
                this.error = ex.message
            }
        },

        cleanList() {
            this.todos = []
            this.error = null
        },

        async getByUserId(userId) {
            if (!userId) {
                this.error = "No user id is provided."
                this.todos = []
            }
            else {
                console.log("getByUserId: Fetching todos for user " + userId);
                this.getTodos(userId)
            }
        }
    }
}).mount("#app")