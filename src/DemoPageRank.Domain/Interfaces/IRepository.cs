﻿namespace DemoPageRank.Domain.Interfaces;
public interface IRepository<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
}
