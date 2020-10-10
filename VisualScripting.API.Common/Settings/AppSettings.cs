using System.ComponentModel.DataAnnotations;

namespace VisualScripting.API.Common.Settings
{
    public class AppSettings
    {
        [Required]
        public ApiSettings API { get; set; }
        [Required]
        public Swagger Swagger { get; set; }
        [Required]
        public MongoDBOptions MongoDB { get; set; }
    }

    public class ApiSettings
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public ApiContact Contact { get; set; }

        public string TermsOfServiceUrl { get; set; }

        public ApiLicense License { get; set; }
    }

    public class ApiContact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Url { get; set; }
    }

    public class ApiLicense
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Swagger
    {
        [Required]
        public bool Enabled { get; set; }
    }

    public class MongoDBOptions
    {
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public string Uri { get; set; }
        [Required]
        public string TestingUri { get; set; }
        [Required]
        public string DatabaseName { get; set; }
    }
}
