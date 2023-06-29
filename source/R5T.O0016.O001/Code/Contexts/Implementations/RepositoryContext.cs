using System;

using R5T.T0137;
using R5T.T0186;
using R5T.T0200;


namespace R5T.O0016.O001
{
    [ContextImplementationMarker]
    public class RepositoryContext : IRepositoryContext
    {
        public T0184.IRepositoryName RepositoryName { get; set; }
        public IOwnerName OwnerName { get; set; }
        public IRepositoryDirectoryPath LocalDirectoryPath { get; set; }
    }
}
