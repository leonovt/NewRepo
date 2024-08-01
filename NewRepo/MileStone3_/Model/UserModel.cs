using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone3_.Model
{
    public class UserModel
    {
        public UserModel(String username, String password) {
            this.password = password;
            this.username = username;   
        }
        public string username {  get; set; }
        public string password { get; set; }
    }
}
