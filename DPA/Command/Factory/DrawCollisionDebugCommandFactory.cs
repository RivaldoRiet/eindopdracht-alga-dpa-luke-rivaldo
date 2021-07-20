namespace DPA.Command.Factory
{
    public class DrawCollisionDebugCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new DrawCollisionDebugCommand();
        }
    }
}
