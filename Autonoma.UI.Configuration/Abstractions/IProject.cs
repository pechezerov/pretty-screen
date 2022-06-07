﻿using Autonoma.Domain.Entities;
using System.Collections.Generic;

namespace Autonoma.UI.Configuration.Abstractions
{
    public interface IProject
    {
        public IRouterProject Technology { get; }

        public ITopologyProject Topology { get; }

        string? FilePath { get; }
    }

    public interface IRouterProject
    {
        public IList<IRouter> Routers { get; }
    }

    public interface IRouter
    {
        public string? Name { get; }
        public int? AdapterTypeId { get; }
        public IList<IAdapter> Adapters { get; }
    }

    public interface IAdapter
    {
        public string? Name { get; }
        AdapterType? AdapterType { get; }
    }

    /// <summary>
    /// Корневой узел иерархии информационной модели
    /// </summary>
    public interface ITopologyProject : ILogicalNode
    {
    }

    /// <summary>
    /// Логический узел (объединение в составе информационной модели)
    /// </summary>
    public interface ILogicalNode : IModelElement
    {
        public IEnumerable<IModelElement> Elements { get; }
    }

    /// <summary>
    /// Объектно-ориентированная единица информационной модели
    /// </summary>
    public interface IDataObject : IModelElement
    {
    }

    /// <summary>
    /// Неструктурированная единица информационной модели
    /// </summary>
    public interface IDataPoint : IModelElement
    {
    }

    /// <summary>
    /// Элементарная единица информационной модели
    /// </summary>
    public interface IModelElement
    {
        public string Name { get; }
    }
}