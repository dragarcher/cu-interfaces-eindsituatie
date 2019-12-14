using cu_interfaces.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu_interfaces.LIB.Klassen
{
    public class SmartLamp : ElektrischToestel, IPowerable
    {
        public bool IsOn { get; set; }

        public SmartLamp(string livingRoom) : base(livingRoom)
        {
        }
        public string PowerOff()
        {
            IsOn = false;
            return $"Smartlamp {LivingRoom} is uit";
        }

        public string PowerOn()
        {
            IsOn = true;
            return $"Smartlamp {LivingRoom} is aan";
        }
    }
}
