// Written by A.Darkins
// Date 13/8/2020
// Issue : Initial
//
// display Parent form with tile,cascade,create and status panel functionality
//

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

        // On button click create new child form
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

        // Cascade all child forms
        private void cascadeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        // Tile all child forms
        private void tileWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        //event for when hild form activated to update status panel
        void ChildForm_Activated(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = ((Form)sender).Text;
        }
    }
}