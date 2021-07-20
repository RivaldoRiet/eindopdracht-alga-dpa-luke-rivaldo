namespace DPA.Command.Factory
{
    public class AddAsteroidCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new AddAsteroidCommand();
        }
    }
}
