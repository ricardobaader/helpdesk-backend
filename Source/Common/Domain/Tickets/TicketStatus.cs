using System.ComponentModel;

namespace Common.Domain.Tickets
{
    public enum TicketStatus
    {
        [Description("Pendente")]
        Pending = 0,
        [Description("Em Progresso")]
        InProgress = 1,
        [Description("Finalizado")]
        Finished = 2
    }
}
