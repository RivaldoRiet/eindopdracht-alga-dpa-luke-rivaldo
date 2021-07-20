namespace DPA.Command.Factory
{
    public class IncreaseSimulationSpeedCommandFactory : ICommandFactory
    {
        public ICommand CreateCommand()
        {
            return new IncreaseSimulationSpeedCommand();
        }
    }
}
