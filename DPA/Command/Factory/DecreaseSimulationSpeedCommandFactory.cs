namespace DPA.Command.Factory
{
    public class DecreaseSimulationSpeedCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new DecreaseSimulationSpeedCommand();
        }
    }
}
