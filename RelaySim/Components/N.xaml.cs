﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for N.xaml
    /// </summary>
    public partial class N : ElectricComponent
    {
        public N()
        {
            InitializeComponent();
            this.Ports = new List<Connection>();
            ((Connection)Con1.Content).Component = this;
            this.Ports.Add((Connection)Con1.Content);
        }
    }
}
