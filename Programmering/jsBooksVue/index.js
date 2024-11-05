const baseUrl = "https://anbo-restbookquerystring.azurewebsites.net/api/Books"

Vue.createApp({
    data() {
        return {
            books: [],
            titleSubstring: "",
            idToGetBy: "",
            singleBook: null,
            bookSearched: false,
            addData: { title: "", price: 0 },
            addMessage: "",
            updateData: { id: 0, title: "", price: 0 },
            updateMessage: "",
            idToDelete: "",
            deleteMessage: ""
        }
    },

    methods: {
        getAllBooks() {
            console.log("Getting all books")
            this.getBooks(baseUrl)
        },

        async getByTitle() {
            const substring = this.titleSubstring.toLowerCase()
            console.log("Getting books by title: " + substring)
            this.titleSubstring = ""
            await this.getBooks(baseUrl)
            this.books = this.books.filter(book => book.title.toLowerCase().includes(substring))
        },

        async getBooks(url) {
            console.log("Get books using url: " + url)
            try {
                const response = await axios.get(url)
                this.books = await response.data
            }

            catch (ex) {
                alert(ex.message)
            }
        },

        async getById(id) {
            if (id < 0 || !id) {
                alert("please type a positive id")
            }

            else {
                const url = baseUrl + "/" + id
                console.log("Get book by id: " + url)

                try {
                    const response = await axios.get(url)
                    this.singleBook = await response.data
                    this.bookSearched = true
                }

                catch (ex) {
                    alert(ex.message)
                }
            }
        },

        async addBook() {
            console.log("Add book")
            try {
                const response = await axios.post(baseUrl, this.addData)
                this.addMessage = "response: " + response.status + " " + response.statusText
                this.getAllBooks()
            }

            catch (ex) {
                alert(ex.message)
            }
        },

        async updateBook() {
            console.log("Update book")
            try {
                const url = baseUrl + "/" + this.updateData.id
                const response = await axios.put(url, this.updateData)
                this.updateMessage = "response: " + response.status + " " + response.statusText
                this.getAllBooks()
            }

            catch (ex) {
                alert(ex.message)
            }
        },

        async deleteBook(id) {
            const url = baseUrl + "/" + id
            console.log("Delete book by id: " + url)

            try {
                const response = await axios.delete(url)
                this.deleteMessage = "response: " + response.status + " " + response.statusText
                this.getAllBooks()
            }

            catch (ex) {
                alert(ex.message)
            }
        }
    }
}).mount("#app")