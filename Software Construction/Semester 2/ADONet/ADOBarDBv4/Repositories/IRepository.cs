﻿
/// <summary>
/// Technology-neutral interface for a repository with CRUD
/// methods for managing objects of type T.
/// </summary>
/// <typeparam name="T">Type of objects being stored</typeparam>
public interface IRepository<T> where T : class, IHasId
{
    /// <summary>
    /// Returns all objects stored in the repository.
    /// </summary>
    List<T> GetAll();

    /// <summary>
    /// Stores the given object in the repository, and also assigns a new ID to it.
    /// The ID value is generated by the repository.
    /// </summary>
    /// <returns>ID for the stored object.</returns>
    int Create(T t);

    /// <summary>
    /// Reads the object with the given ID.
    /// </summary>
    /// <returns>Object with the given ID, if such an objects exists. Otherwise null.</returns>
    T? Read(int id);

    /// <summary>
    /// Deletes the object with the given ID.
    /// </summary>
    /// <returns>true if an object was deleted, otherwise false</returns>
    bool Delete(int id);
}
