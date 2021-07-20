using DPA.Controller;
using DPA.Repository;
using DPA.View;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DPA
{

    public partial class FlatGalaxy : Form
    {

        private readonly GameHandler gameHandler;
        private readonly int _rewindTime = 5000;
        //private int _tickTime = 50;
        private readonly int _ticks;


        public FlatGalaxy()
        {
            InitializeComponent();
            gameHandler = SimulationRepository.Instance.GameHandler;

            _ticks = (_rewindTime / SimulationRepository.Instance.GetTickTime());
            KeyDown += new System.Windows.Forms.KeyEventHandler(FlatGalaxy_KeyDown);

            //onze default key om te rewinden in het spel
            KeyDataRepository.Instance.Rewindkey = Keys.Back;
            SimulationRepository.Instance.SetIsRunning(false);
        }


        private void rewindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameHandler.Undo();
        }

        private void OpenKeybindsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeybindForm keybindForm = new KeybindForm();
            keybindForm.ShowDialog();
        }

        private void FlatGalaxy_KeyDown(object sender, KeyEventArgs e)
        {
            //heeft een nieuwe key
            if (e.KeyCode.ToString().Equals(KeyDataRepository.Instance.Rewindkey.ToString()))
            {
                gameHandler.Undo();
            }
        }

        private void PauzeerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CelestialObjectRepository.Instance.GetCelestialObjectList() != null && CelestialObjectRepository.Instance.GetCelestialObjectList().Count > 0)
            {
                SimulationRepository.Instance.SetIsRunning(!SimulationRepository.Instance.IsRunning());
                if (SimulationRepository.Instance.IsRunning())
                {
                    pauzeerToolStripMenuItem.Text = "Simulatie pauzeren";
                }
                else
                {
                    pauzeerToolStripMenuItem.Text = "Simulatie starten";
                }
            }
        }

        private void FlatGalaxy_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = SimulationRepository.Instance.dijkstraActive;
            disableBreadthFirstSearchToolStripMenuItem.Checked = SimulationRepository.Instance.bfsActive;
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());
            SimulationRepository.Instance.SetTickTime(trackBar1.Value);
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void GalaxyCanvas1_Load(object sender, EventArgs e)
        {

        }

        private void LocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = "";
            bool isXML = false;
            bool isWebFile = false;

            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open a galaxy File...";
            if (GetOpenFileDialog1().ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                string ext = Path.GetExtension(openFileDialog1.FileName);
                if (ext != null && ext.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0 || ext.IndexOf("csv", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isXML = ext.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (gameHandler.Initialize(file, isXML, isWebFile))
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

        public OpenFileDialog GetOpenFileDialog1()
        {
            return openFileDialog1;
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void WebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebFileForm webFileForm = new WebFileForm(gameHandler);
            webFileForm.ShowDialog();
        }

        private void AlgorithmInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgorithmInfo algorithmInfo = new AlgorithmInfo();
            algorithmInfo.ShowDialog();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SimulationRepository.Instance.dijkstraActive)
            {
                toolStripMenuItem1.Checked = false;
                SimulationRepository.Instance.dijkstraActive = false;
            }
            else
            {
                toolStripMenuItem1.Checked = true;
                SimulationRepository.Instance.dijkstraActive = true;
            }

        }

        private void DisableBreadthFirstSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SimulationRepository.Instance.bfsActive)
            {
                disableBreadthFirstSearchToolStripMenuItem.Checked = false;
                SimulationRepository.Instance.bfsActive = false;
            }
            else
            {
                disableBreadthFirstSearchToolStripMenuItem.Checked = true;
                SimulationRepository.Instance.bfsActive = true;
            }
        }
    }
}
