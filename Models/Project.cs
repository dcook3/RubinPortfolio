namespace RubinPortfolio.Models
{
    public class Project
    {
        private string name { get; set; }
        private string shortDescription { get; set; }
        private string description { get; set; }
        private string duration { get; set; }
        private string role { get; set; }
        private string projectUrl { get; set; }
        private string[] responsibilities { get; set; } = new string[0];
        private string[] imageNames { get; set; } = new string[0];
        private string[] imageUrls { get; set; } = new string[0];

        public Project(string name, string shortDescription, string description, string duration, string role, string projectUrl, string[] responsibilities, string[] imageNames, string[] imageUrls)
        {
            this.name = name;
            this.shortDescription = shortDescription;
            this.description = description;
            this.duration = duration;
            this.role = role;
            this.projectUrl = projectUrl;
            this.responsibilities = responsibilities;
            this.imageNames = imageNames;
            this.imageUrls = imageUrls;
        }

        public static string GetJsonAsString(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
