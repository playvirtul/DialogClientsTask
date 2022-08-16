namespace DialogClients.Domain
{
    public interface IDialogsService
    {
        Task<Guid> FindDialog(Guid[] clientsId);
    }
}
