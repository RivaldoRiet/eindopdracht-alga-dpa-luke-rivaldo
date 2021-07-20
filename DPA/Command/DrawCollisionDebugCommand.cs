using DPA.Repository;

namespace DPA.Command
{
    public class DrawCollisionDebugCommand : ICommand
    {
        public void Execute()
        {
            SimulationRepository.Instance.SetDrawCollisionDebug(!SimulationRepository.Instance.GetDrawCollisionDebug());
        }
    }
}
