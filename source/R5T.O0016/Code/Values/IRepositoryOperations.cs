using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0031.Extensions;
using R5T.L0042.T000;
using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0198.Extensions;
using R5T.T0200.Extensions;

using R5T.T0186.Extensions;


namespace R5T.O0016
{
    [ValuesMarker]
    public partial interface IRepositoryOperations : IValuesMarker
    {
        /// <summary>
        /// Verifies that the repository does not exist (checks both remote GitHub and local Git),
        /// then creates the remote repository and clones it locally.
        /// A repository context is then provided
        /// </summary>
        public async Task In_New_RepositoryContext(
            IRepositoryName repositoryName,
            IRepositoryDescription repositoryDescription,
            IRepositoryOwnerName repositoryOwnerName,
            bool isPrivate,
            ITextOutput textOutput,
            IEnumerable<Func<T001.IRepositoryContext, Task>> operations = default)
        {
            var repositoryContext = new RepositoryContext
            {
                RepositoryName = repositoryName,
                TextOutput = textOutput,
            };

            var innerRepositoryContext = new T001.RepositoryContext
            {
                RepositoryName = repositoryName,
                RepositoryOwnerName = repositoryOwnerName,
                RepositoryDescription = repositoryDescription,
                TextOutput = textOutput,
            };

            // Run operations to build the inner repository context.
            await repositoryContext.Run(
                Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist(repositoryOwnerName),
                Instances.RepositoryContextOperations.In_CreateRepositoryContext(
                    Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                        repositoryOwnerName.Value.ToGitHubRepositoryOwnerName(),
                        Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(
                            repositoryDescription,
                            isPrivate),
                        Instances.GitHubRepositoryContextOperations.Clone_Repository(
                            localRepositoryDirectoryPath => innerRepositoryContext.LocalRepositoryDirectoryPath = localRepositoryDirectoryPath.ToLocalRepositoryDirectoryPath()),
                        async gitHubRepositoryContext =>
                        {
                            innerRepositoryContext.RemoteRepositoryUrl = (await F0041.GitHubOperator.Instance.GetCloneUrl(
                                gitHubRepositoryContext.OwnerName.Value,
                                gitHubRepositoryContext.RepositoryName.Value))
                                .ToRepositoryUrl();
                        }
                    )
                )
            );

            // Then run the operations for the inner repository context.
            await innerRepositoryContext.Run(
                operations);
        }

        public Task In_New_RepositoryContext(
            IRepositoryName repositoryName,
            IRepositoryDescription repositoryDescription,
            IRepositoryOwnerName repositoryOwnerName,
            bool isPrivate,
            ITextOutput textOutput,
            params Func<T001.IRepositoryContext, Task>[] operations)
        {
            return this.In_New_RepositoryContext(
                repositoryName,
                repositoryDescription,
                repositoryOwnerName,
                isPrivate,
                textOutput,
                operations.AsEnumerable());
        }

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
