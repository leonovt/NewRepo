using KanBan_2024.ServiceLayer;
using MileStone3_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MileStone3_.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            controller = new BackendController();
        }

        private string _labelText;

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                if (_labelText != value)
                {
                    _labelText = value;
                    OnPropertyChanged(nameof(LabelText));
                }
            }
        }

        public BackendController controller { get; private set; }

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool Login()
        {
            string s = controller.login(Username, Password);

            Response? r = JsonSerializer.Deserialize<Response?>(s);
            if (r.ReturnValue != null)
            {
                return true;
            }
            LabelText = r.ErrorMessage;
            return false;

        }

        public bool Register()
        {
            string s = controller.register(Username, Password);

            Response? r = JsonSerializer.Deserialize<Response?>(s);
            if (r.ReturnValue != null)
            {
                return true;
            }
            LabelText = r.ErrorMessage;
            return false;

        }
    }
}
