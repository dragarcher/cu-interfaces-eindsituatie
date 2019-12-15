using cu_interfaces.LIB.Klassen;
using cu_interfaces.LIB.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Text;

namespace cu_interfaces.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Televisie tvWoonkamer;
        Radio radioKeuken;
        SmartLamp lampGang;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tvWoonkamer = new Televisie("woonkamer");
            radioKeuken = new Radio("keuken");
            lampGang = new SmartLamp("gang");
        }

        private void btnTvWoonkamerPower_Click(object sender, RoutedEventArgs e)
        {
            if (tvWoonkamer.IsOn)
            {
                lblTvWoonkamer.Content = tvWoonkamer.PowerOff();
                lblTvWoonkamer.Background = Brushes.Red;
            }
            else
            {
                lblTvWoonkamer.Content = tvWoonkamer.PowerOn();
                lblTvWoonkamer.Background = Brushes.LightGreen;
            }
        }

        private void btnSmartLampGangPower_Click(object sender, RoutedEventArgs e)
        {
            if (lampGang.IsOn)
            {
                lblSmartLampGang.Content = lampGang.PowerOff();
                lblSmartLampGang.Background = Brushes.Red;
            }
            else
            {
                lblSmartLampGang.Content = lampGang.PowerOn();
                lblSmartLampGang.Background = Brushes.LightGreen;
            }
        }

        private void btnRadioKeuken_Click(object sender, RoutedEventArgs e)
        {
            if (radioKeuken.IsOn)
            {
                lblRadioKeuken.Content = radioKeuken.PowerOff();
                lblRadioKeuken.Background = Brushes.Red;
            }
            else
            {
                lblRadioKeuken.Content = radioKeuken.PowerOn();
                lblRadioKeuken.Background = Brushes.LightGreen;
            }
        }

        private void btnTvWoonKamerVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (tvWoonkamer.IsOn)
            {
                tvWoonkamer.VolumeDown();
                lblTvWoonKamerVolume.Content = tvWoonkamer.CurrentVolume;
            }
        }

        private void btnTvWoonKamerVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (tvWoonkamer.IsOn)
            {
                tvWoonkamer.VolumeUp();
                lblTvWoonKamerVolume.Content = tvWoonkamer.CurrentVolume;
            }
        }

        private void btnRadioKeukenVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            if (radioKeuken.IsOn)
            {
                radioKeuken.VolumeDown();
                lblRadioKeukenVolume.Content = radioKeuken.CurrentVolume;
            }
        }

        private void btnRadioKeukenVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            if (radioKeuken.IsOn)
            {
                radioKeuken.VolumeUp();
                lblRadioKeukenVolume.Content = radioKeuken.CurrentVolume;
            }
        }

        private void btnCheckConnections_Click(object sender, RoutedEventArgs e)
        {
            List<IConnectionCheckable> connectionChecks = new List<IConnectionCheckable>
            {
                new Radio("keuken"),
                new Televisie("keuken"),
                new Radio("badkamer"),
                new Radio("living"),
                new Televisie("living"),
                new Televisie("slaapkamer"),
                new Radio("wc"),
            };

            tbkTestConnectionFeedback.Text = "";
            foreach (IConnectionCheckable check in connectionChecks)
            {
                tbkTestConnectionFeedback.Text += check.CheckBroadcastConnection();
            }
        }

        private void btnCheckInterfaceImplementation_Click(object sender, RoutedEventArgs e)
        {
            List<ElektrischToestel> powerables = new List<ElektrischToestel>
            {
                lampGang,
                tvWoonkamer,
                radioKeuken
            };

            StringBuilder stringBuilder = new StringBuilder();

            foreach (IPowerable powerableItem in powerables)
            {
                if (!powerableItem.IsOn)
                {
                    powerableItem.IsOn = true;
                }

                stringBuilder.AppendLine($"{powerableItem.GetType().Name} power is on: {powerableItem.IsOn}");

                if (powerableItem is IVolumeChangeable volumeChangeableItem)
                {
                    stringBuilder.AppendLine($"Volume was: {volumeChangeableItem.CurrentVolume}");
                    volumeChangeableItem.VolumeUp();
                    stringBuilder.AppendLine($"Volume is now raised to: {volumeChangeableItem.CurrentVolume}");

                    if (powerableItem is Televisie)
                    {
                        lblTvWoonkamer.Content = "AAN";
                        lblTvWoonKamerVolume.Content = volumeChangeableItem.CurrentVolume;
                        lblTvWoonkamer.Background = Brushes.LightGreen;
                    }

                    if (powerableItem is Radio)
                    {
                        lblRadioKeuken.Content = "AAN";
                        lblRadioKeukenVolume.Content = volumeChangeableItem.CurrentVolume;
                        lblRadioKeuken.Background = Brushes.LightGreen;
                    }
                }
            }

            tbkTestConnectionFeedback.Text = stringBuilder.ToString();
        }
    }
}
