using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        TaskManagerLib.TaskManagerLib taskManagerLib = new TaskManagerLib.TaskManagerLib();

        public Form1()
        {
            InitializeComponent();
        }
  
        private void InitGrid()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("ProcessName", "Process Name");
            dataGridView1.Columns.Add("WindowName", "Window Name");
            dataGridView1.Columns.Add("WorkingSet", "Working Set");
            dataGridView1.Columns.Add("VirtualMemory", "Virtual Memory");
            dataGridView1.Columns.Add("BasePriority", "Base Priority");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGrid();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            List<string[]> procs = taskManagerLib.RefreshProcs();
            dataGridView1.Rows.Clear();
            foreach (var proc in procs)
            {
                dataGridView1.Rows.Add(proc);
            }
        }

        //переименовывание
        private void BtnRename_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            taskManagerLib.Rename(name);
            UpdateGrid();

        }

        //сворачивание/разворачивание
        private void BtnCollapse_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            taskManagerLib.Collapse(name);
        }

        private void BtnKill_Click(object sender, EventArgs e)
        {
            int parentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            taskManagerLib.Kill(parentId);
            UpdateGrid();
        }
    }
}

