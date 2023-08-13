using System;
using System.Threading.Tasks;

using R5T.L0042.T000;
using R5T.T0131;
using R5T.T0184;
using R5T.T0186;
using R5T.T0222;


namespace R5T.O0016
{
    [ValuesMarker]
    public partial interface IRepositoryContextOperationSets : IValuesMarker
    {
        public Func<IRepositoryContext, Task>[] Create_Repository(
            IOrganizationName organizationName,
            IRepositoryDescription repositoryDescription,
            bool isPrivate)
        {
            var gitHubRepositoryOwnerName = Instances.OrganizationNameOperator.Get_GitHubRepositoryOwnerName(organizationName);

            return this.Create_Repository(
                gitHubRepositoryOwnerName,
                repositoryDescription,
                isPrivate);
        }

        public Func<IRepositoryContext, Task>[] Create_Repository(
            IGitHubRepositoryOwnerName gitHubRepositoryOwnerName,
            IRepositoryDescription repositoryDescription,
            bool isPrivate)
        {
            return new[]
            {
                Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist(
                    gitHubRepositoryOwnerName),
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    gitHubRepositoryOwnerName,
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(
                        repositoryDescription,
                        isPrivate
                    ),
                    Instances.GitHubRepositoryContextOperations.Clone_Repository()
                ),
                Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(
                    gitHubRepositoryOwnerName,
                    Instances.LocalGitRepositoryContextOperations.In_CommitContext(
                        Instances.CommitMessages.AddGitIgnoreFile,
                        Instances.LocalGitRepositoryContextOperations.Add_GitIgnoreFile
                    )
                )
            };
        }
    }
}
