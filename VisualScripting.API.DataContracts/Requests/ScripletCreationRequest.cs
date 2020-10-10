using System;
using System.Collections.Generic;
using System.Text;

namespace VisualScripting.API.DataContracts.Requests
{
    public class ScripletCreationRequest
    {
        public DateTime Date { get; set; }

        // TODO: Include only the fields that need initializing, since most fields can have default values
        public Scriplet Scriplet { get; set; }
    }
}
