﻿using SEP_Framework.FrameWork.Controllers;
using SEP_Framework.FrameWork.Factory;
using SEP_Framework.Views.BaseFormPkg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP_Framework.View
{
    public partial class HomeForm : Form
    {
        public SQLServerController controller;
        FormFactory formFactory = new FormFactory();
        string cnnString = @"Data Source=MAYTINH-HE52SNT;Initial Catalog=FootballPlayer;Integrated Security=True";
        public HomeForm()
        {
            InitializeComponent();
            controller = new SQLServerController(cnnString);
            List<string> tablenames;
            tablenames=controller.getAllTableName("FootballPlayer");
            this.tableDropdown.Items = tablenames.ToArray();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void showDataButton_Click(object sender, EventArgs e)
        {
            if(tableDropdown.selectedIndex != -1)
            {
                BaseForm readForm = formFactory.getForm(typeForm.READ, controller, tableDropdown.selectedValue, null);
                readForm.ShowForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bảng dữ liệu");
            }
            
            
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            if (tableDropdown.selectedIndex != -1)
            {
                BaseForm addForm = formFactory.getForm(typeForm.ADD, controller, tableDropdown.selectedValue, null);
                addForm.ShowForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bảng dữ liệu");
            }
        }

        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (tableDropdown.selectedIndex != -1)
            {
                BaseForm updateForm = formFactory.getForm(typeForm.UPDATE, controller, tableDropdown.selectedValue, null);
                updateForm.ShowForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bảng dữ liệu");
            }
        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            if (tableDropdown.selectedIndex != -1)
            {
                BaseForm deleteForm = formFactory.getForm(typeForm.DELETE, controller, tableDropdown.selectedValue, null);
                deleteForm.ShowForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bảng dữ liệu");
            }
        }
    }
}
