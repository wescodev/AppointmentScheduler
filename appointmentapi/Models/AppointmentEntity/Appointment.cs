using appointmentapi.Models.AuthEntity;

namespace appointmentapi.Models.AppointmentEntity;

public class Appointment
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    public int SpecialtyId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}

//💡 Exemplo de dados:
//João Silva, 2025-11-10 09:00, Especialidade: Cardiologia, Unidade: Paulista, Status: “Agendado”