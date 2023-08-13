using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0042.T000;
using R5T.T0132;
using R5T.T0159;
using R5T.T0184;
using R5T.T0222;


namespace R5T.O0016
{
    [FunctionalityMarker]
    public partial interface IRepositoryContextOperator : IFunctionalityMarker
    {
        public Task In_New_RepositoryContext(
            IRepositoryName repositoryName,
            IOrganizationName organizationName,
            IRepositoryDescription repositoryDescription,
            bool isPrivate,
            ITextOutput textOutput,
            IEnumerable<Func<IRepositoryContext, Task>> operations = default)
        {
            var adjustedRepositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName_ForPrivacy(
                repositoryName,
                isPrivate);

            var allOperations = Instances.RepositoryContextOperationSets.Create_Repository(
                organizationName,
                repositoryDescription,
                isPrivate)
                .Append(operations);

            return Instances.RepositoryContextOperator.In_RepositoryContext(
                adjustedRepositoryName,
                textOutput,
                allOperations);
        }

        public Task In_New_RepositoryContext(
            IRepositoryName repositoryName,
            IOrganizationName organizationName,
            IRepositoryDescription repositoryDescription,
            bool isPrivate,
            ITextOutput textOutput,
            params Func<IRepositoryContext, Task>[] operations)
        {
            return this.In_New_RepositoryContext(
                repositoryName,
                organizationName,
                repositoryDescription,
                isPrivate,
                textOutput,
                operations.AsEnumerable());
        }
    }
}
