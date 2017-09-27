namespace identity.Models
{
    public class HomePageModel
    {
        public HomePageModel(string name)
        {
            this.UserName = name;
        }
        public string UserName { get; }
    }
}
