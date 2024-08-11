using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using IntroSE.Kanban.Backend.ServiceLayer;
using KanBan_2024.ServiceLayer;
using Microsoft.VisualBasic;


namespace Frontend.Model
{
    public class BackendController
    {
        private ServiceFactory Service { get; set; }
        public BackendController(ServiceFactory service)
        {
            this.Service = service;
        }

        private bool flag = true;
        public BackendController()
        {
            this.Service = new ServiceFactory();
            Service.DeleteData();
            Service.LoadData();
/*
            if(flag){
                Service.DeleteData();
                flag = false;
            }
*/            
            
            //if(flag){
            //string email ="mail@mail.com";
            //string board1 = "board1";
            //Service.SignIn(email,"Password1");
            //Service.CreateBoard(email,board1);
            //Service.AddTask(email,board1,"title1","describtion1", DateTime.Now.AddDays(1));
            //Service.AssignTask(email,board1,0,0,email);
            //Service.AdvanceTask(email,board1,0);
            //Service.AdvanceTask(email,board1,0);

            //Service.AddTask(email,board1,"title2","describtion2", DateTime.Now.AddDays(2));
            //Service.AssignTask(email,board1,0,1,email);
            //Service.AdvanceTask(email,board1,1);
            //Service.AddTask(email,board1,"title3","describtion3", DateTime.Now.AddDays(3));

            //Service.CreateBoard(email,"board2");
            //Service.Logout(email);
            //flag = false;
            
            //}
           


        }
        internal UserModel Register(string email, string password)
        {
            Response? res = JsonSerializer.Deserialize<Response>(Service.US.Register(email, password));
            if (res.ErrorMessage != null)
            {
                throw new Exception(res.ErrorMessage);  
            }
            ObservableCollection<BoardModel> bords = getAllBoards(email);

            return new UserModel(this,email);
        }

        public void LogOut(string email)
        {
            Response? user = JsonSerializer.Deserialize<Response>(Service.US.Logout(email));
            if (user?.ErrorMessage != null)
            {
                throw new Exception(user.ErrorMessage);
            }
        }
        
        public UserModel Login(string email, string password)
        {
            Response? res = JsonSerializer.Deserialize<Response>(Service.US.Login(email, password));
            if (res?.ErrorMessage != null)
            {
                throw new Exception(res.ErrorMessage);  
            }
            ObservableCollection<BoardModel> bords = getAllBoards(email);
            
            return new UserModel(this,email);
        }


        internal BoardModel CreateBoard(UserModel user, string boardName)
        {
            Response? res = JsonSerializer.Deserialize<Response>(Service.BS.CreateBoard(user.Email, boardName));
            if (res?.ErrorMessage != null)
            {
                throw new Exception(res.ErrorMessage);
            }
            List<string> Members = new List<string>();
            Members.Add(user.Email);
            return new BoardModel(this, user.Email, user.Email, boardName, Members);
        }


        internal void DeleteBoard(string email, string boardName)
        {
            Response? res = JsonSerializer.Deserialize<Response>(Service.BS.DeleteBoard(email, boardName));
            if (res.ErrorMessage != null)
            {
                throw new Exception(res.ErrorMessage);
            }
            MessageBox.Show("Message was removed successfully");
        }

        internal ObservableCollection<TaskModel> GetAllTasksFromColumn(string email,string boardName, int columnOrdinal)
        {
            string s=Service.BS.GetColumn(email, boardName,columnOrdinal);
            Response r = JsonSerializer.Deserialize<Response>(s);

            List<taskSL> Tasks = ConvertReturnValue<List<taskSL>>(r?.ReturnValue);
            ObservableCollection<TaskModel> TaskModel = new ObservableCollection<TaskModel>();
            if(Tasks != null){
                foreach(taskSL t in Tasks){
                    TaskModel.Add(new TaskModel(this ,t.Id, t.Title ,t.Description ,t.DueDate, t.Assignee));
                }
            }
            return TaskModel;
        }


        public T ConvertReturnValue<T>(object returnValue)
        {
            if (returnValue is JsonElement jsonElement)
            {
                return JsonSerializer.Deserialize<T>(jsonElement);
            }
            return (T)returnValue;
        }

        internal ObservableCollection<BoardModel> getAllBoards(string email)
        {
            
            Response? boardsIndexs = JsonSerializer.Deserialize<Response>(Service.BS.GetUserBoards(email));
            object ? ids = boardsIndexs.ReturnValue;
            List<int>? boards = null;
            if (ids is JsonElement jsonElement)
            {
                 boards = JsonSerializer.Deserialize<List<int>>(jsonElement.GetRawText());
            }
            ;
            ObservableCollection<BoardModel> BoardModel = new ObservableCollection<BoardModel>();
            foreach(int id in boards)
            {
                Response res = Service.BS.GetBoard(email, id);
                BoardSL b =(BoardSL) res.ReturnValue;
                List<string> users = Service.BS.GetBoardUsers(id);


                BoardModel.Add(new BoardModel(this ,email ,b.boardOwner, b.boardName, users));

                //BoardSL b = JsonSerializer.Deserialize<BoardSL>(res.ReturnValue.ToString());
                //BoardModel.Add(new BoardModel(this ,email ,b.boardName, b.Members));
            } 
            return BoardModel;
        }

    }

}
