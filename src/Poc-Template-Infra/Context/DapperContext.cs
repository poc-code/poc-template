using System.Data;

namespace Poc_Template_Infra.Context
{
    public class DapperContext
    {
        private readonly IDbConnection _conn;

        public DapperContext(IDbConnection conn)
        {
            _conn = conn;
        }

        public IDbConnection DapperConnection
        {
            get
            {
                return _conn;
            }
        }
    }
}
