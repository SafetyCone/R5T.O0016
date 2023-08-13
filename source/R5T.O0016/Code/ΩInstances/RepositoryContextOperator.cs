using System;


namespace R5T.O0016
{
    public class RepositoryContextOperator : IRepositoryContextOperator
    {
        #region Infrastructure

        public static IRepositoryContextOperator Instance { get; } = new RepositoryContextOperator();


        private RepositoryContextOperator()
        {
        }

        #endregion
    }
}
