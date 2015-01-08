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

            dbcMgr.Execute("create table if not exists demo.test2 (id int, group int, description varchar, primary key (id));");
            
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("insert into test2(id, group, description) values (:id, :group, :description);{0}", Environment.NewLine);

            dbcMgr.Execute(sb.ToString());
        }
    }
}
