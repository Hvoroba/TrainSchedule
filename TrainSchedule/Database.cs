using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace TrainSchedule
{
    class Database
    {
        internal static SQLiteConnection connection = new SQLiteConnection("data source=TrainSchedule.db");

        internal static void DeleteRow(string tableName, int id)
        {
            string query = "DELETE FROM " + tableName + " WHERE _id = " + id;
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        internal static Tables Select(string query, string tableName)
        {
            Tables tables = new Tables
            {
                T_Routes = new List<Routes>(),
                T_Trains = new List<Trains>(),
                T_Stops = new List<Stops>()
            };

            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            
            switch (tableName)
            {
                case "Маршруты":

                    while (reader.Read())
                    {
                        Routes routes = new Routes
                        {
                            _Id = new int(),
                            Trains_Id = string.Empty,
                            FirstStop_Id = string.Empty,
                            LastStop_Id = string.Empty,
                            DepartmentTime = string.Empty,
                            ArrivalTime = string.Empty
                        };

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            routes._Id = (int)reader[i++];
                            routes.Trains_Id = (string)reader[i++];
                            routes.FirstStop_Id = (string)reader[i++];
                            routes.LastStop_Id = (string)reader[i++];
                            routes.DepartmentTime = (string)reader[i++];
                            routes.ArrivalTime = (string)reader[i];
                        }
                        tables.T_Routes.Add(routes);
                    }
                    break;

                case "Поезда":

                    while (reader.Read())
                    {
                        Trains trains = new Trains
                        {
                            _Id = new int(),
                            Name = string.Empty,
                            Capacity = new int()
                        };

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            trains._Id = (int)reader[i++];
                            trains.Name = (string)reader[i++];
                            trains.Capacity = (int)reader[i];
                        }
                        tables.T_Trains.Add(trains);
                    }
                    break;

                case "Остановки":

                    while (reader.Read())
                    {
                        Stops stops = new Stops
                        {
                            _Id = new int(),
                            Name = string.Empty
                        };

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            stops._Id = Convert.ToInt32(reader[i++]);
                            stops.Name = (string)reader[i];
                        }
                        tables.T_Stops.Add(stops);
                    }
                    break;

                default:
                    break;
            }
            
            reader.Close();
            connection.Close();

            return tables;
        }

        internal static TrainsIdToName SelectIdsAndNames(string query)
        {
            connection.Open();

            TrainsIdToName tbl = new TrainsIdToName()
            {
                _id = new List<int>(),
                Name = new List<string>()
            };

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i <reader.FieldCount; i++)
                {
                    tbl._id.Add((int)reader[i++]);
                    tbl.Name.Add((string)reader[i]);
                }
            }
                reader.Close();
            connection.Close();

            return tbl;
        }

        internal static List<int> SelectAllIds(string query)
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<int> idList = new List<int>();
            while(reader.Read())
            {
                idList.Add(Convert.ToInt32(reader[0]));
            }

            reader.Close();
            connection.Close();

            return idList;
        }

        internal static void UpdateRoutes(RoutesToUpdate routes)
        {
            connection.Open();

            string values = routes._Id + ", ";
            values += routes.Trains_Id + ", ";
            values += routes.FirstStop_Id + ", ";
            values += routes.LastStop_Id + ", ";
            values += "\"" + routes.DepartmentTime + "\", ";
            values += "\"" + routes.ArrivalTime + "\"";

            SQLiteCommand command = new SQLiteCommand("INSERT INTO Маршруты VALUES (" + values + ")", connection);
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                connection.Close();
                MessageBox.Show("Ошибка ввода.", "Ошибка!");
                return;
            }

            connection.Close();
        }

        internal static void UpdateTrains(TrainsToUpdate trains)
        {
            connection.Open();

            string values = trains._Id + ", ";
            values += "\"" + trains.Name + "\", ";
            values += trains.Capacity;

            SQLiteCommand command = new SQLiteCommand("INSERT INTO Поезда VALUES (" + values + ")", connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                connection.Close();
                MessageBox.Show("Ошибка ввода.", "Ошибка!");
                return;
            }

            connection.Close();

        }

        internal static void UpdateStops(StopsToUpdate stops)
        {
            connection.Open();

            string values = stops._Id + ", ";
            values += "\"" + stops.Name + "\"";

            SQLiteCommand command = new SQLiteCommand("INSERT INTO Остановки VALUES (" + values + ")", connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                connection.Close();
                MessageBox.Show("Ошибка ввода.", "Ошибка!");
                return;
            }

            connection.Close();

        }
        
        internal static DataSet GetDataSet(string query)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, connection);

            DataSet ds = new DataSet();
            da.Fill(ds, "AllData");
            
            ds.Dispose();
            da.Dispose();

            return ds;
        }

        internal static List<string> SellectAllNames(string query)
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> nameList = new List<string>();

            while (reader.Read())
            {
                nameList.Add(reader[0].ToString());
            }

            reader.Close();
            connection.Close();

            return nameList;
        }
    }
}
