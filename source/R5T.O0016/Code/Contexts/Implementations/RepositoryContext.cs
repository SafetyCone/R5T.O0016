using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0184;
using R5T.T0198;
using R5T.T0200;


namespace R5T.O0016.T001
{
    /// <inheritdoc cref="IRepositoryContext"/>
    [ContextImplementationMarker]
    public class RepositoryContext : IContextImplementationMarker,
        IRepositoryContext
    {
        public IRepositoryName RepositoryName { get; set; }
        public IRepositoryOwnerName RepositoryOwnerName { get; set; }
        public IRepositoryDescription RepositoryDescription { get; set; }
        public ILocalRepositoryDirectoryPath LocalRepositoryDirectoryPath { get; set; }
        public IRepositoryUrl RemoteRepositoryUrl { get; set; }

        public ITextOutput TextOutput { get; set; }
    }
}