using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisualScripting.API.DataContracts
{
    public class NodeItem
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string CustomName { get; set; }

        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string SchemaId { get; set; }

        public IdValuePair[] InputValues { get; set; } = { };
        public ItemSlotPair[] InputSlots { get; set; } = { };
        public ItemSlotPair[] InputFlowSlots { get; set; } = { };
        public Dictionary<int, ItemSlotPair[]> OutputSlots { get; set; } = new Dictionary<int, ItemSlotPair[]>();
        public ItemSlotPair[] OutputFlowSlots { get; set; } = { };
        public int VariableId { get; set; }

        [DataType(DataType.Text)]
        public string VariableType { get; set; }
    }
}
