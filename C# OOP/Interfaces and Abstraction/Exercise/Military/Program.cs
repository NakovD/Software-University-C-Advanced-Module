using Military.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Military
{
    public class StartUp
    {
        private static List<Private> privates = new List<Private>();

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ReadSoldiers();
        }

        private static void ReadSoldiers()
        {
            var currentLine = Console.ReadLine();

            if (currentLine == "End") return;

            CreateSoldier(currentLine);

            ReadSoldiers();
        }

        private static void CreateSoldier(string currentLine)
        {
            var soldierData = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ISoldier soldier = null;

            var soldierType = soldierData.Take(1).ToArray()[0];

            soldierData = soldierData.Skip(1).ToArray();

            switch (soldierType)
            {
                case "Private":
                    soldier = CreatePrivate(soldierData);
                    break;
                case "LieutenantGeneral": soldier = CreateLeutenant(soldierData);
                    break;
                case "Engineer": soldier = CreateEnginner(soldierData);
                    break;
                case "Commando": soldier = CreateCommando(soldierData);
                    break;
                default: soldier = CreateSpy(soldierData);
                    break;
            }

            if (soldier == null) return;

            Console.WriteLine(soldier.ToString());
        }

        private static ISoldier CreateSpy(string[] spyData)
        {
            var id = spyData[0];
            var fName = spyData[1];
            var lName = spyData[2];
            var codeNumber = int.Parse(spyData[3]);

            var spy = new Spy(codeNumber, fName, lName, id);

            return spy;
        }

        private static ISoldier CreateCommando(string[] commandoData)
        {
            var id = commandoData[0];
            var fName = commandoData[1];
            var lName = commandoData[2];
            var salary = decimal.Parse(commandoData[3]);
            var corps = commandoData[4];
            var areCorpsValid = ValidateCorps(corps);
            if (!areCorpsValid) return null;
            var missionsArr = commandoData.Skip(5).ToArray();

            var missions = GetMissions(missionsArr);

            var commando = new Commando(missions, corps, fName, lName, id, salary);

            return commando;
        }

        private static HashSet<Mission> GetMissions(string[] missionsArr)
        {
            var missions = new HashSet<Mission>();

            for (int i = 0; i < missionsArr.Length; i += 2)
            {
                var missionName = missionsArr[i];
                var missionState = missionsArr[i + 1];
                if (missionState != "inProgress" && missionState != "Finished") continue;
                var mission = new Mission(missionName, missionState);
                missions.Add(mission);
            }

            return missions;
        }

        private static ISoldier CreateEnginner(string[] engineerData)
        {
            var id = engineerData[0];
            var fName = engineerData[1];
            var lName = engineerData[2];
            var salary = decimal.Parse(engineerData[3]);
            var corps = engineerData[4];
            var areCorpsValid = ValidateCorps(corps);
            if (!areCorpsValid) return null;
            var repairParts = engineerData.Skip(5).ToArray();

            var repairs = GetRepairParts(repairParts);

            var engineer = new Engineer(repairs, corps, fName, lName, id, salary);

            return engineer;
        }

        private static HashSet<Repair> GetRepairParts(string[] repairParts)
        {
            var _repairParts = new HashSet<Repair>();

            for (int i = 0; i < repairParts.Length; i += 2)
            {
                var repairPartName = repairParts[i];
                var repairPartHours = int.Parse(repairParts[i + 1]);
                var repairPart = new Repair(repairPartName, repairPartHours);
                _repairParts.Add(repairPart);
            }

            return _repairParts;
        }

        private static ISoldier CreateLeutenant(string[] leutenantData)
        {
            var id = leutenantData[0];
            var fName = leutenantData[1];
            var lName = leutenantData[2];
            var salary = decimal.Parse(leutenantData[3]);
            var privatesString = leutenantData.Skip(4).ToArray();

            var privates = GetLeutenantPrivates(privatesString);

            var leutenant = new LieutenantGeneral(privates, fName, lName, id, salary);

            return leutenant;
        }

        private static HashSet<Private> GetLeutenantPrivates(string[] privatesString)
        {
            var setPrivates = new HashSet<Private>();

            foreach (var privateString in privatesString)
            {
                var neededPrivate = privates.SingleOrDefault(_private => _private.Id == privateString);
                setPrivates.Add(neededPrivate);
            }

            return setPrivates;
        }

        private static ISoldier CreatePrivate(string[] privateData)
        {
            var id = privateData[0];
            var fName = privateData[1];
            var lName = privateData[2];
            var salary = decimal.Parse(privateData[3]);

            var _private = new Private(fName, lName, id, salary);

            privates.Add(_private);

            return _private;
        }

        private static bool ValidateCorps(string corps)
        {
            if (corps != "Airforces" && corps != "Marines") return false;
            return true;
        }
    }
}
