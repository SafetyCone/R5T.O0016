using System;

using R5T.T0137;
using R5T.T0184;
using R5T.T0194;
using R5T.T0198;
using R5T.T0200;


namespace R5T.O0016.T001
{
    /// <summary>
    /// Repository context for a combined local and remote repository.
    /// </summary>
    [ContextDefinitionMarker]
    public interface IRepositoryContext : IContextDefinitionMarker,
        ITextOutputtedContext
    {
        IRepositoryName RepositoryName { get; }
        IRepositoryOwnerName RepositoryOwnerName { get; }
        IRepositoryDescription RepositoryDescription { get; }
        ILocalRepositoryDirectoryPath LocalRepositoryDirectoryPath { get; }
        IRepositoryUrl RemoteRepositoryUrl { get; }
    }
}