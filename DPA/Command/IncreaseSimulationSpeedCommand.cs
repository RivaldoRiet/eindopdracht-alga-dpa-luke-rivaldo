using DPA.Repository;

namespace DPA.Command
{
    public class IncreaseSimulationSpeedCommand : ICommand
    {
        private readonly int speedIncrease = 1;
        public void Execute()
        {
            int newTickTime = SimulationRepository.Instance.GetTickTime() - speedIncrease;
            if (SimulationRepository.Instance.GetTickTime() > 1)
            {
                SimulationRepository.Instance.SetTickTime(newTickTime);
            }
        }
    }
}
