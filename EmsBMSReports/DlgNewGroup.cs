using System;
using System.Windows.Forms;

namespace EmsBMSReports
{

    public partial class DlgNewGroup
    {
        public DlgNewGroup()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            int localGetGroupID() { string argsGroupName = tGroupName.Text; var ret = MactusReportLib.MactusReportLib.GetGroupID(ref argsGroupName); tGroupName.Text = argsGroupName; return ret; }

            if (localGetGroupID() > 0)
            {
                MessageBox.Show("Group Name Already Exist.", "Add NEw Data Trend Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string argsGroupName = tGroupName.Text;
                MactusReportLib.MactusReportLib.AddNewDataTrendGroup(ref argsGroupName);
                tGroupName.Text = argsGroupName;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tGroupName_TextChanged(object sender, EventArgs e)
        {
            if (tGroupName.Text.Length <= 2)
            {
                OK_Button.Enabled = false;
            }
            else
            {
                OK_Button.Enabled = true;
            }
        }
    }
}