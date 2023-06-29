using System;


namespace R5T.O0016.O001.Internal
{
    public class RepositoryOperations : IRepositoryOperations
    {
        #region Infrastructure

        public static IRepositoryOperations Instance { get; } = new RepositoryOperations();


        private RepositoryOperations()
        {
        }

        #endregion
    }
}
