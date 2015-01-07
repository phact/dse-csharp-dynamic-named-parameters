using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cassandra;

namespace ConsoleApplication1
{
    class CassandraDbMgr
    {
        private   string p;
        private ISession _session;

public    CassandraDbMgr(string p)
    {
        Cluster cluster = Cluster.Builder().AddContactPoint(p).Build();
        this._session = cluster.Connect("demo");
        this.p = p;
    }
        public void ExecuteNonQuery(string cql, dynamic parameters = null)
        {
            ExecuteRowSet(cql, parameters);
        }

       public RowSet ExecuteRowSet(string cql, dynamic parameters = null)
        {
            if (parameters != null)
            {
                PreparedStatement ps = _session.Prepare(cql);
                object[] myArgs = new object[2];
                Console.Out.WriteLine(p.Length);
                int i = 0;
                foreach (var item in (IDictionary<string,object>)parameters)
                {
                    myArgs[i] = item.Value;
                    Console.Out.WriteLine(item.Value);
                    i++;
                }
                Console.Out.WriteLine(myArgs.ToString());
                dynamic x = ps.Bind(myArgs);
                return _session.Execute(x);
            }
            else return _session.Execute(cql);
        }
	}
}