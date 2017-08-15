using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwSpecification
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnObzor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title = "Select exe";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                Path1c.Text = dialog.FileName;
            }
        }

        private void Otmena_Click(object sender, EventArgs e)
        {
            Close();
            
        }
    }
}
