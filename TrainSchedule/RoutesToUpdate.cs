namespace TrainSchedule
{
    class RoutesToUpdate
    {
        public int _Id { get; set; }

        public int Trains_Id { get; set; }

        public int FirstStop_Id { get; set; }

        public int LastStop_Id { get; set; }

        public string DepartmentTime { get; set; }

        public string ArrivalTime { get; set; }

    }
}
