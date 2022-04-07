namespace TaskManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnRename = new System.Windows.Forms.Button();
            this.BtnCollapse = new System.Windows.Forms.Button();
            this.BtnKill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(12, 7);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(643, 402);
            this.dataGridView1.TabIndex = 2;
            // 
            // BtnRename
            // 
            this.BtnRename.Location = new System.Drawing.Point(94, 7);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(75, 23);
            this.BtnRename.TabIndex = 3;
            this.BtnRename.Text = "Rename";
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnCollapse
            // 
            this.BtnCollapse.Location = new System.Drawing.Point(176, 7);
            this.BtnCollapse.Name = "BtnCollapse";
            this.BtnCollapse.Size = new System.Drawing.Size(75, 23);
            this.BtnCollapse.TabIndex = 4;
            this.BtnCollapse.Text = "Collapse";
            this.BtnCollapse.UseVisualStyleBackColor = true;
            this.BtnCollapse.Click += new System.EventHandler(this.BtnCollapse_Click);
            // 
            // BtnKill
            // 
            this.BtnKill.BackColor = System.Drawing.SystemColors.Control;
            this.BtnKill.Location = new System.Drawing.Point(258, 7);
            this.BtnKill.Name = "BtnKill";
            this.BtnKill.Size = new System.Drawing.Size(37, 23);
            this.BtnKill.TabIndex = 5;
            this.BtnKill.Text = "Kill";
            this.BtnKill.UseVisualStyleBackColor = false;
            this.BtnKill.Click += new System.EventHandler(this.BtnKill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 450);
            this.Controls.Add(this.BtnKill);
            this.Controls.Add(this.BtnCollapse);
            this.Controls.Add(this.BtnRename);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnRefresh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnRename;
        private System.Windows.Forms.Button BtnCollapse;
        private System.Windows.Forms.Button BtnKill;
    }
}

