using System.ComponentModel.DataAnnotations;

namespace VisualScripting.API.DataContracts
{
    public class User
    {
        [DataType(DataType.Text)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        public Address Address { get; set; }

    }
}
