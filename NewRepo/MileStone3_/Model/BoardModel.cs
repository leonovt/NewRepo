using System.Collections.ObjectModel;

namespace Frontend.Model
{
    public class BoardModel : NotifiableModelObject
    {
        private readonly string userEmail;

        private string ownerEmail;

        public string OwnerEmail
        {
            get => ownerEmail;
            set
            {
                this.ownerEmail = value;
                RaisePropertyChanged("Body");
            }
        }

        private string _boardname;
        public string BoardName
        {
            get => _boardname;
            set
            {
                this._boardname = value;
                RaisePropertyChanged("Title");
            }
        }

        private List<string> boardMembers;
        
        internal ObservableCollection<TaskModel> InProgress { get; set; }      
        internal ObservableCollection<TaskModel> BackLog { get; set; }      
        internal ObservableCollection<TaskModel> Done { get; set; }

        internal string Test {get; set;}

        

        public BoardModel(BackendController controller, string userEmail, string ownerEmail ,string boardNam, List<string> boardM) : base(controller)
        {
            this.BoardName = boardNam;
            this.boardMembers = boardM;
            this.userEmail = userEmail;
            InProgress = Controller.GetAllTasksFromColumn(userEmail,BoardName,0);
            BackLog = Controller.GetAllTasksFromColumn(userEmail,BoardName,1);
            Done = Controller.GetAllTasksFromColumn(userEmail,BoardName,2);  
            this.ownerEmail =  ownerEmail; 
            this.Test = "Elad";       
          
          
          //Tasks.CollectionChanged += HandleChange;
        }
        
    
        
        // private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        // {
        //     //read more here: https://stackoverflow.com/questions/4279185/what-is-the-use-of-observablecollection-in-net/4279274#4279274
        //     if (e.Action == NotifyCollectionChangedAction.Remove)
        //     {
        //         foreach (TaskModel y in e.OldItems)
        //         {
        //             //do nothing
        //         }

        //     }
        // }
    }
}
