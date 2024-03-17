namespace RubinPortfolio.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Role { get; set; }
        public string ProjectUrl { get; set; }
        public string[] Responsibilities { get; set; } = new string[0];
        public string[] ImageNames { get; set; } = new string[0];
        public string[] ImageUrls { get; set; } = new string[0];

        public Project(string name, string shortDescription, string description, string duration, string role, string projectUrl, string[] responsibilities, string[] imageNames, string[] imageUrls)
        {
            this.Name = name;
            this.ShortDescription = shortDescription;
            this.Description = description;
            this.Duration = duration;
            this.Role = role;
            this.ProjectUrl = projectUrl;
            this.Responsibilities = responsibilities;
            this.ImageNames = imageNames;
            this.ImageUrls = imageUrls;
        }

        public static string GetJsonAsString(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        public override string ToString()
        {
            return $"Name:{this.Name}, \nShort Desc: {this.ShortDescription},\nDesc: {this.Description},\nDuration: {this.Duration}\nRole: {this.Role},\nProject Url: {this.ProjectUrl},\nResponsibilities@0: {this.Responsibilities[0]},\nImage Names@0: {this.ImageNames[0]},\nImage Urls@0: {this.ImageNames[0]}";
        }
    }
}
