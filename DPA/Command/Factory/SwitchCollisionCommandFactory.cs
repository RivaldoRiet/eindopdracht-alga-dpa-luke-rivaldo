namespace DPA.Command.Factory
{
    public class SwitchCollisionCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new SwitchCollisionCommand();
        }
    }
}
