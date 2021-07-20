using DPA.Repository;
using DPA.View;
using System.Diagnostics;
using System.Windows.Forms;

namespace DPA.Command
{
    public class OpenWebFileCommand : ICommand
    {
        public void Execute()
        {
            FormCollection fc = Application.OpenForms;
            bool exists = false;
            foreach (Form frm in fc)
            {
                //iterate through
                Debug.WriteLine("form name: " + frm.Name);
                if (frm.Name.Equals("WebFileForm"))
                {
                    exists = true;
                }
            }

            if (exists == false)
            {
                WebFileForm webFileForm = new WebFileForm(SimulationRepository.Instance.GameHandler);
                webFileForm.ShowDialog();
            }

        }
    }
}
