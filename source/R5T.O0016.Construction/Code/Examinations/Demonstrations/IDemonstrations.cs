using System;
using System.Threading.Tasks;

using R5T.T0141;


namespace R5T.O0016.Construction
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        public async Task In_New_SampleRepositoryContext()
        {
            await Instances.RepositoryOperations.In_New_SampleRepositoryContext(
                async repositoryContext =>
                {
                    var exists = await Instances.GitHubOperator.RepositoryExists(
                        repositoryContext.OwnerName.Value,
                        repositoryContext.RepositoryName.Value);

                    Console.Write($"{exists}: GitHub repository exists ({repositoryContext.OwnerName}/{repositoryContext.RepositoryName})");
                });
        }
    }
}
