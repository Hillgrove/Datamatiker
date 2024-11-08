const baseUrl = "https://api.github.com/users/hillgrove/repos"

Vue.createApp({
    data() {
        return {
            repos: [],
            error: null
        }
    },

    async created() {
        this.getAll(baseUrl)
    },

    methods: {
        async getAll(url) {
            try {
                const response = await axios.get(url)
                this.repos = response.data
            }
            catch (ex) {
                this.error = ex.message 
            }
        }
    }
}).mount("#app")