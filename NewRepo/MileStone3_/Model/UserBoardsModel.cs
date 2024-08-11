using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class UserBoardsModel : NotifiableModelObject
    {
        private readonly UserModel user;
        public ObservableCollection<BoardModel> Messages { get; set; }

        private UserBoardsModel(BackendController controller, ObservableCollection<BoardModel> messages) : base(controller)
        {
            Messages = messages;
            Messages.CollectionChanged += HandleChange;
        }

        public UserBoardsModel(BackendController controller, UserModel user) : base(controller)
        {
            this.user = user;
            Messages = new ObservableCollection<BoardModel>(controller.getAllBoards(user.Email));
            Messages.CollectionChanged += HandleChange;
        }



        public void RemoveMessage(BoardModel t)
        {

            Messages.Remove(t);

        }

        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            //read more here: https://stackoverflow.com/questions/4279185/what-is-the-use-of-observablecollection-in-net/4279274#4279274
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (BoardModel y in e.OldItems)
                {

                    Controller.DeleteBoard(user.Email, y.BoardName);
                }

            }
        }


    }
}
