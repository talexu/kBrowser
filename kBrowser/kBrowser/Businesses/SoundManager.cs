using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace kBrowser.Businesses
{
    class SoundManager
    {
        #region instance
        private static SoundManager _instance = new SoundManager();
        public static SoundManager Instance
        {
            get
            {
                return _instance;
            }
        }
        private SoundManager()
        {
        }
        #endregion

        public event Action<float> ScaleChanged;

        private const int OUTPUTRATE = 48000;
        private const int SPECTRUMSIZE = 8192;
        private const float SPECTRUMRANGE = ((float)OUTPUTRATE / 2.0f);
        private const float BINSIZE = (SPECTRUMRANGE / (float)SPECTRUMSIZE);

        private FMOD.System system = null;
        private FMOD.Sound sound = null;
        private FMOD.Channel channel = null;
        private int outputfreq = 0;
        private int bin = 0;
        private int numdrivers = 0;
        private uint version = 0;
        private StringBuilder drivername = new StringBuilder(256);
        private FMOD.GUID guid = new FMOD.GUID();
        private DispatcherTimer t;

        public void init() 
        {
            FMOD.RESULT result;

            //create system
            result = FMOD.Factory.System_Create(ref system);
            ERRCHECK(result);

            //check version
            result = system.getVersion(ref version);
            ERRCHECK(result);
            if (version < FMOD.VERSION.number)
            {
                Console.WriteLine("Error!  You are using an old version of FMOD " + version.ToString("X") + ".  This program requires " + FMOD.VERSION.number.ToString("X") + ".");
            }

            //get playback drivers
            result = system.getNumDrivers(ref numdrivers);
            ERRCHECK(result);

            for (int count = 0; count < numdrivers; count++)
            {
                result = system.getDriverInfo(count, drivername, drivername.Capacity, ref guid);
                ERRCHECK(result);
            }

            //get record drivers 
            result = system.getRecordNumDrivers(ref numdrivers);
            ERRCHECK(result);

            for (int count = 0; count < numdrivers; count++)
            {
                result = system.getRecordDriverInfo(count, drivername, drivername.Capacity, ref guid);
                ERRCHECK(result);
            }

            //set output device
            result = system.setOutput(FMOD.OUTPUTTYPE.DSOUND);
            ERRCHECK(result);

            //set playback driver 0-扬声器
            result = system.setDriver(0);
            ERRCHECK(result);

            //set record driver 0-kinect 1-microphone(if there is no kinect 0-microphone)
            FMOD.CREATESOUNDEXINFO exinfo = new FMOD.CREATESOUNDEXINFO();
            FMOD.DSP_RESAMPLER resampler = FMOD.DSP_RESAMPLER.MAX;
            int selected = 1;
            system.getRecordDriverInfo(selected, drivername, drivername.Capacity, ref guid);
            Console.WriteLine("recorder name:" + drivername.ToString());
            int temp = 0;
            FMOD.SOUND_FORMAT format = FMOD.SOUND_FORMAT.NONE;

            result = system.setSoftwareFormat(OUTPUTRATE, FMOD.SOUND_FORMAT.PCM16, 1, 0, 0);
            ERRCHECK(result);

            result = system.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
            ERRCHECK(result);

            result = system.getSoftwareFormat(ref outputfreq, ref format, ref temp, ref temp, ref resampler, ref temp);
            ERRCHECK(result);

            //create a sound to record
            exinfo.cbsize = Marshal.SizeOf(exinfo);
            exinfo.numchannels = 1;
            exinfo.format = FMOD.SOUND_FORMAT.PCM16;
            exinfo.defaultfrequency = OUTPUTRATE;
            exinfo.length = (uint)(exinfo.defaultfrequency * 2 * exinfo.numchannels * 5);

            result = system.createSound((string)null, (FMOD.MODE._2D | FMOD.MODE.SOFTWARE | FMOD.MODE.LOOP_NORMAL | FMOD.MODE.OPENUSER), ref exinfo, ref sound);
            ERRCHECK(result);

            //start recording 
            result = system.recordStart(selected, sound, true);
            ERRCHECK(result);
            //give time to record
            Thread.Sleep(100);
            //play back
            result = system.playSound(FMOD.CHANNELINDEX.REUSE, sound, false, ref channel);
            ERRCHECK(result);

            result = channel.setVolume(0);
            ERRCHECK(result);

            //start timer to do spectrum analysis
            t = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            t.Tick += timer_Tick;
            t.Start();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            if (channel != null)
            {
                FMOD.RESULT result;
                float[] spectrum = new float[SPECTRUMSIZE];
                float dominanthz = 0;
                float max;
                float rate;
                int count = 0;

                result = channel.getSpectrum(spectrum, SPECTRUMSIZE, 0, FMOD.DSP_FFT_WINDOW.TRIANGLE);
                ERRCHECK(result);

                max = 0;
                for (count = 0; count < SPECTRUMSIZE; count++)
                {
                    if (spectrum[count] > 0.01f && spectrum[count] > max)
                    {
                        max = spectrum[count];
                        bin = count;
                    }
                }

                dominanthz = (float)bin * BINSIZE;
                if (dominanthz >= 300.0f && dominanthz < 1000.0f)
                {
                    float lr = 0.97f;
                    rate = (dominanthz - 300.0f) / 100.0f;
                    if (rate >= 0.0f && rate < lr)
                    {
                        rate = rate * (1.0f - lr) / 1.0f + lr;
                        ScaleChanged(rate);
                    }
                    else if (rate >= lr && rate < 2.0f - lr)
                    {
                        ScaleChanged(rate);
                    }
                    else if (rate >= 2.0f - lr && rate < 2.0f)
                    {
                        rate = rate * (1.0f -lr) / 7.0f +1.0f;
                        ScaleChanged(rate);
                    }
                    Console.WriteLine("rate: " + rate);
                }
            }

            if (system != null)
            {
                system.update();
            }
        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                t.Stop();
                Console.WriteLine("FMOD error! " + result + " - " + FMOD.Error.String(result));
                Environment.Exit(-1);
            }
        }
    }
}
