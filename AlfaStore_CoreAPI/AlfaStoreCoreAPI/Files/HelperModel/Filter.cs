using Newtonsoft.Json;
using System.Linq.Expressions;
using System;
using System.Text.Json;
using DataAccessLayer;

namespace AlfaStoreCoreAPI.Files.HelperModel
{
    public class Filter
    {
        public string prop_name { get; set; }
        public string operator_sign { get; set; }
        public string value { get; set; }

    }
}
