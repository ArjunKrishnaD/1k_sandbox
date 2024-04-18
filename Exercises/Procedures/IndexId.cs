using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Procedures
{
    public class IndexId
    {
        private readonly List<int> ids = new List<int> {};
        public IndexId Next()
        {
            if (ids.Count == 0) return this;
            ids[ids.Count - 1]= ids[ids.Count - 1] + 1;
            return this;
        }
        public IndexId Down()
        {
            ids.Add(0);
            return this;
        }
        public IndexId Up()
        {
            ids.RemoveAt(ids.Count-1);
            return this;
        }
        public string Value()
        {
            return ids.Select(i => i.ToString()).Aggregate((i, j) => i + "." + j);

        }

    }
}
