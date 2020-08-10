using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<string> leftList;
        public ObservableCollection<string> LeftList
        {
            get => leftList;
            set
            {
                SetProperty(ref leftList, value);
            }
        }


        private ObservableCollection<string> rightList;
        public ObservableCollection<string> RightList
        {
            get => rightList;
            set
            {
                SetProperty(ref rightList, value);
            }
        }
        public ICommand exitCmd { get; }
        public ICommand MoveAllRightCmd { get; }
        public ICommand MoveAllLeftCmd { get; }

        public MainWindowViewModel()
        {
            exitCmd = new DelegateCommand(execExit);
            MoveAllRightCmd = new DelegateCommand(ExecMoveAllRight);
            MoveAllLeftCmd = new DelegateCommand(ExecMoveAllLeft);

            LeftList = new ObservableCollection<string> { "Richard","Edward","Harry" };
            RightList = new ObservableCollection<string> { "Kelly", "Megan", "Freya" };
        }

        private void execExit()
        {
            Application.Current.Shutdown();
        }

        private void ExecMoveAllRight()
        {
            if (LeftList.Count>0)
            {
                RightList.AddRange(LeftList);
                LeftList.Clear();
            }
        }

        private void ExecMoveAllLeft()
        {
            if (RightList.Count > 0)
            {
                LeftList.AddRange(RightList);
                RightList.Clear();
            }
        }

    }
}
