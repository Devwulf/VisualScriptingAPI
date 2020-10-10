using System;
using System.Collections.Generic;
using System.Text;

namespace VisualScripting.Services.Model
{
    public class NodeItem
    {
        public int Id { get; set; }
        public string CustomName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string SchemaId { get; set; }
        public IdValuePair[] InputValues { get; set; }
        public ItemSlotPair[] InputSlots { get; set; }
        public ItemSlotPair[] InputFlowSlots { get; set; }
        public ItemSlotPair[] OutputSlots { get; set; }
        public ItemSlotPair[] OutputFlowSlots { get; set; }
        public int VariableId { get; set; }
        public string VariableType { get; set; }
    }
}
