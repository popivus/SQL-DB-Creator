using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabaseCreator
{
    public class BindingArrows
    {
        public Point startArrow { get; set; }
        public Point endArrow { get; set; }

        public bool isOneToOne { get; set; }

        public int parentTableId { get; set; }
        public int childTableId { get; set; }


        public BindingArrows(Point start, Point end, bool isOneToOne, int parent, int child)
        {
            startArrow = start;
            endArrow = end;
            this.isOneToOne = isOneToOne;
            parentTableId = parent;
            childTableId = child;
        }
    }
}
