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

        List<Process> processesList = new List<Process>();

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        private struct Windowplacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshProcs()
        {
            dataGridView1.Rows.Clear();
            processesList.Clear();
            int k = 0;
            var allProcess = from pr in Process.GetProcesses(".")
                             orderby pr.Id
                             select pr;
            foreach (var proc in allProcess)
            {
                if (proc.MainWindowHandle != IntPtr.Zero && !String.IsNullOrEmpty(proc.MainWindowTitle.ToString()))
                {
                    string[] arr = { "" + proc.Id, "" + proc.ProcessName, "" + proc.MainWindowTitle,
                    "" + proc.WorkingSet64 /1024/1024 + " MB", "" + proc.VirtualMemorySize64 /1024/1024 + " MB", ""+ proc.BasePriority};
                    dataGridView1.Rows.Add(arr);
                    processesList.Add(proc);
                    k++;
                }
            }
            this.Text = "Number of opened windows: " + k.ToString() + " Number of all processes " + allProcess.Count<Process>().ToString();
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

        private static void KillProcessAndChildren(int pid)
        {
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();

            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshProcs();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGrid();
            RefreshProcs();
        }

        private IntPtr FindhWnd()
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            foreach (var proc in processesList)
            {
                if (proc.ProcessName.Contains(name))
                {
                    return proc.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        //переименовывание
        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindhWnd();
            string name = Interaction.InputBox("Rename window");
            SetWindowText(hWnd, name);
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        //сворачивание/разворачивание
        private void BtnCollapse_Click(object sender, EventArgs e)
        {
            IntPtr wdwIntPtr = FindhWnd();

            Windowplacement placement = new Windowplacement();
            GetWindowPlacement(wdwIntPtr, ref placement);

            if (placement.showCmd == 2)
            {
                ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);
            }
            else
            {
                ShowWindow(wdwIntPtr,ShowWindowEnum.ShowMinimized);
            }

            SetForegroundWindow(wdwIntPtr);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

        private void BtnKill_Click(object sender, EventArgs e)
        {
            int parentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            KillProcessAndChildren(parentId);
        }
    }
}

