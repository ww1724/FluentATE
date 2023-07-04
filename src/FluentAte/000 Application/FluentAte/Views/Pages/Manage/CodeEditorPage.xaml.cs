using FluentAte.ViewModels.Pages.Admin;
using FluentAte.ViewModels.Pages.Manage;
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
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages.Manage
{
    /// <summary>
    /// CodeEditor.xaml 的交互逻辑
    /// </summary>
    public partial class CodeEditorPage : INavigableView<CodeEditorViewModel>
    {
        private bool _isDragging;
        private object _draggedItem;

        public CodeEditorViewModel ViewModel
        {
            get;
        }

        public CodeEditorPage(CodeEditorViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draggedItem = sender;
            CodeStepListView.ScrollIntoView(CodeStepListView.Items[CodeStepListView.Items.Count - 1]);//移动到最后一行

        }

        private void ListViewItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_draggedItem == null || e.LeftButton != MouseButtonState.Pressed || _isDragging)
                return;

            _isDragging = true;

            //var listView = sender as ListView;
            var itemIndex = CodeStepListView.ItemContainerGenerator.IndexFromContainer(_draggedItem as DependencyObject);

            // Initialize the drag & drop operation
            var data = new DataObject(typeof(int), itemIndex);
            DragDrop.DoDragDrop(CodeStepListView, data, DragDropEffects.Move);

            _draggedItem = null;
            _isDragging = false;
        }
    }
}
