using System.Collections.Generic;

namespace AutofacInterceptorPoc.Repositories
{
    public interface IValuesRepository
    {
        IEnumerable<string> Get();
        string Get(int id);
        void Post(string value);
        void Put(int id, string value);
        void Delete(int id);
    }
}