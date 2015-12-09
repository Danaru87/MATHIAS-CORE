using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCORE.Kinect
{
    internal class KinectAudioStream : Stream
    {
        private Stream kinect32BitStream;
        public bool SpeechActive { get; set; }

        public KinectAudioStream(Stream input)
        {
            this.kinect32BitStream = input;
        }
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                return 0;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            const int SampleSizeRatio = sizeof(float) / sizeof(short);
 
            const int SleepDuration = 50;

            int readcount = count * SampleSizeRatio;
            byte[] kinectBuffer = new byte[readcount];

            int bytesremaining = readcount;

            while(bytesremaining > 0)
            {
                if (!this.SpeechActive)
                {
                    return 0;
                }

                int result = this.kinect32BitStream.Read(kinectBuffer, readcount - bytesremaining, bytesremaining);
                bytesremaining -= result;

                if (bytesremaining > 0)
                {
                    System.Threading.Thread.Sleep(SleepDuration);
                }
            }

            for(int i = 0; i < count / sizeof(short); i++)
            {
                float sample = BitConverter.ToSingle(kinectBuffer, i * sizeof(float));

                if (sample > 1.0f)
                {
                    sample = 1.0f;
                }
                else if(sample < -1.0f)
                {
                    sample = -1.0f;
                }

                short convertedSample = Convert.ToInt16(sample * short.MaxValue);

                byte[] local = BitConverter.GetBytes(convertedSample);
                System.Buffer.BlockCopy(local, 0, buffer, offset + (i * sizeof(short)), sizeof(short));
            }
            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
