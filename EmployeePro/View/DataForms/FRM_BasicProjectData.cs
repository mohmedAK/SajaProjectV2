using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SagaProjectV2.View.DataForms
{
    public partial class FRM_BasicProjectData : DevExpress.XtraEditors.XtraForm
    {
        public FRM_BasicProjectData()
        {
            InitializeComponent();
        }

        private void sbNewProject_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_GeniralProjectInformation fRM_GeniralProjectInformation = new FRM_GeniralProjectInformation();
            fRM_GeniralProjectInformation.Show();
        }
    }
}