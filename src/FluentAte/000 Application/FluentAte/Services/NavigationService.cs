using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FluentAte.Services
{
    public interface IAppNavigationService
    {
        //bool CanGoBack { get; }
        //void GoBack();
        void Navigate(Type type, object args = null);

        void SetServiceProvider(IServiceProvider serviceProvider);

        void SetNavigationContainer(ContentControl contentControl);
    }

    // UWP navigation service
    public class AppNavigationService : IAppNavigationService
    {
        private ContentControl _frame;

        private IServiceProvider _serviceProvider;

        public AppNavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public bool CanGoBack => this.frame.CanGoBack;

        //public void GoBack() => this.frame.GoBack();

        public void Navigate(Type type, object args = null)
        {
            if (_frame == null) return;
          _frame.Content = _serviceProvider.GetService(type);
        }


        public void SetNavigationContainer(ContentControl contentControl)
        {
            _frame = contentControl;
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
