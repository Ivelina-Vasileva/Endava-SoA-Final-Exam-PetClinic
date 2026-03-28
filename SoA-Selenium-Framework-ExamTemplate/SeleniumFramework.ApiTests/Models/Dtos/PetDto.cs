namespace SeleniumFramework.ApiTests.Models.Dtos;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public PetType Type { get; set; }
    public int OwnerId { get; set; }

    public class PetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}