namespace P04.Recharge
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var rechargeStation = new RechargeStation();

            var robocop1 = new Robot("robocop", 100);

            var employee = new Employee("gosho");

            var robocop2 = new Robot("robocop2", 200);

            var rechargables = new List<IRechargeable>() { robocop1, robocop2 };

            rechargeStation.RechargeEntities(rechargables);

            var workers = new List<Worker>() { robocop1, employee, robocop2 };

            workers.ForEach(worker => worker.Work(2));

            
        }
    }
}
