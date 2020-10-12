using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisualScripting.API.DataContracts.Requests
{
    public class NodeItemCreationRequest
    {
        public DateTime Date { get; set; }

        public NodeItem NodeItem { get; set; }
    }
}
