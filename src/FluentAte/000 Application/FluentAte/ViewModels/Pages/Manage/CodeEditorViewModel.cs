using ATE.Common.Test.TestFramework;
using ATE.Service;
using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAte.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FluentAte.ViewModels.Pages.Manage
{
    public partial class CodeEditorViewModel : ObservableObject
    {
        private PackageManager _packageManager;

        public TestStore TestStore { get; }


        [ObservableProperty]
        private ObservableCollection<ITestTaskMetadata> _availableTasks;

        public CodeEditorViewModel(TestStore testStore, PackageManager packageManager)
        {
            TestStore = testStore;
            _packageManager = packageManager;
            _availableTasks = new ObservableCollection<ITestTaskMetadata>();
            InitializeTaskPackage();
        }

        private async void InitializeTaskPackage()
        {
            await Task.CompletedTask;
            _availableTasks = new ObservableCollection<ITestTaskMetadata>(_packageManager.GetAvailableTasks());
            await Task.CompletedTask;
        }


        [RelayCommand]
        private void MoveItemsUp()
        {

        }

        [RelayCommand]
        private void MoveItemsDown()
        {

        }

        [RelayCommand]
        private void ExpandAll(object items)
        {
            foreach (var item in TestStore.EditorItems)
            {
                item.IsExpand = true;
            }
        }

        [RelayCommand]
        private void ShrinkAll(object items)
        {
            foreach (var item in TestStore.EditorItems)
            {
                item.IsExpand = false;
            }
        }

        [RelayCommand]
        private void SelectAll()
        {
            foreach(var item in TestStore.EditorItems)
            {
                item.IsChecked = true;
            }
        }
        [RelayCommand]
        private void UnSelectAll()
        {
            foreach (var item in TestStore.EditorItems)
            {
                item.IsChecked = false;
            }
        }

    }
}
