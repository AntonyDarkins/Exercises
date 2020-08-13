using System;
using System.Windows.Forms;
using System.Linq;

namespace Exercise_2___MDI
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int nextID = 0;
            bool idOK = false;

            while (!idOK)
            {
                idOK = true;
                nextID++;
                foreach (ChildForm child in this.MdiChildren.OfType<ChildForm>())
                {
                    if (child.FormID == nextID)
                        idOK = false;
                }
            }

            var consoleForm = new ChildForm(nextID);
            consoleForm.Activated += ChildForm_Activated;
            consoleForm.MdiParent = this;
            consoleForm.Show();
        }

        private void cascadeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        void ChildForm_Activated(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = ((Form)sender).Text;
        }
    }
}