namespace backend.Models
{
    public class Projetos
    {
        public int Id {set; get;}
        public required string Title {set; get;}
        public required string Description {set; get;}
        public string ?GithubLink {set; get;}
        public string ?AnotherLink {get; set;}
    }
}