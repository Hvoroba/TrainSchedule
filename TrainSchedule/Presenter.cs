using System.Windows.Forms;
using System.Collections.Generic;
using static TrainSchedule.Form1;
using System;
using System.Data;
using System.Linq;

namespace TrainSchedule
{
    class Presenter
    {
        internal static void GetDGV(DataGridView dataTable, string tableName, int filterOption = (int)Form1.OperationOption.None, string filterValue = "")
        {
            dataTable.DataSource = null;

            dataTable.Columns.Clear();
            dataTable.Rows.Clear();

            string query = "SELECT * FROM " + tableName;

            if (tableName == "Маршруты")
            {
                query = "SELECT М._id, П.Название, О1.Название, О2.Название, М.\"Время отправления\", М.\"Время прибытия\" " +
                            "FROM Маршруты AS М " +
                            "INNER JOIN Поезда AS П " +
                            "ON М.Поезд = П._id " +
                            "INNER JOIN Остановки AS О1 " +
                            "ON М.\"Первая остановка\" = О1._id " +
                            "INNER JOIN Остановки AS О2 " +
                            "ON М.\"Конечная остановка\" = О2._id";
            }

            switch (filterOption)
            {
                case (int)Form1.OperationOption.None:
                    break;
                case (int)Form1.OperationOption.Trains:
                    query += " WHERE П.Название = \"" + filterValue + "\"";
                    break;
                case (int)Form1.OperationOption.FirstStop:
                    query += " WHERE О1.Название = \"" + filterValue + "\"";
                    break;
                case (int)Form1.OperationOption.LastStop:
                    query += " WHERE О2.Название = \"" + filterValue + "\"";
                    break;
                case (int)Form1.OperationOption.DepartmentTime:
                    filterValue = Configurate.FilterString(filterValue, " AND М.\"Время отправления\"");
                    query += " WHERE М.\"Время отправления\" " + filterValue;
                    break;
                case (int)Form1.OperationOption.ArrivalTime:
                    filterValue = Configurate.FilterString(filterValue, " AND М.\"Время прибытия\"");
                    query += " WHERE М.\"Время прибытия\" " + filterValue;
                    break;
                default:
                    break;
            }

            Tables tables = Database.Select(query, tableName);

            switch (tableName)
            {
                case "Маршруты":
                    dataTable.DataSource = tables.T_Routes;
                    break;
                case "Поезда":
                    dataTable.DataSource = tables.T_Trains;
                    break;
                case "Остановки":
                    dataTable.DataSource = tables.T_Stops;
                    break;
                default:
                    break;
            }

            Configurate.OptimalView_DGV(dataTable, tableName);
        }

        internal static void GetTableNames(ComboBox CB_ToFill)
        {
            DataSet ds = Database.GetDataSet("SELECT name FROM sqlite_master WHERE type = 'table' AND name <> 'sqlite_sequence' AND name <> 'copied' ORDER BY name");
            CB_ToFill.DisplayMember = "Name";
            CB_ToFill.DataSource = ds.Tables["AllData"];

            ds.Dispose();
        }

        internal static void UpdateTableRoutes(DataGridView DGV_ToUdpate, string selectedOperation)
        {
            int rowCount;

            if (selectedOperation == "Add")
            {
                rowCount = DGV_ToUdpate.RowCount - 1;
            }
            else
            {
                rowCount = DGV_ToUdpate.RowCount;
            }

            TrainsIdToName tbl = Database.SelectIdsAndNames("SELECT _id, Название FROM Поезда");

            for (int i = 0; i < rowCount; i++)
            {
                bool exist = false;
                for (int k = 0; k < tbl._id.Count; k++)
                {
                    if (DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.TrainName].Value.ToString() == tbl.Name[k])
                    {
                        exist = true;
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.TrainName] = cell;
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.TrainName].Value = tbl._id[k];
                    }
                }
                if (!exist)
                {
                    MessageBox.Show("Неудачный ввод", "Ошибка");
                    return;
                }
            }

            tbl = Database.SelectIdsAndNames("SELECT _id, Название FROM Остановки");

            for (int i = 0; i < rowCount; i++)
            {
                bool fistExist = false;
                bool secondExist = false;
                for (int k = 0; k < tbl._id.Count; k++)
                {
                    if (DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.FistStopName].Value.ToString() == tbl.Name[k])
                    {
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.FistStopName] = cell;
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.FistStopName].Value = tbl._id[k];
                        fistExist = true;
                    }

                    if (DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.LastStopName].Value.ToString() == tbl.Name[k])
                    {
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.LastStopName] = cell;
                        DGV_ToUdpate.Rows[i].Cells[(int)RoutesColumnsIndexes.LastStopName].Value = tbl._id[k];
                        secondExist = true;
                    }
                }
                if (!secondExist || !fistExist)
                {
                    MessageBox.Show("Неудачный ввод", "Ошибка");
                    return;
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                RoutesToUpdate routesToUpdate = new RoutesToUpdate()
                {
                    _Id = new int(),
                    Trains_Id = new int(),
                    FirstStop_Id = new int(),
                    LastStop_Id = new int(),
                    DepartmentTime = string.Empty,
                    ArrivalTime = string.Empty
                };
                for (int j = 0; j < DGV_ToUdpate.ColumnCount; j++)
                {
                    routesToUpdate._Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    routesToUpdate.Trains_Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    routesToUpdate.FirstStop_Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    routesToUpdate.LastStop_Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    routesToUpdate.DepartmentTime = DGV_ToUdpate.Rows[i].Cells[j++].Value.ToString();
                    routesToUpdate.ArrivalTime = DGV_ToUdpate.Rows[i].Cells[j].Value.ToString();
                }
                Database.DeleteRow("Маршруты", routesToUpdate._Id);
                Database.UpdateRoutes(routesToUpdate);
            }
        }

        internal static void UpdateTableTrains(DataGridView DGV_ToUdpate, string selectedOperation)
        {
            int rowCount;

            if (selectedOperation == "Add")
            {
                rowCount = DGV_ToUdpate.RowCount - 1;
            }
            else
            {
                rowCount = DGV_ToUdpate.RowCount;
            }

            for (int i = 0; i < rowCount; i++)
            {
                TrainsToUpdate trains = new TrainsToUpdate()
                {
                    _Id = new int(),
                    Name = string.Empty,
                    Capacity = new int()
                };

                for (int j = 0; j < DGV_ToUdpate.ColumnCount; j++)
                {
                    trains._Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    trains.Name = DGV_ToUdpate.Rows[i].Cells[j++].Value.ToString();
                    trains.Capacity = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j].Value);
                }
                Database.DeleteRow("Поезда", trains._Id);
                Database.UpdateTrains(trains);
            }

        }

        internal static void UpdateTableStops(DataGridView DGV_ToUdpate, string selectedOperation)
        {
            int rowCount;

            if (selectedOperation == "Add")
            {
                rowCount = DGV_ToUdpate.RowCount - 1;
            }
            else
            {
                rowCount = DGV_ToUdpate.RowCount;
            }

            for (int i = 0; i < rowCount; i++)
            {
                StopsToUpdate stops = new StopsToUpdate()
                {
                    _Id = new int(),
                    Name = string.Empty
                };

                for (int j = 0; j < DGV_ToUdpate.ColumnCount; j++)
                {
                    stops._Id = Convert.ToInt32(DGV_ToUdpate.Rows[i].Cells[j++].Value);
                    stops.Name = DGV_ToUdpate.Rows[i].Cells[j].Value.ToString();
                }
                Database.DeleteRow("Остановки", stops._Id);
                Database.UpdateStops(stops);

            }
        }

        internal static int GetCurrMaxId(string tableName)
        {
            List<int> idList = Database.SelectAllIds("SELECT _id FROM " + tableName);
            return idList.Max();
        }

        internal static void DeleteRow(string tableName, int id)
        {
            Database.DeleteRow(tableName, id);
        }

        internal static DataTable GetAllNames(string query)
        {
            List<string> namesList = Database.SellectAllNames(query);
            DataTable DT = new DataTable();

            DT.Columns.Add("Name");
            
            for(int i = 0; i < namesList.Count; i++)
            {
                DT.Rows.Add(namesList[i]);
            }

            return DT;
        }
    }
}