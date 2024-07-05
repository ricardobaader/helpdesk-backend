using Common.Domain;
using Common.Domain.Chats;
using Common.Domain.Users;
using Microsoft.AspNetCore.SignalR;

namespace Common.Application.ChatHub
{
    public class ChatHub : Hub
    {
        private readonly IChatsRepository _chatsRepository;
        private readonly IBaseEntityRepository<User> _usersRepository;

        public ChatHub(
            IChatsRepository chatsRepository,
            IBaseEntityRepository<User> usersRepository)
        {
            _chatsRepository = chatsRepository;
            _usersRepository = usersRepository;
        }

        public async Task ConnectChat(Guid ticketId)
        {
            var chatExistente = await _chatsRepository.ExistsBy(x => x.TicketId == ticketId);

            if (chatExistente)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, ticketId.ToString());

                var mensagens = await _chatsRepository.ListChatWithUser(ticketId);

                foreach (var item in mensagens)
                    await Clients.Group(ticketId.ToString()).SendAsync("ChatHistory", item.User.Name, item.Message);
            }
        }

        public async Task SendMessage(string message, Guid userId, Guid ticketId)
        {
            ////var chat = new Chat(message, userId, ticketId);

            //await _chatsRepository.InsertOne(chat);
            //await _chatsRepository.Commit();

            //var username = await _usersRepository.ProjectOneBy(x => x.Name, x => x.Id == userId);

            //await Clients.Group(ticketId.ToString()).SendAsync("ReceiveMessage", username, message);
        }
    }
}
