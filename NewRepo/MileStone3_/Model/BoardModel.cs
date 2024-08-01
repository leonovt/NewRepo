using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone3_.Model
{
    internal class BoardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public BoardModel(int id, string name, string owner) {
            Id = id;
            Name = name;
            Owner = owner;
        }

    }
}
