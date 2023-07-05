using ATE.Share.Models;
using FluentAte.ViewModels.Pages;
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
        private ListViewItem _draggedItem;

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

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _draggedItem = sender as ListViewItem;
            if (_draggedItem == null) return;
            //var itemIndex = CodeStepListView.ItemContainerGenerator.IndexFromContainer(_draggedItem as DependencyObject);
            DragDrop.DoDragDrop(CodeStepListView, _draggedItem.DataContext, DragDropEffects.Copy);
        }


        private void ListViewItem_PreviewDragOver(object sender, DragEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item == _draggedItem) return;
            foreach (var i in FindVisualChild<ListViewItem>(CodeStepListView))
            {
                i.BorderBrush = Brushes.Transparent;
            }
            item.BorderBrush = Brushes.Red;
            Console.WriteLine((item.DataContext as TestingStep).Title);
        }

        private void ListViewItem_PreviewDrop(object sender, DragEventArgs e)
        {
            var target = sender as ListViewItem;
            if (target == _draggedItem) return;
            ViewModel.TestStore.Record.Steps.Remove(_draggedItem.DataContext as TestingStep);
            ViewModel.TestStore.Record.Steps.Insert(CodeStepListView.Items.IndexOf(target.DataContext), e.Data.GetData(typeof(TestingStep)) as TestingStep);
        }

        static List<T> FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            try
            {
                List<T> TList = new List<T> { };
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        TList.Add((T)child);
                    }
                    else
                    {
                        List<T> childOfChildren = FindVisualChild<T>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                }
                return TList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }


    }
}
