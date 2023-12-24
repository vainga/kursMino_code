using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursCode.MVVM.ViewModel
{
    public class ClientSkillViewModel : INotifyPropertyChanged
    {
        private string text;
        private string hintText;
        private string lastButtonName;

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public string HintText
        {
            get { return hintText; }
            set
            {
                if (hintText != value)
                {
                    hintText = value;
                    OnPropertyChanged(nameof(HintText));
                }
            }
        }

        public ICommand HintCommand { get; }

        public ClientSkillViewModel()
        {
            QualityButtonCommand = new RelayCommand(() => ChangeHintText("QualityButton"));
            SkillButtonCommand = new RelayCommand(() => ChangeHintText("SkillButton"));
        }

        public ICommand QualityButtonCommand { get; }
        public ICommand SkillButtonCommand { get; }

        private void ChangeHintText(string buttonName)
        {
            lastButtonName = buttonName;

            if (buttonName == "QualityButton")
            {
                HintText = "Качество";
            }
            else if (buttonName == "SkillButton")
            {
                HintText = "Навык";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
