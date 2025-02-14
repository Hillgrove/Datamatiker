export default {
  name: "RepoCard",
  props: {
    repo: Object,
  },
  template: `
    <div class="card repo-card">
      <div class="card-body">
        <h5 class="card-title">{{ repo.name }}</h5>
        <p class="card-text">{{ repo.description || 'No description available' }}</p>
        <ul class="list-group list-group-flush">
          <li class="list-group-item"><strong>Stars:</strong> {{ repo.stargazers_count }}</li>
          <li class="list-group-item"><strong>Forks:</strong> {{ repo.forks_count }}</li>
          <li class="list-group-item"><strong>Language:</strong> {{ repo.language || 'Not specified' }}</li>
        </ul>
        <a :href="repo.html_url" target="_blank" class="btn btn-primary mt-3">View on GitHub</a>
      </div>
    </div>
  `,
};
