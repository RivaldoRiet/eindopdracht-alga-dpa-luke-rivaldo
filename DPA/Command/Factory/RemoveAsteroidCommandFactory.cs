namespace DPA.Command.Factory
{
    public class RemoveAsteroidCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new RemoveAsteroidCommand();
        }
    }
}
