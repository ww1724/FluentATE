using ATE.Service;
using ATE.Share.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ATE.Share.Stores
{
    public partial class TestStore : ObservableObject
    {
        [ObservableProperty]
        private TestingRecord record;

        public TestStore(DbService dbService)
        {

            record = new TestingRecord();

            InitializeRecord(ref record);

            OnPropertyChanged(nameof(Record));


        }

        public void InitializeRecord(ref TestingRecord record)
        {
            record.Steps = new ObservableCollection<TestingStep>
            {
                new TestingStep() { Title = "启动测试" },
                new TestingStep() { Title = "输入对输出高压测试" },
                new TestingStep() { Title = "输入对地高压测试" },
                new TestingStep() { Title = "输出对地高压测试"},
                new TestingStep() { Title = "小负载测试"},
                new TestingStep() { Title = "大负载测试"},
                new TestingStep() { Title = "短路&恢复测试"},
                new TestingStep() { Title = "153P调光测试"},
                new TestingStep() { Title = "300P调光测试"},
                new TestingStep() { Title = "0-10V调光测试"},
                new TestingStep() { Title = "变压器放电"},
                new TestingStep() { Title = "变压器放电"},
                new TestingStep() { Title = "变压器放电"},
                new TestingStep() { Title = "变压器放电"},
                new TestingStep() { Title = "变压器放电"},
            };
        }
    }
}
