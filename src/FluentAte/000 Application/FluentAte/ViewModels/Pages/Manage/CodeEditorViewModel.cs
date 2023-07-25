using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FluentAte.ViewModels.Pages.Manage
{
    public class CodeEditorViewModel : ObservableObject
    {
        public TestStore TestStore { get; }

        public CodeEditorViewModel(TestStore testStore)
        {
            TestStore = testStore;
        }
    }
}
