using DPA.Repository;

namespace DPA.Command
{
    public class RewindCommand : ICommand
    {
        public void Execute()
        {
            if (SimulationRepository.Instance.IsRunning())
            {
                //zet de huidige lijst van objecten naar de lijst van de undo
                CelestialObjectRepository.Instance.SetCelestialObjectList(SimulationRepository.Instance.GetCareTaker().Undo().CelestialObjects);
            }
        }
    }
}
