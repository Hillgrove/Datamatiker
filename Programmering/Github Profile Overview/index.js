const baseUrl = "https://api.github.com/users/hillgrove/repos"

Vue.createApp({
    data() {
        return {
            repos: [],
            loading: true,
            error: null,
        }
    },

    async created() {
        this.getAll(baseUrl)
    },

    methods: {
        async getAll(url) {
            try {
                const response = await axios.get(url)
                await this.wait(2000) // test: to test loading icon
                this.repos = response.data
            }
            catch (ex) {
                // this.error = ex.message
                this.error = "Failed to load repositories. Please try again later."
            }
            finally {
                this.loading = false;
            }
        },

        wait(ms) {
            return new Promise(resolve => setTimeout(resolve, ms))
        }
    }
}).mount("#app")