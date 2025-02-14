<template>
    <div class="container">
        <h1 class="text-center mb-4">GitHub Repositories Overview</h1>
        <div class="row">
            <div v-if="loading" class="text-center">
                <div class="spinner-border" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
            </div>
            <div v-if="error" class="alert alert-danger" role="alert">
                {{ error }}
            </div>
            <div v-for="repo in repos" :key="repo.id" class="col-md-4">
                <RepoCard :repo="repo" />
            </div>
        </div>
    </div>
</template>

<script>
import RepoCard from "./RepoCard.js";

export default {
    name: "GitHubRepos",
    components: {
        RepoCard,
    },
    data() {
        return {
            repos: [],
            loading: true,
            error: null,
        };
    },
    mounted() {
        this.fetchRepos();
    },
    methods: {
        async fetchRepos() {
            try {
                const response = await axios.get(
                    "https://api.github.com/users/hillgrove/repos"
                );
                this.repos = response.data;
            } catch (err) {
                this.error = "Failed to load repositories. Please try again later.";
            } finally {
                this.loading = false;
            }
        },
    },
};
</script>

<style scoped>
.repo-card {
    margin-bottom: 20px;
}
</style>
