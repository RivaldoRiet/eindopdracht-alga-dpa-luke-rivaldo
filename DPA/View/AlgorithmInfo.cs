using DPA.Repository;
using System;
using System.Windows.Forms;

namespace DPA.View
{
    public partial class AlgorithmInfo : Form
    {
        public AlgorithmInfo()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 100;
            timer1.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateAlgData()
        {
            if (!string.IsNullOrEmpty(SimulationRepository.Instance.BreadthFirstSearchData))
            {
                label2.Text = SimulationRepository.Instance.BreadthFirstSearchData;
            }
            else
            {
                label2.Text = "NULL";
            }

            if (!string.IsNullOrEmpty(SimulationRepository.Instance.DijkstraData))
            {
                label4.Text = SimulationRepository.Instance.DijkstraData;
            }
            else
            {
                label4.Text = "NULL";
            }
        }
        private void AlgorithmInfo_Load(object sender, EventArgs e)
        {
            UpdateAlgData();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateAlgData();
        }
    }
}
