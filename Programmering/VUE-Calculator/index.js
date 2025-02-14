const app = Vue.createApp({
    data() {
        return {
            number1: null,
            number2: null,
            result: null,
            operation: "+"

        }
    },

    methods: {
        calculate() {            
            switch(this.operation) {
                case "+": this.result = this.number1 + this.number2; break
                case "-": this.result = this.number1 - this.number2; break
                case "*": this.result = this.number1 * this.number2; break
                case "/": this.result = this.number1 / this.number2; break
            }
        }
    }
})

app.mount("#app")