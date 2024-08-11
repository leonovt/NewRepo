using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Frontend.Model
{
    public class TaskModel : NotifiableModelObject
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Assignee { get; set; }
    

        public TaskModel(BackendController controller, int id, string title, string description, DateTime dueDate, string Assignee) : base(controller)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.Assignee = Assignee;
        }
    }
}

