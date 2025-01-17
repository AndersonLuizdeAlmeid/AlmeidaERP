﻿using AlmeidaERP.Core.Factory.Interfaces;
using System.Data;

namespace AlmeidaERP.Core.Factory;
public sealed class DatabaseFactory : IDatabaseFactory, IDisposable
{
    private bool OpenTransaction { get; set; }
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; set; }

    public DatabaseFactory(string connectionString)
    {
        // Connection = new NpgsqlConnection(connectionString);
        OpenTransaction = false;
        Connection.Open();
    }

    public void Begin()
    {
        Transaction = Connection.BeginTransaction();
        OpenTransaction = true;
    }

    public void Commit()
    {
        Transaction!.Commit();
        OpenTransaction = false;
    }

    public void Rollback()
    {
        Transaction!.Rollback();
        OpenTransaction = false;
    }

    public void Dispose()
    {
        if (OpenTransaction)
            Transaction?.Rollback();

        Transaction?.Dispose();
        Connection?.Close();
        Connection?.Dispose();

        GC.SuppressFinalize(this);
    }
}