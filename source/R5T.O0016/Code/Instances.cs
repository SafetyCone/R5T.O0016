using System;


namespace R5T.O0016
{
    public static class Instances
    {
        public static Z0036.ICommitMessages CommitMessages => Z0036.CommitMessages.Instance;
        public static L0036.IGitHubRepositoryContextOperations GitHubRepositoryContextOperations => L0036.GitHubRepositoryContextOperations.Instance;
        public static F0041.IGitOperator GitOperator => F0041.GitOperator.Instance;
        public static L0047.O001.ILocalGitRepositoryContextOperations LocalGitRepositoryContextOperations => L0047.O001.LocalGitRepositoryContextOperations.Instance;
        public static L0047.F000.ILocalRepositoryContextOperator LocalRepositoryContextOperator => L0047.F000.LocalRepositoryContextOperator.Instance;
        public static F0143.F001.IOrganizationNameOperator OrganizationNameOperator => F0143.F001.OrganizationNameOperator.Instance;
        public static L0042.O001.IRepositoryContextOperations RepositoryContextOperations => L0042.O001.RepositoryContextOperations.Instance;
        public static IRepositoryContextOperationSets RepositoryContextOperationSets => O0016.RepositoryContextOperationSets.Instance;
        public static L0042.F000.IRepositoryContextOperator RepositoryContextOperator => L0042.F000.RepositoryContextOperator.Instance;
        public static F0142.IRepositoryNameOperator RepositoryNameOperator => F0142.RepositoryNameOperator.Instance;
    }
}