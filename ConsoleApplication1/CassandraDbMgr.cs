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

        public RowSet Execute(string cql)
        {
            PreparedStatement ps = _session.Prepare(cql);

            int id = 110;
            int group = 2;
            string description = "Test record 1 group 1";

            dynamic x = ps.Bind(new { id = id , group = group, description = description});
                
            return _session.Execute(x);
        }
	}
}