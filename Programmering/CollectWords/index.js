const app = Vue.createApp({
    data() {
        return {
            
            Word: String,
            Words: [],
            Message: "testing",
            ShowMessage: false
        }
    },

    methods: {
        Save(word) {
            this.Words.push(word)
        },
        Clear() {
            this.Words = []
        },
        Show() {
            this.ShowMessage = true
        }
    }
})

app.mount("#app")