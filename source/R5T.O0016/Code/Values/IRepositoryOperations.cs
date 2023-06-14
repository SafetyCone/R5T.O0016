using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0186.Extensions;


namespace R5T.O0016
{
    [ValuesMarker]
    public partial interface IRepositoryOperations : IValuesMarker
    {
        public async Task Delete_Repository(
            IRepositoryName repositoryName,
            IRepositoryOwnerName ownerName,
            ITextOutput textOutput)
        {
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                textOutput,
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    ownerName.Value.ToGitHubRepositoryOwnerName(),
                    Instances.GitHubRepositoryContextOperations.Delete_Repository
                ),
                Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(
                    repositoryName.Value.ToGitHubRepositoryName(),
                    ownerName.Value.ToGitHubRepositoryOwnerName(),
                    Instances.LocalGitRepositoryContextOperations.Delete_Repository
                )
            );
        }

        public async Task Create_Repository(
            IRepositoryName repositoryName,
            IRepositoryDescription repositoryDescription,
            IRepositoryOwnerName ownerName,
            ITextOutput textOutput,
            Action<L0036.T000.N001.IGitHubRepositoryContext, string> outputConsumer = default)
        {
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                textOutput,
                Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist(
                    ownerName),
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    ownerName.Value.ToGitHubRepositoryOwnerName(),
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(
                        repositoryDescription),
                    Instances.GitHubRepositoryContextOperations.Clone_Repository(
                        outputConsumer)
                )
            );
        }
    }
}
