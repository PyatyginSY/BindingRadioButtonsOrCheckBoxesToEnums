using BindingRadioButtonsOrCheckBoxesToEnums.Services.Interfaces;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
