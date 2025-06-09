namespace Test2.DTOs;

public class ResponseMatchDTO
{
    public string Tournament { get; set; }
    public string Map { get; set; }
    public DateTime Date { get; set; }
    public int MVPs { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}