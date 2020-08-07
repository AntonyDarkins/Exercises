using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Exercise1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<string> leftList;
        public List<string> LeftList
        {
            get => leftList;
            set
            {
                SetProperty(ref leftList, value);
            }
        }

        private List<string> rightList;
        public List<string> RightList
        {
            get => rightList;
            set
            {
                SetProperty(ref rightList, value);
            }
        }
        public ICommand exitCmd { get; }

        public MainWindowViewModel()
        {
            exitCmd = new DelegateCommand(execExit);

            LeftList = new List<string> { "Tom","Dick","Harry" };
        }

        private void execExit()
        {
            Application.Current.Shutdown();
        }
    }
}
