using DPA.Repository;

namespace DPA.Command
{
    public class DecreaseSimulationSpeedCommand : ICommand
    {
        private readonly int speedDecrease = 1;
        public void Execute()
        {
            int newTickTime = SimulationRepository.Instance.GetTickTime() + speedDecrease;
            if (SimulationRepository.Instance.GetTickTime() < 100)
            {
                SimulationRepository.Instance.SetTickTime(newTickTime);
            }
        }
    }
}
