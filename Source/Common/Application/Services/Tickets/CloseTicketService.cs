using Common.Application.Services.Email;
using Common.Domain.Tickets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Application.Services.Tickets
{
    public class CloseTicketService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CloseTicketService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private const int SecondsInterval = 20;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(Convert.ToDouble(SecondsInterval)));

            while (await timer.WaitForNextTickAsync(stoppingToken))
                await ExecuteClosingTickets();
        }

        public async Task ExecuteClosingTickets()
        {
            if (Environment.GetEnvironmentVariable("EXECUTE_CLOSING_TICKETS_JOB") == "false")
                return;

            using var scope = _serviceProvider.CreateScope();
            var ticketsRepository = scope.ServiceProvider.GetRequiredService<ITicketsRepository>();
            var emailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();

            var ticketsToClose = await ticketsRepository.ListAllSolvedTickets();

            foreach (var ticket in ticketsToClose)
                ticket.CloseTicket();

            ticketsRepository.DeleteMany(ticketsToClose);
            await ticketsRepository.Commit();

            foreach (var ticket in ticketsToClose)
            {
                var subject = "Seu chamado foi encerrado!";
                var message = @$"
                    <p>Olá {ticket.User.Name},</p>
                    <p>Seu chamado foi encerrado devido à falta de retorno após a solução. Se você ainda estiver enfrentando o mesmo problema, por favor, abra um novo ticket.</p>
                    <p>Caso deseje acessar o nosso sistema, clique no botão abaixo:</p>
                    <p><a href='#' class='btn'>Clique Aqui</a></p>
                    <p>Estamos à disposição para qualquer dúvida!</p>";

                await emailSenderService.SendEmailAsync(ticket.User.Email, subject, message);
            }
        }
    }
}
