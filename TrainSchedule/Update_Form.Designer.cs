namespace TrainSchedule
{
    partial class Update_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OperationOption_lbl = new System.Windows.Forms.Label();
            this.Updatable_DGV = new System.Windows.Forms.DataGridView();
            this.OperationOption2_lbl = new System.Windows.Forms.Label();
            this.NewData_DGV = new System.Windows.Forms.DataGridView();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.OperationRun_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Updatable_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewData_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // OperationOption_lbl
            // 
            this.OperationOption_lbl.AutoSize = true;
            this.OperationOption_lbl.BackColor = System.Drawing.Color.Transparent;
            this.OperationOption_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperationOption_lbl.ForeColor = System.Drawing.Color.Aquamarine;
            this.OperationOption_lbl.Location = new System.Drawing.Point(12, 9);
            this.OperationOption_lbl.Name = "OperationOption_lbl";
            this.OperationOption_lbl.Size = new System.Drawing.Size(138, 20);
            this.OperationOption_lbl.TabIndex = 2;
            this.OperationOption_lbl.Text = "Изменить строку";
            // 
            // Updatable_DGV
            // 
            this.Updatable_DGV.AllowUserToDeleteRows = false;
            this.Updatable_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Updatable_DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Updatable_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Updatable_DGV.Location = new System.Drawing.Point(12, 32);
            this.Updatable_DGV.Name = "Updatable_DGV";
            this.Updatable_DGV.ReadOnly = true;
            this.Updatable_DGV.RowHeadersVisible = false;
            this.Updatable_DGV.Size = new System.Drawing.Size(776, 100);
            this.Updatable_DGV.TabIndex = 3;
            // 
            // OperationOption2_lbl
            // 
            this.OperationOption2_lbl.AutoSize = true;
            this.OperationOption2_lbl.BackColor = System.Drawing.Color.Transparent;
            this.OperationOption2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperationOption2_lbl.ForeColor = System.Drawing.Color.Aquamarine;
            this.OperationOption2_lbl.Location = new System.Drawing.Point(12, 135);
            this.OperationOption2_lbl.Name = "OperationOption2_lbl";
            this.OperationOption2_lbl.Size = new System.Drawing.Size(30, 20);
            this.OperationOption2_lbl.TabIndex = 4;
            this.OperationOption2_lbl.Text = "На";
            // 
            // NewData_DGV
            // 
            this.NewData_DGV.AllowUserToDeleteRows = false;
            this.NewData_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NewData_DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.NewData_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewData_DGV.Location = new System.Drawing.Point(12, 158);
            this.NewData_DGV.Name = "NewData_DGV";
            this.NewData_DGV.ReadOnly = true;
            this.NewData_DGV.RowHeadersVisible = false;
            this.NewData_DGV.Size = new System.Drawing.Size(776, 100);
            this.NewData_DGV.TabIndex = 5;
            this.NewData_DGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.NewData_DGV_CellBeginEdit);
            this.NewData_DGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.NewData_DGV_RowsAdded);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_button.Location = new System.Drawing.Point(680, 406);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(108, 32);
            this.Cancel_button.TabIndex = 6;
            this.Cancel_button.Text = "Отменить";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // OperationRun_button
            // 
            this.OperationRun_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperationRun_button.Location = new System.Drawing.Point(680, 368);
            this.OperationRun_button.Name = "OperationRun_button";
            this.OperationRun_button.Size = new System.Drawing.Size(108, 32);
            this.OperationRun_button.TabIndex = 7;
            this.OperationRun_button.Text = "Изменить";
            this.OperationRun_button.UseVisualStyleBackColor = true;
            this.OperationRun_button.Visible = false;
            this.OperationRun_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // Update_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TrainSchedule.Properties.Resources.cbbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OperationRun_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.NewData_DGV);
            this.Controls.Add(this.OperationOption2_lbl);
            this.Controls.Add(this.Updatable_DGV);
            this.Controls.Add(this.OperationOption_lbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Update_Form";
            this.Load += new System.EventHandler(this.Update_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Updatable_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewData_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OperationOption_lbl;
        private System.Windows.Forms.DataGridView Updatable_DGV;
        private System.Windows.Forms.Label OperationOption2_lbl;
        private System.Windows.Forms.DataGridView NewData_DGV;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button OperationRun_button;
    }
}