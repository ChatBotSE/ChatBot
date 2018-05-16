using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApplication1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        //Wait for a message from the user
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // Return our reply to the user
            await context.PostAsync($"You sent {activity.Text}");

            context.Wait(MessageReceivedAsync);
        }
    }
}