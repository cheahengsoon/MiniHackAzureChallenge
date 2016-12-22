using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHack
{
    class myTable
    {
        string desc;
        string name;
        string url;
        string id;

        [JsonProperty(PropertyName = "ID")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "NAME")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [JsonProperty(PropertyName = "DESC")]
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        [JsonProperty(PropertyName = "URL")]
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
    }
}
