using DialogClients.DataAccess;
using DialogClients.Domain;

namespace DialogClients.BusinessLogic
{
    public class DialogsService : IDialogsService
    {
        public async Task<Guid> FindDialog(Guid[] clientsId)
        {
            return await Task.Run(() =>
            {
                var dialogs = new RGDialogsClients().Init();

                var clientsInDialog = new Dictionary<Guid, List<Guid>>();

                foreach (var dialog in dialogs)
                {
                    if (clientsInDialog.ContainsKey(dialog.IDRGDialog) == false)
                    {
                        clientsInDialog.Add(dialog.IDRGDialog, new List<Guid>());
                        clientsInDialog[dialog.IDRGDialog].Add(dialog.IDClient);
                    }
                    else
                    {
                        clientsInDialog[dialog.IDRGDialog].Add(dialog.IDClient);
                    }
                }

                foreach (var clientInDialog in clientsInDialog)
                {
                    var allClientsIdInDialog = clientInDialog.Value.Intersect(clientsId).Count() == clientsId.Length;
                    if (allClientsIdInDialog)
                    {
                        return clientInDialog.Key;
                    }
                }

                return Guid.Empty;
            });
        }
    }
}