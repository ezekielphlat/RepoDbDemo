using Microsoft.Data.SqlClient;
using RepoDb;

namespace RepodbDemo
{
    public class WarehouseRepository : BaseRepository<Warehouse, SqlConnection>
    {    

        public WarehouseRepository(string connectionString): base(connectionString)
        {
            
        }
    }
}
