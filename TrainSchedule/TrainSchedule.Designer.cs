namespace TrainSchedule
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Select = new System.Windows.Forms.TabPage();
            this.DayTime_checkList = new System.Windows.Forms.CheckedListBox();
            this.SearchValue_CB = new System.Windows.Forms.ComboBox();
            this.SearchOption_CB = new System.Windows.Forms.ComboBox();
            this.Search_lbl = new System.Windows.Forms.Label();
            this.SelectTable_lbl = new System.Windows.Forms.Label();
            this.SelectTable_CB = new System.Windows.Forms.ComboBox();
            this.Trains_lbl = new System.Windows.Forms.Label();
            this.Select_DGV = new System.Windows.Forms.DataGridView();
            this.Change = new System.Windows.Forms.TabPage();
            this.Add_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            this.Update_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateTable_CB = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveRoutes_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTrains_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveStops_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.Select.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Select_DGV)).BeginInit();
            this.Change.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Update_DGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Select);
            this.TabControl.Controls.Add(this.Change);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 24);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(950, 504);
            this.TabControl.TabIndex = 0;
            // 
            // Select
            // 
            this.Select.BackgroundImage = global::TrainSchedule.Properties.Resources.bg;
            this.Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Select.Controls.Add(this.DayTime_checkList);
            this.Select.Controls.Add(this.SearchValue_CB);
            this.Select.Controls.Add(this.SearchOption_CB);
            this.Select.Controls.Add(this.Search_lbl);
            this.Select.Controls.Add(this.SelectTable_lbl);
            this.Select.Controls.Add(this.SelectTable_CB);
            this.Select.Controls.Add(this.Trains_lbl);
            this.Select.Controls.Add(this.Select_DGV);
            this.Select.Location = new System.Drawing.Point(4, 22);
            this.Select.Name = "Select";
            this.Select.Padding = new System.Windows.Forms.Padding(3);
            this.Select.Size = new System.Drawing.Size(942, 478);
            this.Select.TabIndex = 0;
            this.Select.Text = "Просмотр";
            this.Select.UseVisualStyleBackColor = true;
            // 
            // DayTime_checkList
            // 
            this.DayTime_checkList.BackColor = System.Drawing.Color.AliceBlue;
            this.DayTime_checkList.CheckOnClick = true;
            this.DayTime_checkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayTime_checkList.FormattingEnabled = true;
            this.DayTime_checkList.Items.AddRange(new object[] {
            "Утром",
            "Днём",
            "Вечером"});
            this.DayTime_checkList.Location = new System.Drawing.Point(797, 6);
            this.DayTime_checkList.Name = "DayTime_checkList";
            this.DayTime_checkList.Size = new System.Drawing.Size(92, 67);
            this.DayTime_checkList.TabIndex = 10;
            this.DayTime_checkList.Visible = false;
            this.DayTime_checkList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.DayTime_checkList_ItemCheck);
            this.DayTime_checkList.SelectedIndexChanged += new System.EventHandler(this.DayTime_checkList_SelectedIndexChanged);
            this.DayTime_checkList.VisibleChanged += new System.EventHandler(this.DayTime_checkList_VisibleChanged);
            // 
            // SearchValue_CB
            // 
            this.SearchValue_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchValue_CB.FormattingEnabled = true;
            this.SearchValue_CB.Location = new System.Drawing.Point(613, 42);
            this.SearchValue_CB.Name = "SearchValue_CB";
            this.SearchValue_CB.Size = new System.Drawing.Size(146, 21);
            this.SearchValue_CB.TabIndex = 9;
            this.SearchValue_CB.Visible = false;
            this.SearchValue_CB.SelectedIndexChanged += new System.EventHandler(this.SearchValue_CB_SelectedIndexChanged);
            // 
            // SearchOption_CB
            // 
            this.SearchOption_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchOption_CB.FormattingEnabled = true;
            this.SearchOption_CB.Items.AddRange(new object[] {
            "Поездам",
            "Начальной остановке",
            "Конечной остановке",
            "Времени отправления",
            "Времени завершения маршрута"});
            this.SearchOption_CB.Location = new System.Drawing.Point(412, 42);
            this.SearchOption_CB.Name = "SearchOption_CB";
            this.SearchOption_CB.Size = new System.Drawing.Size(176, 21);
            this.SearchOption_CB.TabIndex = 8;
            this.SearchOption_CB.Visible = false;
            this.SearchOption_CB.SelectedIndexChanged += new System.EventHandler(this.SearchOption_CB_SelectedIndexChanged);
            // 
            // Search_lbl
            // 
            this.Search_lbl.AutoSize = true;
            this.Search_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search_lbl.Location = new System.Drawing.Point(316, 40);
            this.Search_lbl.Name = "Search_lbl";
            this.Search_lbl.Size = new System.Drawing.Size(77, 20);
            this.Search_lbl.TabIndex = 7;
            this.Search_lbl.Text = "Поиск по";
            this.Search_lbl.Visible = false;
            // 
            // SelectTable_lbl
            // 
            this.SelectTable_lbl.AutoSize = true;
            this.SelectTable_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTable_lbl.Location = new System.Drawing.Point(8, 40);
            this.SelectTable_lbl.Name = "SelectTable_lbl";
            this.SelectTable_lbl.Size = new System.Drawing.Size(148, 20);
            this.SelectTable_lbl.TabIndex = 6;
            this.SelectTable_lbl.Text = "Показать таблицу";
            this.SelectTable_lbl.Visible = false;
            // 
            // SelectTable_CB
            // 
            this.SelectTable_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectTable_CB.FormattingEnabled = true;
            this.SelectTable_CB.Location = new System.Drawing.Point(162, 42);
            this.SelectTable_CB.Name = "SelectTable_CB";
            this.SelectTable_CB.Size = new System.Drawing.Size(121, 21);
            this.SelectTable_CB.TabIndex = 5;
            this.SelectTable_CB.Visible = false;
            this.SelectTable_CB.SelectedIndexChanged += new System.EventHandler(this.SelectTable_CB_SelectedIndexChanged);
            // 
            // Trains_lbl
            // 
            this.Trains_lbl.AutoSize = true;
            this.Trains_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Trains_lbl.Location = new System.Drawing.Point(4, 61);
            this.Trains_lbl.Name = "Trains_lbl";
            this.Trains_lbl.Size = new System.Drawing.Size(0, 20);
            this.Trains_lbl.TabIndex = 4;
            this.Trains_lbl.Visible = false;
            // 
            // Select_DGV
            // 
            this.Select_DGV.AllowUserToAddRows = false;
            this.Select_DGV.AllowUserToDeleteRows = false;
            this.Select_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Select_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Select_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Select_DGV.Location = new System.Drawing.Point(3, 76);
            this.Select_DGV.Name = "Select_DGV";
            this.Select_DGV.ReadOnly = true;
            this.Select_DGV.Size = new System.Drawing.Size(936, 399);
            this.Select_DGV.TabIndex = 0;
            // 
            // Change
            // 
            this.Change.BackgroundImage = global::TrainSchedule.Properties.Resources.bg;
            this.Change.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Change.Controls.Add(this.Add_button);
            this.Change.Controls.Add(this.Delete_button);
            this.Change.Controls.Add(this.Update_button);
            this.Change.Controls.Add(this.Update_DGV);
            this.Change.Controls.Add(this.label1);
            this.Change.Controls.Add(this.UpdateTable_CB);
            this.Change.Location = new System.Drawing.Point(4, 22);
            this.Change.Name = "Change";
            this.Change.Padding = new System.Windows.Forms.Padding(3);
            this.Change.Size = new System.Drawing.Size(942, 478);
            this.Change.TabIndex = 1;
            this.Change.Text = "Изменение";
            this.Change.UseVisualStyleBackColor = true;
            // 
            // Add_button
            // 
            this.Add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_button.Location = new System.Drawing.Point(826, 26);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(108, 32);
            this.Add_button.TabIndex = 11;
            this.Add_button.Text = "Добавить";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_button.Location = new System.Drawing.Point(598, 26);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(108, 32);
            this.Delete_button.TabIndex = 10;
            this.Delete_button.Text = "Удалить";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Visible = false;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Update_button
            // 
            this.Update_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Update_button.Location = new System.Drawing.Point(712, 26);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(108, 32);
            this.Update_button.TabIndex = 9;
            this.Update_button.Text = "Изменить";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Visible = false;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // Update_DGV
            // 
            this.Update_DGV.AllowUserToDeleteRows = false;
            this.Update_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Update_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Update_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Update_DGV.Location = new System.Drawing.Point(3, 67);
            this.Update_DGV.Name = "Update_DGV";
            this.Update_DGV.ReadOnly = true;
            this.Update_DGV.RowHeadersVisible = false;
            this.Update_DGV.Size = new System.Drawing.Size(936, 408);
            this.Update_DGV.TabIndex = 2;
            this.Update_DGV.Visible = false;
            this.Update_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Update_DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Изменить таблицу";
            // 
            // UpdateTable_CB
            // 
            this.UpdateTable_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateTable_CB.FormattingEnabled = true;
            this.UpdateTable_CB.Location = new System.Drawing.Point(164, 40);
            this.UpdateTable_CB.Name = "UpdateTable_CB";
            this.UpdateTable_CB.Size = new System.Drawing.Size(121, 21);
            this.UpdateTable_CB.TabIndex = 0;
            this.UpdateTable_CB.SelectedIndexChanged += new System.EventHandler(this.UpdateTable_CB_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveRoutes_ToolStripMenuItem,
            this.SaveTrains_ToolStripMenuItem,
            this.SaveStops_ToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // SaveRoutes_ToolStripMenuItem
            // 
            this.SaveRoutes_ToolStripMenuItem.Name = "SaveRoutes_ToolStripMenuItem";
            this.SaveRoutes_ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveRoutes_ToolStripMenuItem.Text = "Сохранить маршруты";
            this.SaveRoutes_ToolStripMenuItem.Click += new System.EventHandler(this.SaveRoutes_ToolStripMenuItem_Click);
            // 
            // SaveTrains_ToolStripMenuItem
            // 
            this.SaveTrains_ToolStripMenuItem.Name = "SaveTrains_ToolStripMenuItem";
            this.SaveTrains_ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveTrains_ToolStripMenuItem.Text = "Сохранить поезда";
            this.SaveTrains_ToolStripMenuItem.Click += new System.EventHandler(this.SaveTrains_ToolStripMenuItem_Click);
            // 
            // SaveStops_ToolStripMenuItem
            // 
            this.SaveStops_ToolStripMenuItem.Name = "SaveStops_ToolStripMenuItem";
            this.SaveStops_ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveStops_ToolStripMenuItem.Text = "Сохранить остановки";
            this.SaveStops_ToolStripMenuItem.Click += new System.EventHandler(this.SaveStops_ToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.AboutToolStripMenuItem.Text = "Справка";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 528);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.Select.ResumeLayout(false);
            this.Select.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Select_DGV)).EndInit();
            this.Change.ResumeLayout(false);
            this.Change.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Update_DGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private new System.Windows.Forms.TabPage Select;
        private System.Windows.Forms.TabPage Change;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView Select_DGV;
        private System.Windows.Forms.Label Trains_lbl;
        private System.Windows.Forms.DataGridView Update_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UpdateTable_CB;
        private System.Windows.Forms.Label SelectTable_lbl;
        private System.Windows.Forms.ComboBox SelectTable_CB;
        private System.Windows.Forms.ComboBox SearchOption_CB;
        private System.Windows.Forms.Label Search_lbl;
        private System.Windows.Forms.ComboBox SearchValue_CB;
        private System.Windows.Forms.CheckedListBox DayTime_checkList;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.ToolStripMenuItem SaveRoutes_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveTrains_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveStops_ToolStripMenuItem;
    }
}

