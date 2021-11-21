// <copyright file="MessageService.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using BindingRadioButtonsOrCheckBoxesToEnums.Services.Interfaces;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Services
{
    /// <summary>
    /// MessageService.
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <inheritdoc/>
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
