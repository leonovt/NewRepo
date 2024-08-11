using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class UserModel : NotifiableModelObject
    {

        private string _email;
        internal string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }



        public UserBoardsModel GetBoards()
        {
            return new UserBoardsModel(Controller, this);
        }



        public UserModel(BackendController controller, string email) : base(controller)
        {
            this.Email = email;

        }

    }
    
}
