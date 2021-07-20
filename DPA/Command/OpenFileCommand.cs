using DPA.Repository;
using System;
using System.IO;
using System.Windows.Forms;

namespace DPA.Command
{
    public class OpenFileCommand : ICommand
    {
        public void Execute()
        {
            FlatGalaxy flatGalaxy = new FlatGalaxy();
            string file = "";
            bool isXML = false;
            bool isWebFile = false;

            flatGalaxy.GetOpenFileDialog1().FileName = "";
            flatGalaxy.GetOpenFileDialog1().Title = "Open a galaxy File...";
            if (flatGalaxy.GetOpenFileDialog1().ShowDialog() == DialogResult.OK)
            {
                file = flatGalaxy.GetOpenFileDialog1().FileName;
                string ext = Path.GetExtension(flatGalaxy.GetOpenFileDialog1().FileName);
                if (ext != null && ext.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0 || ext.IndexOf("csv", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isXML = ext.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (SimulationRepository.Instance.GameHandler.Initialize(file, isXML, isWebFile))
                    {
                        SimulationRepository.Instance.SetIsRunning(true);
                    }
                }
                else
                {
                    MessageBox.Show("Error", "Could not load file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
