using System;


namespace R5T.O0016.O001
{
    public static class Instances
    {
        public static F0000.IActionOperator ActionOperator => F0000.ActionOperator.Instance;
        public static F0041.IDirectoryPathOperator DirectoryPathOperator => F0041.DirectoryPathOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static F0041.IGitOperator GitOperator => F0041.GitOperator.Instance;
        public static F0042.ILocalRepositoryOperator LocalRepositoryOperator => F0042.LocalRepositoryOperator.Instance;
        public static Z0043.IOwnerNames OwnerNames => Z0043.OwnerNames.Instance;
        public static Z0046.IValues Values => Z0046.Values.Instance;
    }
}