using System;
/// <summary>
/// Descripción breve de IUnitOfWork
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IGenderRepository GenderRepository { get; }
    IUserRepository UserRepository { get; }
    int Commit();
    new void Dispose();
}