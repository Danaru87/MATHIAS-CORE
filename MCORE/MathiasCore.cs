using COREDB;
using MCORE.Kinect;
using Microsoft.Kinect;
using Microsoft.Kinect.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCORE
{
    public class MathiasCore
    {
        private string user { get; set; }
        private string password { get; set; }

        public bool CONNECTED { get; set; }
        private DBManager dbManager { get; set; }
        public DBContext DBCONTEXT { get; set; }
        public KinectSensor kinect = null;
        public KinectAudioController KinectAudio = new KinectAudioController();

        public MathiasCore(string login, string password)
        {
            if (Connect(login, password))
            {
                CONNECTED = true;
                dbManager = new DBManager();
                kinect = KinectSensor.GetDefault();
            }
            else { CONNECTED = false; }

        }

        public bool Connect(string _login, string _password)
        {
            using (DBCONTEXT = new DBContext())
            {
                if(DBCONTEXT.CheckUser(_login, _password))
                {
                    CONNECTED = true;
                }
                else { CONNECTED = false; }
            }
            return CONNECTED;
        }

        private void LoadPlugins()
        {
          throw new NotImplementedException();
        }
    }
}
