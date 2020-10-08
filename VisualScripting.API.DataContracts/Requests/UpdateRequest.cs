using System;
using System.Collections.Generic;
using System.Text;

namespace VisualScripting.API.DataContracts.Requests
{
    public class UpdateRequest
    {
        public string Id { get; set; }
        public Dictionary<string, string> NameValuePairs { get; set; }
    }
}
