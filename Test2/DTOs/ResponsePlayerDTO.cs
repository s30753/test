namespace Test2.DTOs;

public class ResponsePlayerDTO
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<ResponseMatchDTO> Matches { get; set; }
}