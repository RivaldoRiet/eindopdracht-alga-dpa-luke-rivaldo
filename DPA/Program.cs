using DPA.Controller;
using DPA.Repository;
using System;
using System.Windows.Forms;

namespace DPA
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            GameHandler _gameHandler = new GameHandler();
            SimulationRepository.Instance.GameHandler = _gameHandler;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FlatGalaxy());
        }
    }
}
