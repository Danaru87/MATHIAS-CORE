using COREDB;
using MCORE.Kinect;
using System;
using System.Collections.Generic;
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
        public DBContext context { get; set; }

        public KinectAudioController KinectAudio = new KinectAudioController();

        public MathiasCore()
        {
            dbManager = new DBManager();
        }

        public bool Connect(string _login, string _password)
        {
            using (context = new DBContext())
            {
                if(context.CheckUser(_login, _password))
                {
                    CONNECTED = true;
                }
                else { CONNECTED = false; }
            }
            return CONNECTED;
        }
    }
}
