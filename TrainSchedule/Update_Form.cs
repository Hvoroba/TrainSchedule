using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainSchedule
{
    public partial class Update_Form : Form
    {
        internal enum RoutesColumnsIndexes
        {
            TrainName = 1,
            FistStopName,
            LastStopName,
            DepartmentTime,
            ArrivalTime
        }


        public Update_Form()
        {
            InitializeComponent();
        }

        public string TableName { get; set; }
        public string SelectedOption { get; set; }
        public List<string> DGV_row { get; set; }
        public List<string> DGV_header { get; set; }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Change_button_Click(object sender, EventArgs e)
        {

            for (int j = 1; j < NewData_DGV.ColumnCount; j++)
            {
                if (NewData_DGV.Rows[0].Cells[j].Value == null)
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }
            }

            if(SelectedOption == "Update")
            {
                bool isSame = true;
                for(int i = 0; i < NewData_DGV.ColumnCount; i++)
                {
                    if(NewData_DGV.Rows[0].Cells[i].Value.ToString() != DGV_row[i])
                    {
                        isSame = false;
                    }
                }
                if (isSame)
                {
                    MessageBox.Show("Введенное значение не изменилось");
                    return;
                }
            }
            
            if (Configurate.GoodToUpdate(NewData_DGV, TableName, Presenter.GetCurrMaxId(TableName) + 1, SelectedOption))
            {
                switch (TableName)
                {
                    case "Маршруты":
                        Presenter.UpdateTableRoutes(NewData_DGV, SelectedOption);
                        break;
                    case "Поезда":
                        Presenter.UpdateTableTrains(NewData_DGV, SelectedOption);
                        break;
                    case "Остановки":
                        Presenter.UpdateTableStops(NewData_DGV, SelectedOption);
                        break;
                    default:
                        break;
                }
                NewData_DGV.Hide();
                MessageBox.Show("Таблица изменена");
                NewData_DGV.Show();
                Close();
            }
        }

        private void Update_Form_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DGV_row.Count; i++)
            {
                Updatable_DGV.Columns.Add(DGV_header[i], DGV_header[i]);
                NewData_DGV.Columns.Add(DGV_header[i], DGV_header[i]);
            }
            NewData_DGV.Rows.Add();

            switch (SelectedOption)
            {
                case "Update":
                    for (int i = 0; i < DGV_row.Count; i++)
                    {
                        Updatable_DGV.Rows[0].Cells[i].Value = DGV_row[i];
                        NewData_DGV.Rows[0].Cells[i].Value = DGV_row[i];
                    }
                    OperationOption_lbl.Text = "Изменить строку";
                    NewData_DGV.AllowUserToAddRows = false;
                    OperationRun_button.Text = "Изменить";
                    //
                    if (TableName == "Маршруты")
                    {
                        for (int i = 0; i < (int)RoutesColumnsIndexes.DepartmentTime; i++)
                        {
                            if (i == (int)RoutesColumnsIndexes.TrainName)
                            {
                                DataGridViewComboBoxCell CB_cell = new DataGridViewComboBoxCell
                                {
                                    DataSource = Presenter.GetAllNames("SELECT Название FROM Поезда"),
                                    ValueMember = "Name",
                                    DisplayMember = "Name"
                                };
                                NewData_DGV.Rows[0].Cells[i] = CB_cell;
                                NewData_DGV.Rows[0].Cells[i].Value = DGV_row[i];

                            }
                            else if (i == (int)RoutesColumnsIndexes.FistStopName || i == (int)RoutesColumnsIndexes.LastStopName)
                            {
                                DataGridViewComboBoxCell CB_cell = new DataGridViewComboBoxCell
                                {
                                    DataSource = Presenter.GetAllNames("SELECT Название FROM Остановки"),
                                    ValueMember = "Name",
                                    DisplayMember = "Name"
                                };

                                NewData_DGV.Rows[0].Cells[i] = CB_cell;
                                NewData_DGV.Rows[0].Cells[i].Value = DGV_row[i];
                            }
                        }
                    }
                    //
                    break;
                case "Add":
                    Updatable_DGV.Hide();
                    OperationOption_lbl.Hide();
                    OperationOption2_lbl.Text = "Добавить строки";
                    NewData_DGV.Rows.Clear();
                    OperationRun_button.Text = "Добавить";
                    break;
                default:
                    Close();
                    break;
            }

            NewData_DGV.Columns[0].Visible = false;
            NewData_DGV.ReadOnly = false;
            Updatable_DGV.Columns[0].Visible = false;
        }

        private void NewData_DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (TableName == "Маршруты")
            {
                for (int i = 0; i < NewData_DGV.ColumnCount; i++)
                {
                    if (i == (int)RoutesColumnsIndexes.TrainName)
                    {
                        DataGridViewComboBoxCell CB_cell = new DataGridViewComboBoxCell
                        {
                            DataSource = Presenter.GetAllNames("SELECT Название FROM Поезда"),
                            ValueMember = "Name",
                            DisplayMember = "Name"
                        };

                        NewData_DGV.Rows[NewData_DGV.RowCount - 1].Cells[i] = CB_cell;

                    }
                    else if (i == (int)RoutesColumnsIndexes.FistStopName || i == (int)RoutesColumnsIndexes.LastStopName)
                    {
                        DataGridViewComboBoxCell CB_cell = new DataGridViewComboBoxCell
                        {
                            DataSource = Presenter.GetAllNames("SELECT Название FROM Остановки"),
                            ValueMember = "Name",
                            DisplayMember = "Name"
                        };

                        NewData_DGV.Rows[NewData_DGV.RowCount - 1].Cells[i] = CB_cell;

                    }
                }
            }
        }

        private void NewData_DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            OperationRun_button.Show();
        }
    }
}
