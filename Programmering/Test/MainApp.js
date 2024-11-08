import GitHubRepos from "./components/GitHubRepos.js";

export default {
  name: "MainApp",
  components: {
    GitHubRepos,
  },
  template: `
    <div id="app">
      <GitHubRepos />
    </div>
  `,
};
