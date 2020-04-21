using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static TrainSchedule.Form1;
using System;

namespace TrainSchedule
{
    class Configurate
    {
        internal static void SearchOptionValues(ComboBox Values_CB, DataGridView Searchable_DGV, int columnIndex)
        {
            Values_CB.Items.Clear();
            List<string> values = new List<string>();
            for (int i = 0; i < Searchable_DGV.RowCount; i++)
            {
                values.Add(Searchable_DGV.Rows[i].Cells[columnIndex+1].Value.ToString());
            }

            values = values.Distinct().ToList();
            for(int i = 0; i < values.Count; i++)
            {
                Values_CB.Items.Add(values[i]);
            }
        }

        internal static string FilterString(string filterString, string filterOption)
        {
            if (filterString.Contains('&'))
            {
                int index = filterString.IndexOf('&');
                filterString = filterString.Remove(index, 1);
                filterString = filterString.Insert(index-1, filterOption);
            }

            return filterString;
        }

        internal static void OptimalView_DGV(DataGridView DGV_ToDisplay, string tabelName)
        {
            DGV_ToDisplay.RowHeadersVisible = false;
            DGV_ToDisplay.Columns[0].Visible = false;

            switch(tabelName)
            {
                case "Маршруты":
                    DGV_ToDisplay.Columns[1].HeaderText = "Поезд";
                    DGV_ToDisplay.Columns[2].HeaderText = "Первая остановка";
                    DGV_ToDisplay.Columns[3].HeaderText = "Конечная остановка";
                    DGV_ToDisplay.Columns[4].HeaderText = "Время отправления";
                    DGV_ToDisplay.Columns[5].HeaderText = "Время прибытия";
                    break;
                case "Поезда":
                    DGV_ToDisplay.Columns[1].HeaderText = "Название";
                    DGV_ToDisplay.Columns[2].HeaderText = "Вместимость";
                    break;
                case "Остановки":
                    DGV_ToDisplay.Columns[1].HeaderText = "Название";
                    break;
                default:
                    break;
            }
        }

        internal static bool GoodToUpdate(DataGridView Update_DGV, string tableName, int nextMaxIndex, string selectedOperation)
        {
            int rowCount;

            if (selectedOperation == "Add")
            {
                rowCount = Update_DGV.RowCount - 1;
            } else
            {
                rowCount = Update_DGV.RowCount;
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (Update_DGV.Rows[i].Cells[0].Value == null)
                {
                    Update_DGV.Rows[i].Cells[0].Value = nextMaxIndex;
                    nextMaxIndex++;
                }
            }


            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < Update_DGV.ColumnCount; j++)
                {
                    if (Update_DGV.Rows[i].Cells[j].Value == null)
                    {
                        MessageBox.Show("Заполните пустые поля", "Ошибка!");
                        return false;
                    }
                }
            }

            if (tableName == "Маршруты")
            {
                for(int i = 0; i < Update_DGV.RowCount-1; i++)
                {
                    for(int j = (int)RoutesColumnsIndexes.DepartmentTime; j <= (int)RoutesColumnsIndexes.ArrivalTime; j++)
                    {
                        string value = Update_DGV.Rows[i].Cells[j].Value.ToString();
                        if (value.Length != 5)
                        {
                            MessageBox.Show("Некорректный ввод времени." + Environment.NewLine + "Верный формат: 00:00");
                            return false;
                        }
                        if (value[2] != ':')
                        {
                            MessageBox.Show("Некорректный ввод времени." + Environment.NewLine + "Верный формат: 00:00");
                            return false;
                        }
                        value = value.Remove(2, 1);//12:00 --> 1200
                        string hours = value.Remove(2, 2); //1200 -->12
                        string minutes = value.Remove(0, 2); //1200 -->00
                        int.TryParse(hours, out int h);
                        int.TryParse(minutes, out int m);
                        if (h < 0 || h >= 24 || (h == 0 && hours != "00"))
                        {
                            MessageBox.Show("Некорректный ввод времени." + Environment.NewLine + "Верный формат: 00:00");
                            return false;
                        }
                        if (m < 0 || m >= 60 || (m == 0 && minutes != "00"))
                        {
                            MessageBox.Show("Некорректный ввод времени." + Environment.NewLine + "Верный формат: 00:00");
                            return false;
                        }
                    }
                }
            }

            if(tableName == "Поезда")
            {
                for (int i = 0; i < rowCount; i++) {

                    Int32.TryParse(Update_DGV.Rows[i].Cells[(int)TableNames.Trains].Value.ToString(), out int num);

                    if (Update_DGV.Rows[i].Cells[(int)TableNames.Trains].Value.ToString() != "0" && num == 0 || num < 0)
                    {
                        MessageBox.Show("Некорректный ввод вместимости", "Ошибка!");
                        return false;
                    }
                }
            }

            return true;
        }

        internal static Update_Form OptimalView_Form (string operationOption, DataGridView Update_DGV, int rowToEdit, string tableName)
        {
            Update_Form UF = new Update_Form()
            {
                DGV_row = new List<string>(),
                DGV_header = new List<string>(),
                TableName = string.Empty,
                SelectedOption = operationOption
            };

            UF.TableName = tableName;

            for (int i = 0; i < Update_DGV.ColumnCount; i++)
            {
                UF.DGV_row.Add(Update_DGV.Rows[rowToEdit].Cells[i].Value.ToString());
                UF.DGV_header.Add(Update_DGV.Columns[i].HeaderText);
            }

            return UF;
        }

        internal static void SaveTableToTxt(DataGridView DGV_data, string fileName)
        {
            List<string> list = new List<string>();
            List<string> finalList = new List<string>();

            int indexCounter = 0;

            for (int i = 0; i < DGV_data.RowCount; i++)
            {
                string temp = "";
                for (int j = 1; j < DGV_data.ColumnCount; j++)
                {
                    list.Add(DGV_data.Rows[i].Cells[j].Value.ToString());
                    temp += list[indexCounter] + " ";
                    indexCounter++;
                }
                finalList.Add(temp);
            }

            System.IO.File.WriteAllLines(fileName, finalList);
            System.Diagnostics.Process.Start(fileName);
        }
    }
}
