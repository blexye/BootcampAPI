using BootcampAPI.Domain.Enums;

namespace BootcampAPI.Domain.Entities
{
    public class DepositoCheque
    {
        public Guid IdDepositoCheque { get; set; }
        public Guid IdAccount { get; set; }
        public string NumeroCheque { get; set; } = string.Empty;
        public string BancoEmisor { get; set; } = string.Empty;
        public decimal MontoNumero { get; set; }
        public string MontoLetra { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public EstadoDepositoCheque EstadoDeposito { get; set; } = EstadoDepositoCheque.RevisionChequePendiente;
        public DateTime FechaSolicitudDepositoCheque { get; set; }
        public DateTime? FechaUltimaModificacionDepositoCheque { get; set; }
        public DateTime? FechaRevisionDepositoCheque { get; set; }
        public string? MotivoRechazo { get; set; }
        public string FotoFrontalRuta { get; set; } = string.Empty;
        public string FotoDorsalRuta { get; set; } = string.Empty;
    }
}
