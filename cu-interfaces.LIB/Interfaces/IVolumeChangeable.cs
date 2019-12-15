using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu_interfaces.LIB.Interfaces
{
    public interface IVolumeChangeable
    {
        int CurrentVolume { get; }

        void VolumeUp();
        void VolumeDown();
    }
}
