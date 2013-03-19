using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Procad.DataAccess.Interfaces
{
    public interface IResourcesRepository
    {
        T Get<T>(string resourceEndpoint);
        T Get<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null);
        IEnumerable<T> GetMany<T>(string resourceEndpoint);
        IEnumerable<T> GetMany<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null);
        HttpResponseMessage Post<T>(string resourceEndpoint, T data);
        HttpResponseMessage Put<T>(string resourceEndpoint, T data);
        HttpResponseMessage Delete(string resourceEndpoint);
    }

    public interface IResourcesRepository<T>
    {
        T Get(string resourceEndpoint);
        T Get(string resourceEndpoint, object parameters = null, object oDataParameters = null);
        IEnumerable<T> GetMany(string resourceEndpoint);
        IEnumerable<T> GetMany(string resourceEndpoint, object parameters = null, object oDataParameters = null);
        HttpResponseMessage Post(string resourceEndpoint, T data);
        HttpResponseMessage Put(string resourceEndpoint, T data);
        HttpResponseMessage Delete(string resourceEndpoint);
    }
}
