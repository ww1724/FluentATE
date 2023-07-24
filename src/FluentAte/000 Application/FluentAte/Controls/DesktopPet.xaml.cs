using HandyControl.Controls;
using HandyControl.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace FluentAte.Controls
{
    /// <summary>
    /// DesktopPet.xaml 的交互逻辑
    /// </summary>
    public partial class DesktopPet : UserControl
    {
        public DesktopPet()
        {
            InitializeComponent();

            IconWidget.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
            var ft = new FormattedText(
                "ATE",
                CultureInfo.GetCultureInfo("en-US"),
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Arial Rounded MT Bold"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                16,
                Brushes.LightGreen,
                100);
            IconWidget.Data = ft.BuildGeometry(new Point(0, 0));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IconWidget.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
            var ft = new FormattedText(
                "WAC", 
                CultureInfo.GetCultureInfo("en-US"),
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Arial Rounded MT Bold"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                16, 
                Brushes.LightGreen, 
                100);
           IconWidget.Data =  ft.BuildGeometry(new Point(0, 0));
        }

        private void IconWidget_Completed(object sender, EventArgs e)
        {

        }
    }
}
