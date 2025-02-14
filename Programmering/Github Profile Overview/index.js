const baseUrl = "https://api.github.com/users/hillgrove/repos"

Vue.createApp({
    data() {
        return {
            repos: [],
<<<<<<< HEAD
            error: null // use or not?
        }
    },

    created() {
        console.log("created method called")
        this.getRepos()

    },

    methods: {
        async getRepos() {
            try {
                const response = await axios.get(baseUrl)
                this.repos = response.data
            }

            catch (ex) {
                this.repos = [],
                this.error = ex.message
            }
=======
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
>>>>>>> f8aa1808ed14caf35307f1ba10f3ff629967ef38
        }
    }
}).mount("#app")