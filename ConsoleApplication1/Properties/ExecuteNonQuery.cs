using System;
using Cassandra;


public class ExecuteNonQuery
{

    private string p;
    private ISession _session;

    public ExecuteNonQuery(string cql, dynamic parameters = null)
    {
        ExecuteRowSet(cql, parameters);
    }

    public RowSet ExecuteRowSet(string cql, dynamic parameters = null)
    {
        if (parameters != null)
        {
            PreparedStatement ps = _session.Prepare(cql);
            dynamic x = ps.Bind(parameters);
            return _session.Execute(x);
        }
        else return _session.Execute(cql);
    }
}
