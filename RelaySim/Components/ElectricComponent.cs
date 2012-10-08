using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace RelaySim.Components
{
    public class ElectricComponent : UserControl
    {
        public ElectricComponent()
        {
            this.Ports = new List<Connection>();
        }
        public List<Connection> Ports { get; internal set; }
        virtual public bool DoesConduct(Connection PortA, Connection PortB)
        {
            return false;
        }
    }
}
