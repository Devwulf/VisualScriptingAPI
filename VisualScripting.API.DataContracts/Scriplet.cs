using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisualScripting.API.DataContracts
{
    public class Scriplet
    {
        [DataType(DataType.Text)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public NodeItem Start { get; set; }
        public Dictionary<int, NodeItem> Items { get; set; }
        public int ItemCounter { get; set; }
        public Dictionary<int, VariableItem> Variables { get; set; }
        public int VariableCounter { get; set; }
        public Dictionary<int, VariableItem> Inputs { get; set; }
        public int InputCounter { get; set; }
        public Dictionary<int, VariableItem> Outputs { get; set; }
        public int OutputCounter { get; set; }
    }
}
