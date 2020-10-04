namespace Exam
{
    public class Atom
    {
        private int id;
        private string symbol;
        private string name;
        private double mass;
        private int radius;

        public Atom()
        {
            AtomId = this.id;
            AtomSymbol = this.symbol;
            AtomName = this.name;
            AtomMass = this.mass;
            AtomRadius = this.radius;
        }

        public int AtomId { get { return id; } set { id = value; } }
        public string AtomSymbol { get { return symbol; } set { symbol = value; } }
        public string AtomName { get { return name; } set { name = value; } }
        public double AtomMass { get { return mass; } set { mass = value; } }
        public int AtomRadius { get { return radius; } set { radius = value; } }
    }
}
