using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // TODO: Make Swagger docs for these
        /// <summary>
        /// The starting node of this scriplet.
        /// </summary>
        /// <remarks>
        /// By default, initializes id, x, and y properties to 0 and schemaId to "Hidden/Start"
        /// </remarks>
        public NodeItem Start { get; set; } = new NodeItem { Id = 0, X = 0, Y = 0, SchemaId = "Hidden/Start" };

        public Dictionary<int, NodeItem> Items { get; set; } = new Dictionary<int, NodeItem>();
        public int ItemCounter { get; set; } = 1;
        public Dictionary<int, VariableItem> Variables { get; set; }
        public int VariableCounter { get; set; }
        public Dictionary<int, VariableItem> Inputs { get; set; }
        public int InputCounter { get; set; }
        public Dictionary<int, VariableItem> Outputs { get; set; }
        public int OutputCounter { get; set; }

        public Scriplet()
        {
            Items.Add(0, Start);
        }
    }
}
