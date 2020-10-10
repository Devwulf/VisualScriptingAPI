using System;
using System.Collections.Generic;
using System.Text;

namespace VisualScripting.API.DataContracts
{
    public class VariableItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public object StartValue { get; set; }
        public object Value { get; set; }
    }
}
