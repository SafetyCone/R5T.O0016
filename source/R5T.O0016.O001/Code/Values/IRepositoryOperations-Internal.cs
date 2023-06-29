using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0184;


namespace R5T.O0016.O001.Internal
{
    [ValuesMarker]
    public partial interface IRepositoryOperations : IValuesMarker
    {
        public async Task Reset_Repository(
            IRepositoryName repositoryName,
            T0186.IOwnerName repositoryOwnerName,
            IRepositoryDescription repositoryDescription)
        {
            var localRepositoryDirectory = Instances.DirectoryPathOperator.GetLocalRepositoryDirectoryPath(
                repositoryName.Value,
                repositoryOwnerName.Value);

            // Delete any existing repository infrastructure.s
            await Instances.GitHubOperator.DeleteRepository_Idempotent(
                repositoryOwnerName.Value,
                repositoryName.Value);

            Instances.LocalRepositoryOperator.Delete_Idempotent(localRepositoryDirectory);

            // Create new infrastructure.
            await Instances.GitHubOperator.Create_Repository(
                repositoryName.Value,
                repositoryOwnerName.Value,
                repositoryDescription.Value);

            await Instances.GitOperator.Clone_NonIdempotent(
                repositoryName.Value,
                repositoryOwnerName.Value);
        }
    }
}
