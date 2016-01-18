using COREDB;
using MCORE.Kinect;
using Microsoft.Kinect;
using System;

namespace MCORE
{
    public class MathiasCore
    {
        private String DBPATH { get; set; }
        public bool CONNECTED { get; set; }
        private DBManager dbManager { get; set; }
        public DBContext DBCONTEXT { get; set; }
        public KinectSensor kinect = null;
        public KinectAudioController KinectAudio;

        /// <summary>
        /// Simply a empty Constructor
        /// </summary>
        public MathiasCore()
        {
            CONNECTED = false;
            KinectAudio = new KinectAudioController();
            kinect = KinectSensor.GetDefault();
            dbManager = new DBManager();
        }

        /// <summary>
        /// Constructor with database path
        /// </summary>
        /// <param name="PathToDatabase">path to database folder</param>
        public MathiasCore(string PathToDatabase)
        {
            DBPATH = PathToDatabase;
            KinectAudio = new KinectAudioController();
            kinect = KinectSensor.GetDefault();
            dbManager = new DBManager(DBPATH);
        }

        public bool Connect(string _login, string _password)
        {
            using (DBCONTEXT = new DBContext())
            {
                if(DBCONTEXT.CheckUser(_login, _password))
                {
                    CONNECTED = true;
                    if (String.IsNullOrEmpty(DBPATH))
                    {
                        DBCONTEXT = new DBContext();
                    }
                    else
                    {
                        DBCONTEXT = new DBContext(DBPATH);
                    }
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
