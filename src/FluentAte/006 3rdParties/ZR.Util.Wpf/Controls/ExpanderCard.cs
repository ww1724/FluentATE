using System;
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

namespace ZR.Util.Wpf.Controls
{
    public class ExpandCard : System.Windows.Controls.Expander
    {
        /// <summary>
        /// Property for <see cref="Icon"/>.
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon),
            typeof(char), typeof(ExpandCard));

        /// <summary>
        /// Gets or sets displayed <see cref="IconElement"/>.
        /// </summary>
        public char? Icon
        {
            get => (char)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}
