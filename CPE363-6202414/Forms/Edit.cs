using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE363_6202414.Forms
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.appData.Table);
            EditDB(false);

        }

        private void EditDB(bool value)
        {
            txtCollection.Enabled = value;
            txtEmail.Enabled = value;   
            txtName.Enabled = value;    
            txtOpenseaURL.Enabled = value;  
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                EditDB(true);
                appData.Table.AddTableRow(appData.Table.NewTableRow());
                tableBindingSource.MoveLast();
                txtCollection.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                appData.Table.RejectChanges();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditDB(true);
            txtCollection.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EditDB(false);
            tableBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EditDB(false);
                tableBindingSource.EndEdit();
                tableTableAdapter.Update(appData.Table);
                dataGridView1.Refresh();
                txtCollection.Focus();
                MessageBox.Show("You data has been successfully saved.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                appData.Table.RejectChanges();
            }
        }

        

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tableBindingSource.RemoveCurrent();
                }
            }
        }
    }
}
