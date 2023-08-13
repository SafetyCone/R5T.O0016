using System;


namespace R5T.O0016
{
    public class RepositoryContextOperationSets : IRepositoryContextOperationSets
    {
        #region Infrastructure

        public static IRepositoryContextOperationSets Instance { get; } = new RepositoryContextOperationSets();


        private RepositoryContextOperationSets()
        {
        }

        #endregion
    }
}
