using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Share.Models
{
    public partial class TestingResult : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private List<object> channelResults;

        [ObservableProperty]
        private double minValue;

        [ObservableProperty]
        private double maxValue;
    }

    public partial class TestingParameter : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public bool parameterToAllChannel;

        [ObservableProperty]
        public Type type;

        [ObservableProperty]
        public object value;

        [ObservableProperty]
        public List<object> channelValues;
    }

    //public class TestingParameter : BindableBase
    //{
    //    private string name;
    //    private string title;
    //    private string description;
    //    private List<object> channelResults;
    //    private double minValue;
    //    private double maxValue;

    //    public string Name { get { return name; } set { SetProperty(ref name, value); } }

    //    public string Title { get { return title; } set { SetProperty(ref title, value); } }

    //    public string Description { get { return description; } set { SetProperty(ref description, value); } }

    //    public double MinValue { get { return minValue; } set { SetProperty(ref minValue, value); } }

    //    public double MaxValue { get { return maxValue; } set { SetProperty(ref maxValue, value); } }

    //    public List<object> ChannelResults { get { return channelResults; } set { SetProperty(ref channelResults, value); } }
    //}

    public partial class TestingStep : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        private bool isToTest = true;

        [ObservableProperty]
        private bool isExpand = false;

        [ObservableProperty]
        private ObservableCollection<TestingParameter> parameters = new();


        [ObservableProperty]
        private ObservableCollection<TestingResult> results = new();

    }

    //public class TestingCode : BindableBase
    //{

    //    private ObservableCollection<TestingStep> steps;
    //    public ObservableCollection<TestingStep> Steps
    //    {
    //        get { return steps; }
    //        set { SetProperty(ref steps, value); }
    //    }
    //}

    public partial class TestingRecord : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TestingStep> steps = new();

    }
}
