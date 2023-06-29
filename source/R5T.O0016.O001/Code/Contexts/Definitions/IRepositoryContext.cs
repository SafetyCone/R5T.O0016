using System;

using R5T.T0137;
using R5T.T0186;
using R5T.T0200;


namespace R5T.O0016.O001
{
    [ContextDefinitionMarker]
    public interface IRepositoryContext
    {
        public T0184.IRepositoryName RepositoryName { get; }
        public IOwnerName OwnerName { get; }
        public IRepositoryDirectoryPath LocalDirectoryPath { get; }
    }
}
