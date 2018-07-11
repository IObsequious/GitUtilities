namespace RepoGen
{
    public class RepositoryInfoManager
    {
        public RepositoryInfo Model { get; }

        public RepositoryInfoViewModel ViewModel { get; }

        public RepositoryInfoManager()
        {
            Model = new RepositoryInfo();
            ViewModel = new RepositoryInfoViewModel(Model);
        }
    }
}
