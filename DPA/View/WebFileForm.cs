using DPA.Controller;
using DPA.Repository;
using System;
using System.Windows.Forms;

namespace DPA.View
{
    public partial class WebFileForm : Form
    {
        private readonly GameHandler _gameHandler;

        public WebFileForm(GameHandler gameHandler)
        {
            InitializeComponent();
            _gameHandler = gameHandler;
        }



        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {


            string url = textBox1.Text;
            bool urlValid = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (urlValid)
            {

                if (checkBox1.Checked)
                {
                    if (_gameHandler.Initialize(textBox1.Text, true, true))
                    {
                        SimulationRepository.Instance.SetIsRunning(true);
                    }
                }
                else
                {
                    if (_gameHandler.Initialize(textBox1.Text, false, true))
                    {
                        SimulationRepository.Instance.SetIsRunning(true);
                    }
                }

                Close();
            }
            else
            {
                MessageBox.Show("Error", "Invalid url",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
