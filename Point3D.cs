using System;

namespace Exam
{
    public class Point3D
    {
        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        } //constructor 3D

        public double X
        {
            get { return x; }
            set { x = value; }
        } //property X
        
        public double Y
        {
            get { return y; }
            set { y = value; }
        } //property Y

        public double Z
        {
            get { return z; }
            set { z = value; }
        } //property Z

        public override bool Equals(object obj)
        {
            if(this == obj)
                return true;

            Point3D other = obj as Point3D;

            if (other == null)
                return false;

            if (!this.x.Equals(other.x))
                return false;

            if (!this.y.Equals(other.y))
                return false;

            if (!this.z.Equals(other.z))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = (int)Math.Round((x + y + z));
            return result;
        } 
    }
}