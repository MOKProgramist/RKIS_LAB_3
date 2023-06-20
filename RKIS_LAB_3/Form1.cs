using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace RKIS_LAB_3
{
    public partial class Form1 : Form
    {
        ModelEF model = new ModelEF();
        public Form1()
        {
            InitializeComponent();
        }

        private void StartLoadData()
        {
            model.Users.Load();
            role_NameComboBox.DataSource = model.Roles.ToList();
            usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }

        private void SaveData()
        {
            try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }

        private void rolesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }
    }
}
