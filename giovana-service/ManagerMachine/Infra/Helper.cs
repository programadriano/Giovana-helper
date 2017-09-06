using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.ServiceProcess;

namespace ManagerMachine.Infra
{
    public class Helper
    {
        public static void Manager()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Manager");
            var collection = database.GetCollection<Models.Machine>("Machine");

            var process = collection.Find(x => x.Name == "TokenBroker").FirstOrDefault();

            if (process != null)
            {

                var update = Builders<Models.Machine>.Update
                    .Set(a => a.DtUpdate, DateTime.Now)
                    .Set(a => a.Status, StatusService("TokenBroker"));

                collection.UpdateOne(model => model.Id == process.Id, update);

            }
            else
            {
                collection.InsertOne(new Models.Machine { Name = "TokenBroker", Status = StatusService("TokenBroker"), DtUpdate = DateTime.Now });
            }
        }


        #region [Manager Process]
        public static string StatusService(string name)
        {

            ServiceController sc = new ServiceController(name);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }

        }

        public static bool StartProcess(string name)
        {

            try
            {
                var sc = new ServiceController(name);
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public static bool StopProcess(string name)
        {

            try
            {
                var sc = new ServiceController(name);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
