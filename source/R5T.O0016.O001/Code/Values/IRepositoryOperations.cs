using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0200.Extensions;


namespace R5T.O0016.O001
{
    [ValuesMarker]
    public partial interface IRepositoryOperations : IValuesMarker
    {
        private static Internal.IRepositoryOperations Internal => O001.Internal.RepositoryOperations.Instance;


        /// <summary>
        /// Specifies the repository name, and will delete any existing repository infrastructure (remote GitHub repository and local directory path)
        /// to allow just creating a repository.
        /// </summary>
        public async Task In_New_SampleRepositoryContext(
            Func<IRepositoryContext, Task> repositoryContextAction)
        {
            var repositoryName = Instances.Values.Sample_RepositoryName;
            var repositoryOwnerName = Instances.OwnerNames.SafetyCone;
            var repositoryDescription = Instances.Values.Sample_RepositoryDescription;

            await Internal.Reset_Repository(
                repositoryName,
                repositoryOwnerName,
                repositoryDescription);

            var localRepositoryDirectoryPath = Instances.DirectoryPathOperator.GetLocalRepositoryDirectoryPath(
                repositoryName.Value,
                repositoryOwnerName.Value)
                .ToRepositoryDirectoryPath();

            var context = new RepositoryContext
            {
                RepositoryName = repositoryName,
                OwnerName = repositoryOwnerName,
                LocalDirectoryPath = localRepositoryDirectoryPath,
            };

            await Instances.ActionOperator.Run(
                repositoryContextAction,
                context);
        }

        /// <inheritdoc cref="In_New_SampleRepositoryContext(Func{IRepositoryContext, Task})"/>
        public async Task In_New_SampleRepositoryContext(
            Action<IRepositoryContext> repositoryContextAction)
        {
            var repositoryName = Instances.Values.Sample_RepositoryName;
            var repositoryOwnerName = Instances.OwnerNames.SafetyCone;
            var repositoryDescription = Instances.Values.Sample_RepositoryDescription;

            await Internal.Reset_Repository(
                repositoryName,
                repositoryOwnerName,
                repositoryDescription);

            var localRepositoryDirectoryPath = Instances.DirectoryPathOperator.GetLocalRepositoryDirectoryPath(
                repositoryName.Value,
                repositoryOwnerName.Value)
                .ToRepositoryDirectoryPath();

            var context = new RepositoryContext
            {
                RepositoryName = repositoryName,
                OwnerName = repositoryOwnerName,
                LocalDirectoryPath = localRepositoryDirectoryPath,
            };

            Instances.ActionOperator.Run(
                context,
                repositoryContextAction);
        }
    }
}
