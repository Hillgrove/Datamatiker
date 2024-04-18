﻿
/// <summary>
/// Technology-neutral interface for a data service, which offers
/// methods for managing entities of type TData.
/// </summary>
/// <typeparam name="TData">Type of entities being managed</typeparam>
public interface IDataService<TData> where TData : class, IHasId, IUpdateFromOther<TData>
{
    /// <summary>
    /// Returns all entities stored in the data service.
    /// </summary>
    List<TData> GetAll();

    /// <summary>
    /// Stores the given entity in the data service, and also assigns a new Id to it.
    /// The Id value is generated by the data service.
    /// </summary>
    /// <returns>Id for the stored entity.</returns>
    int Create(TData t);

    /// <summary>
    /// Reads the entity with the given Id.
    /// </summary>
    /// <returns>Entity with the given Id, if such an entity exists. Otherwise null.</returns>
    TData? Read(int id);

    /// <summary>
    /// Updates the entity with the given Id.
    /// </summary>
    /// <returns>True if an entity was updated, otherwise false</returns>
    bool Update(int id, TData t);

    /// <summary>
    /// Deletes the entity with the given Id.
    /// </summary>
    /// <returns>True if an entity was deleted, otherwise false</returns>
    bool Delete(int id);
}