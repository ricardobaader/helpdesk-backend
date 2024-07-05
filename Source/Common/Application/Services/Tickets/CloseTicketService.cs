using Common.Application.Services.Email;
using Common.Configurations;
using Common.Domain.Tickets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Application.Services.Tickets
{
    public class CloseTicketService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public CloseTicketService(
            IServiceProvider serviceProvider, 
            IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
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
            if (_configuration.ExecuteClosingTicketsJob() == "false")
                return;

            var frontendBaseUrl = Environment.GetEnvironmentVariable("FRONTEND_BASE_URL");

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
                    <p>$Seu chamado de número {ticket.Number} foi encerrado devido à falta de retorno após a solução. Se você ainda estiver enfrentando o mesmo problema, por favor, abra um novo ticket.</p>
                    <p>Caso deseje acessar o nosso sistema, clique no botão abaixo:</p>
                    <p><a href='{frontendBaseUrl}/dashboard/user/tickets/{ticket.Id}' class='btn'>Clique Aqui</a></p>
                    <p>Estamos à disposição para qualquer dúvida!</p>";

                await emailSenderService.SendEmailAsync(ticket.User.Email, subject, message);
            }
        }
    }
}
