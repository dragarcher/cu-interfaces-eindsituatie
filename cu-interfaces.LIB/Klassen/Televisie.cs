using cu_interfaces.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu_interfaces.LIB.Klassen
{
    public class Televisie : ElektrischToestel, IPowerable, IVolumeChangeable, IConnectionCheckable
    {
        static Random rnd = new Random();

        public bool IsOn { get; set; }
        public int CurrentVolume { get; private set; } = 50;

        public Televisie(string livingRoom) : base(livingRoom)
        {
        }

        public string PowerOff()
        {
            IsOn = false;
            return $"TV {LivingRoom} is uit";
        }

        public string PowerOn()
        {
            IsOn = true;
            return $"TV {LivingRoom} is aan";
        }

        public void VolumeUp()
        {
            CurrentVolume += 10;
            if (CurrentVolume > 100)
            {
                CurrentVolume = 100;
            }
        }

        public void VolumeDown()
        {
            CurrentVolume -= 10;
            if (CurrentVolume < 0)
            {
                CurrentVolume = 0;
            }
        }

        public string CheckBroadcastConnection()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"=========== Testing {this.GetType().Name} {LivingRoom} ===========");
            stringBuilder.AppendLine("Is COAX connected? Checking connection...");
            stringBuilder.AppendLine($"COAX connected test returns {IsCoaxCableConnected()} {Environment.NewLine}");

            stringBuilder.AppendLine("Is signal available? Checking signal...");
            stringBuilder.AppendLine($"Signal available test returns {IsSignalAvailable()}");
            stringBuilder.AppendLine($"Signal strength test returns {IsSignalStrengthOk()}");
            stringBuilder.AppendLine($"---------- End of test {this.GetType().Name} {LivingRoom} ---------- {Environment.NewLine}");

            return stringBuilder.ToString();
        }

        private bool IsCoaxCableConnected()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }

        private bool IsSignalStrengthOk()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }
        private bool IsSignalAvailable()
        {
            int trueOrFalse = rnd.Next(2);

            return Convert.ToBoolean(trueOrFalse);
        }
    }
}