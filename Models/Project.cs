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
        public string Platform { get; set; }

        public Project(string name, string shortDescription, string description, string duration, string role, string projectUrl, string[] responsibilities, string[] imageNames, string[] imageUrls, string platform)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Duration = duration;
            Role = role;
            ProjectUrl = projectUrl;
            Responsibilities = responsibilities;
            ImageNames = imageNames;
            ImageUrls = imageUrls;
            Platform = platform;
        }

        public static string GetJsonAsString(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        public override string ToString()
        {
            return $"Name:{Name}, \nShort Desc: {ShortDescription},\nDesc: {Description},\nDuration: {Duration}\nRole: {Role},\nProject Url: {ProjectUrl},\nResponsibilities@0: {Responsibilities[0]},\nImage Names@0: {ImageNames[0]},\nImage Urls@0: {ImageNames[0]}";
        }
    }
}
