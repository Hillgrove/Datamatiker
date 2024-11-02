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
            if (word) {
                this.words.push(word)
                this.word = ""
            }
            
        },
        Clear() {
            this.words = []
            this.message = null
        },
        Show() {
            if (this.words.length == 0) {
                this.message = "empty"
            }
            else {
                this.message = [...this.words];
            }
        }
    }
})

app.mount("#app")