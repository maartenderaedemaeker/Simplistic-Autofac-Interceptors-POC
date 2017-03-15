using System.Collections.Generic;

namespace AutofacInterceptorPoc.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private List<string> Values { get; } = new List<string>();
        public IEnumerable<string> Get()
        {
            return Values;
        }

        public string Get(int id)
        {
            if (id < Values.Count)
            {
                return Values[id];
            }
            return null;
        }

        public void Post(string value)
        {
            Values.Add(value);
        }

        public void Put(int id, string value)
        {
            if (id < Values.Count)
            {
                Values[id] = value;
            }
        }

        public void Delete(int id)
        {
            if (id < Values.Count)
            {
                Values.RemoveAt(id);
            }
        }
    }
}