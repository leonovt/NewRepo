using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanBan_2024.ServiceLayer;


namespace MileStone3_.Model
{
    public class BackendController
    {
        private ServiceFactory _serviceFactory;
        public BackendController() {
            _serviceFactory = new ServiceFactory();
            _serviceFactory.LoadData();
        }


        public string login(string email, string password)
        {
            return _serviceFactory.US.Login(email, password);
        }

        public string register(string email, string password)
        {
            return _serviceFactory.US.Register(email, password);
        }

        public string getUserBoards(string userEmail)
        {
            return _serviceFactory.BS.GetUserBoards(userEmail);
        }

        public string createBoard(string userEmail, string name)
        {
            return _serviceFactory.BS.CreateBoard(userEmail, name);
        }
    }
}
