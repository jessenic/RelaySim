using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RelaySim.Components
{
    /// <summary>
    /// Interaction logic for Wire.xaml
    /// </summary>
    public partial class Wire : ElectricComponent {
        public Wire()
        {
            InitializeComponent();
            this.Ports = new List<Connection>();
        }
        public override bool DoesConduct(Connection A, Connection B)
        {
            //Wire conducts always
            return true;
        }
    }
}
