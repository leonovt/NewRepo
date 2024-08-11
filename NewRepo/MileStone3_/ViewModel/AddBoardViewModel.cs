using Frontend.Model;
using MileStone3_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
    internal class AddBoardViewModel : NotifiableObject
    {
        public BackendController Controller { get; private set; }
        private UserModel user;


        private string _boardname;
        public string BoardName
        {
            get => _boardname;
            set
            {
                this._boardname = value;
                RaisePropertyChanged("BoardName");
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                this._message = value;
                RaisePropertyChanged("Message");
            }
        }

        public BoardModel AddBoard()
        {
            Message = "";
            try
            {
                return Controller.CreateBoard(user, BoardName);
            }
            catch (Exception e)
            {
                Message = e.Message;
                return null;
            }
        }

        public AddBoardViewModel(UserModel user)
        {
            this.user = user;
            this.Controller = new BackendController();
            this.BoardName = "New BoardName";
            
        }
    }
}
