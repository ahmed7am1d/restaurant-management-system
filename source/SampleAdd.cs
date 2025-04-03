using System;
using System.Windows.Forms;

namespace ResturantManagmentSystem
{
    public partial class SampleAdd: Form
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
