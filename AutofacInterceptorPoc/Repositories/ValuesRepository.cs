using System;
using System.Collections.Generic;
using AutofacInterceptorPoc.CustomAttributes;

namespace AutofacInterceptorPoc.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly Random _random = new Random();
        private List<string> Values { get; } = new List<string>();

        [Retry(5)]
        public string PotentialyInstableMethod()
        {
            if (_random.Next(2) != 0)
            {
                throw new Exception("Bad luck...");
            }
            return "Lucky!";
        }
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