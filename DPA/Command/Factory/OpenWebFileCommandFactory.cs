namespace DPA.Command.Factory
{
    public class OpenWebFileCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new OpenWebFileCommand();
        }
    }
}
