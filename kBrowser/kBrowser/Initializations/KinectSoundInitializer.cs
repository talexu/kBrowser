using FrequencyAmplitude;
using kBrowser.Businesses;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace kBrowser.Initializations
{
    class KinectSoundInitializer : AbstractInitializer
    {
        private const int AudioPollingInterval = 50;
        private const int SamplesPerMillisecond = 16;
        private const int BytesPerSample = 2;
        private const int SamplesPerColumn = 40;
        private readonly byte[] audioBuffer = new byte[AudioPollingInterval * SamplesPerMillisecond * BytesPerSample];
        private Stream audioStream;
        private bool reading;
        private Thread readingThread;
        private double accumulatedSquareSum;
        private int accumulatedSampleCount;
        private readonly object energyLock = new object();
        private const int EnergyBitmapWidth = 780;
        private const int EnergyBitmapHeight = 195;
        private readonly double[] energy = new double[(uint)(EnergyBitmapWidth * 1.25)];
        private int energyIndex;
        private int newEnergyAvailable;
        private KinectSensor sensor;
        private List<double> freqs;

        public KinectSoundInitializer(IDictionary<string, object> parameters)
            : base(parameters)
        {
            KinectCommands.WindowClosed += () =>
                {
                    Stop();
                };
        }

        public override void run()
        {
            //throw new NotImplementedException();
            base.run();

            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    Console.WriteLine("sensor get");
                    break;
                }
            }

            if (null != this.sensor)
            {
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                Console.WriteLine("NoKinectReady");
                return;
            }

            this.audioStream = this.sensor.AudioSource.Start();

            this.reading = true;
            this.readingThread = new Thread(AudioReadingThread);
            this.readingThread.Start();

            //start timer to get avg
            DispatcherTimer t = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            t.Tick += calculateFreq;
            t.Start();
        }

        public void Stop()
        {
            this.reading = false;
            if (null != readingThread)
            {
                readingThread.Join();
            }

            if (null != this.sensor)
            {
                this.sensor.AudioSource.Stop();
                this.sensor.Stop();
                this.sensor = null;
            }
        }


        private void AudioReadingThread()
        {
            const double EnergyNoiseFloor = 0.2;

            while (this.reading)
            {
                int readCount = audioStream.Read(audioBuffer, 0, audioBuffer.Length);
                freqs = new List<double>();

                lock (this.energyLock)
                {
                    for (int i = 0; i < readCount; i += 2)
                    {
                        short audioSample = BitConverter.ToInt16(audioBuffer, i);
                        this.accumulatedSquareSum += audioSample * audioSample;
                        ++this.accumulatedSampleCount;

                        if (this.accumulatedSampleCount < SamplesPerColumn)
                        {
                            continue;
                        }

                        double meanSquare = this.accumulatedSquareSum / SamplesPerColumn;
                        double amplitude = Math.Log(meanSquare) / Math.Log(int.MaxValue);
                        //Console.WriteLine("amplitude:" + amplitude);

                        this.energy[this.energyIndex] = Math.Max(0, amplitude - EnergyNoiseFloor) / (1 - EnergyNoiseFloor);
                        this.energyIndex = (this.energyIndex + 1) % this.energy.Length;
                        //Console.WriteLine("amplitude:" + this.energy[this.energyIndex]);

                        this.accumulatedSquareSum = 0;
                        this.accumulatedSampleCount = 0;

                        //FFT处理freq
                        double[] data = new double[audioBuffer.Length];
                        for (int j = 0; j < audioBuffer.Length; j++)
                        {
                            data[j] = (double)audioBuffer[j];
                        }
                        Complex[] fData = FreqAnalyzer.FFT(data, false);

                        //复数转成模
                        data = FreqAnalyzer.Cmp2Mdl(fData);
                        double freqence = ftt2Freq(data);
                        Console.WriteLine("freqence:" + freqence);

                        freqs.Add(freqence);
                    }
                }
            }
        }

        double ftt2Freq(double[] data)
        {
            int N = data.Length;
            int Fs = 16000;

            double maxMagnitude = 0.0;
            int maxIndex = -1;
            for (int i = 0; i < N / 2 - 1; i++)
            {
                if (data[i] > maxMagnitude)
                {
                    maxMagnitude = data[i];
                    maxIndex = i;
                }
            }
            double freq = maxIndex * Fs / N;
            return freq;
        }


        void calculateFreq(object sender, EventArgs e)
        {
            double avgFreq = 0.0;
            double totalFreq = 0.0;

            if (freqs != null)
            {
                for (int i = 0; i < freqs.Count; i++)
                {
                    totalFreq += freqs[i];
                }
                avgFreq = totalFreq / freqs.Count;
                Console.WriteLine("avgFreq:" + avgFreq);
            }
        }
    }
}
