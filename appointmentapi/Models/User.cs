namespace appointmentapi.Models;

public class User
{
    public int CdUser { get; set; }
    public string PasswordHash { get; set; } 
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public bool FlAtivo { get; set; }
    public int CdPerson { get; set; } 
    public Person Person { get; set; }
}
