const app = Vue.createApp({
    data() {
        return {
            word: null,
            words: [],
            message: null
        }
    },

    methods: {
        Save(word) {
            this.words.push(word)
        },
        Clear() {
            this.words = []
            this.message = null
        },
        Show() {
            if (this.words == null || this.words.length == 0) {
                this.message = "empty"
            }
            else {
                this.message = this.words.toString()
            }
        }
    }
})

app.mount("#app")