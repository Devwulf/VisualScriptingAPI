using System;
using System.Collections.Generic;
using System.Text;

namespace VisualScripting.API.DataContracts.Requests
{
    public class NodeItemUpdateRequest
    {
        public int Id { get; set; }
        public Dictionary<string, object> NameValuePairs { get; set; }
    }
}
