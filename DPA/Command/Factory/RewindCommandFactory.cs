namespace DPA.Command.Factory
{
    public class RewindCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new RewindCommand();
        }
    }
}
