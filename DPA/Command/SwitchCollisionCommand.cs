using DPA.CollisionDetection;
using DPA.Repository;

namespace DPA.Command
{
    public class SwitchCollisionCommand : ICommand
    {
        public void Execute()
        {
            if (SimulationRepository.Instance.GetCollisionDetector().GetIdentifier() == "QuadTree")
            {
                SimulationRepository.Instance.SetCollisionDetector(new NaiveDetector(SimulationRepository.Instance.GetCollisionDetector().GetObservers(), SimulationRepository.Instance.GetCollisionDetector().GetPreviousColliders(),
                    SimulationRepository.Instance.GetCollisionDetector().GetCurrentColliders()));
            }
            else if (SimulationRepository.Instance.GetCollisionDetector().GetIdentifier() == "Naive")
            {
                SimulationRepository.Instance.SetCollisionDetector(new QuadTreeDetector(SimulationRepository.Instance.GetCollisionDetector().GetObservers(), SimulationRepository.Instance.GetCollisionDetector().GetPreviousColliders(),
                    SimulationRepository.Instance.GetCollisionDetector().GetCurrentColliders()));
            }
        }
    }
}
