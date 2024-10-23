using AlmeidaERP.Core.Factory.Interfaces;

namespace AlmeidaERP.Core.Repository;
public interface ILocalDatabaseRepository
{
    IDatabaseFactory LocalDatabase { get; }
}