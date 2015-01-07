using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CassandraDbMgr dbcMgr = new CassandraDbMgr("127.0.0.1");

            dbcMgr.ExecuteNonQuery("create table if not exists test2 (id int, description varchar, primary key (id));");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into test2(id, description) values (:id, :description);{0}", Environment.NewLine);

            var test = new { a = "aValue", b = "bValue" };

            IDictionary<string, object> p = new Dictionary<string, object>();

            p.Add("id", 12);
            p.Add("description", "This is a test");

            dbcMgr.ExecuteNonQuery(sb.ToString(), p);
        }
    }
}
