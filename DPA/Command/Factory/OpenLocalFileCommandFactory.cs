namespace DPA.Command.Factory
{
    public class OpenLocalFileCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new OpenFileCommand();
        }
    }
}
