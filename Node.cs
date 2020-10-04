using System.Collections.Generic;

namespace Exam
{
    public class Node
    {
        public string Name;
        public Node previous; //bfs Parent => this
        public List<Arc> Arcs = new List<Arc>();

        public int min = int.MaxValue;

        public Node(string name)
        {
            Name = name;
        }

        public Node AddArc(Node child, int w)
        {
            Arcs.Add(new Arc
            {
                Parent = this,
                Child = child,
                Weigth = w
            });

            if (!child.Arcs.Exists(a => a.Parent == child && a.Child == this))
            {
                child.AddArc(this, w);  //this.class, bond
            }

            return this;
        }
    }
}
