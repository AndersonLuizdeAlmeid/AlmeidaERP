
using System.Data;

namespace AlmeidaERP.Core.Factory.Interfaces;
public interface IDatabaseFactory
{
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; }
    void Begin();
    void Commit();
    void Rollback();
}
