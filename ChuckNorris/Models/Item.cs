using System;
using System.Collections.Generic;

namespace ChuckNorris.Models
{

    public class INorrisFact
    {
        List<string> categories { get; set; }
        string created_at { get; set; }
        string icon_url { get; set; }
        string id { get; set; }
        string updated_at { get; set; }
        string url { get; set; }
        string value { get; set; }
    }

    public class NorrisFact: INorrisFact
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class NullNorrisFact: NorrisFact
    {
        
    }

    public class NorrisFactQueryResult
    {
        public int total { get; set; }
        public NorrisFact[] result { get; set; }
    }


}