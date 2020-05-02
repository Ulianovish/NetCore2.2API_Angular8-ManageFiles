using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Serializable]
    public class Client
    {
        public int PersonId;
        public string Name;
        public string LastName;
        public string CurrentRole;
        public string Country;
        public string Industry;
        public int? NumberOfRecommendations;
        public int? NumberOfConnections;

    }
}
