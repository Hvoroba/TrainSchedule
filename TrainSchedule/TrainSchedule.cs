using System;
using System.Windows.Forms;

namespace TrainSchedule
{
    public partial class Form1 : Form
    {
        public int RowToEdit { get; set; }

        internal enum TableNames
        {
            NotSelected = -1,
            Routes = 0,
            Stops,
            Trains
        }

        internal enum OperationOption
        {
            UpdateRoutes = -2,
            None = -1,
            Trains = 0,
            FirstStop,
            LastStop,
            DepartmentTime,
            ArrivalTime
        }

        internal enum CheckListIndexes
        {
            Morning = 0,
            Day,
            Evening
        }

        internal enum RoutesColumnsIndexes
        {
            TrainName = 1,
            FistStopName,
            LastStopName,
            DepartmentTime,
            ArrivalTime
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void SelectTable_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectTable_CB.SelectedIndex == (int)TableNames.NotSelected)
            {
                Select_DGV.Hide();
            }
            else
            {
                Presenter.GetDGV(Select_DGV, SelectTable_CB.Text);
                Select_DGV.Show();
                SearchValue_CB.Hide();
                DayTime_checkList.Hide();
            }

            if(SelectTable_CB.Text == "Маршруты")
            {
                Search_lbl.Show();
                SearchOption_CB.Show();
            } else
            {
                Search_lbl.Hide();
                SearchOption_CB.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Presenter.GetTableNames(SelectTable_CB);
            Presenter.GetTableNames(UpdateTable_CB);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этой программе можно просматривать и редактировать расписание поездов. " + Environment.NewLine + 
                "Для изменения таблицы нажмите на соответствующую строку.");
        }

        private void SearchOption_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchValue_CB.Hide();
            DayTime_checkList.Hide();
            SearchValue_CB.SelectedIndex = -1;
            Presenter.GetDGV(Select_DGV, SelectTable_CB.Text);

            switch (SearchOption_CB.SelectedIndex)
            {
                case (int)OperationOption.None:
                    break;
                case (int)OperationOption.Trains:
                    Configurate.SearchOptionValues(SearchValue_CB, Select_DGV, (int)OperationOption.Trains);
                    SearchValue_CB.Show();
                    break;
                case (int)OperationOption.FirstStop:
                    Configurate.SearchOptionValues(SearchValue_CB, Select_DGV, (int)OperationOption.FirstStop);
                    SearchValue_CB.Show();
                    break;
                case (int)OperationOption.LastStop:
                    Configurate.SearchOptionValues(SearchValue_CB, Select_DGV, (int)OperationOption.LastStop);
                    SearchValue_CB.Show();
                    break;
                case (int)OperationOption.DepartmentTime:
                    DayTime_checkList.Show();
                    break;
                case (int)OperationOption.ArrivalTime:
                    DayTime_checkList.Show();
                    break;
            }
        }

        private void SearchValue_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.GetDGV(Select_DGV, SelectTable_CB.Text, SearchOption_CB.SelectedIndex, SearchValue_CB.Text);
        }

        private void DayTime_checkList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (DayTime_checkList.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
          
        }

        private void DayTime_checkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = "";

            if (DayTime_checkList.CheckedIndices.Contains((int)CheckListIndexes.Morning))
            {
                filterValue += "<= 1100";
            }
            else if (DayTime_checkList.CheckedIndices.Contains((int)CheckListIndexes.Day))
            {
                filterValue += "> 1100 & <= 1800";
            }
            else if (DayTime_checkList.CheckedIndices.Contains((int)CheckListIndexes.Evening))
            {
                filterValue += "> 1800";
            }

            Presenter.GetDGV(Select_DGV, SelectTable_CB.Text, SearchOption_CB.SelectedIndex, filterValue);
        }

        private void UpdateTable_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_button.Hide();
            Update_button.Hide();
            Delete_button.Hide();

            if (UpdateTable_CB.SelectedIndex == (int)TableNames.NotSelected)
            {
                Update_DGV.Hide();
            }
            else
            {
                Presenter.GetDGV(Update_DGV, UpdateTable_CB.Text, (int)OperationOption.UpdateRoutes);
                Update_DGV.Show();
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Presenter.GetDGV(Update_DGV, UpdateTable_CB.Text, (int)OperationOption.UpdateRoutes);
        }

        private void Update_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                RowToEdit = row;
                Update_button.Show();
                Add_button.Show();
                Delete_button.Show();
            } else
            {
                RowToEdit = new int();
                Add_button.Hide();
                Update_button.Hide();
                Delete_button.Hide();
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        { 
            DialogResult DR = new DialogResult();
            DR = MessageBox.Show("Строка будет удалена. Продолжить?", "Внимание!", MessageBoxButtons.OKCancel);

            if(DR == DialogResult.OK)
            {
                Presenter.DeleteRow(UpdateTable_CB.Text, Convert.ToInt32(Update_DGV.Rows[RowToEdit].Cells[0].Value));
                Presenter.GetDGV(Update_DGV, UpdateTable_CB.Text, (int)OperationOption.UpdateRoutes);
                Add_button.Hide();
                Update_button.Hide();
                Delete_button.Hide();
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            Update_button.Hide();
            Delete_button.Hide();
            Add_button.Hide();

            Update_Form UF = Configurate.OptimalView_Form("Update", Update_DGV, RowToEdit, UpdateTable_CB.Text);

            UF.ShowDialog();
            Presenter.GetDGV(Update_DGV, UpdateTable_CB.Text, (int)OperationOption.UpdateRoutes);
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            Update_button.Hide();
            Delete_button.Hide();
            Add_button.Hide();

            Update_Form UF = Configurate.OptimalView_Form("Add", Update_DGV, RowToEdit, UpdateTable_CB.Text);
            
            UF.ShowDialog();
            Presenter.GetDGV(Update_DGV, UpdateTable_CB.Text, (int)OperationOption.UpdateRoutes);
        }

        private void DayTime_checkList_VisibleChanged(object sender, EventArgs e)
        {
            if (DayTime_checkList.Visible == false)
            {
                foreach (int i in DayTime_checkList.CheckedIndices)
                {
                    DayTime_checkList.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void SaveRoutes_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.GetDGV(Select_DGV, "Маршруты");
            Configurate.SaveTableToTxt(Select_DGV, "routes.txt");
        }

        private void SaveTrains_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.GetDGV(Select_DGV, "Поезда");
            Configurate.SaveTableToTxt(Select_DGV, "trains.txt");
            Presenter.GetDGV(Select_DGV, "Маршруты");
        }

        private void SaveStops_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.GetDGV(Select_DGV, "Остановки");
            Configurate.SaveTableToTxt(Select_DGV, "stops.txt");
            Presenter.GetDGV(Select_DGV, "Маршруты");
        }
    }
}