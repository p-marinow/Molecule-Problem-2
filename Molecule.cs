using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class Molecule
    {
        public bool visited;
        public Node Root;
        public List<Node> AllNodes = new List<Node>();

        public Node CreateRoot(string name)
        {
            Root = CreateNode(name);
            return Root;
        }

        public Node CreateNode(string name)
        {
            var n = new Node(name);
            AllNodes.Add(n);
            return n;
        }

        public int?[,] CreateAdjMatrix()
        {
            int?[,] adj = new int?[AllNodes.Count, AllNodes.Count];

            for (int i = 0; i < AllNodes.Count; i++)
            {
                Node n1 = AllNodes[i];

                for (int j = 0; j < AllNodes.Count; j++)
                {
                    Node n2 = AllNodes[j];

                    var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weigth;
                    }
                }
            }
            return adj;
        }

        ////////////////////////////////////////////////////
        public void BFS(Node source, List<Node> vertices)
        {
            int currentNode = 0;
            source.min = 0;
            Queue<Node> Q = new Queue<Node>();
            Console.Write("\t    ");
            Console.Write("Molecule: ");
            foreach (Node v in vertices)
            {
                Q.Enqueue(v);
                Console.Write("{0}", v.Name);
            }

            Console.WriteLine();
            while (Q.Count != 0)
            {
                Node u = Q.Dequeue();
                currentNode++;
                Console.WriteLine();
                Console.WriteLine("Current ELEMENT: {0}", u.Name);
                
                foreach (Arc arcs in u.Arcs)
                {
                    Node v = arcs.Child;
                    int weight = arcs.Weigth;

                    int tempDistance = u.min + weight;
                    if (currentNode < vertices.Count)
                    {
                        //Q.Dequeue();
                        v.min = tempDistance;
                        v.previous = u;
                        //Q.Enqueue(v); // <= bug
                        Console.WriteLine("       BOUND TO: {0}{1}", (arcs.Weigth == 1) ? "-" : (arcs.Weigth == 2) ? "=" : "#", v.Name);
                    }
                }
            }

            /*  Dijkstra’s Algorithm (Breadth-first search /обхождане в ширина/)
              За всеки връх се пази по едно число, показващо дължината най-късия път, намерен до момента, до този връх. 
              Отначало (когато все още не е открит никакъв път) 
              тези числа са равни на безкрайност, а в течение на работата на алгоритъма намаляват при откриване на все по-къси пътища.
            */

        } // <- END BFS


        static void Main()
        {
            //ELEMENTS
            List<Dictionary<string, Atom>> elements = new List<Dictionary<string, Atom>>();
                elements.Add(new Dictionary<string, Atom>());
                elements[0].Add("H", new Atom() { AtomId = 1, AtomSymbol = "H", AtomName = "Hydrogen", AtomMass = 1.0079, AtomRadius = 25 });

                elements.Add(new Dictionary<string, Atom>());
                elements[1].Add("C", new Atom() { AtomId = 6, AtomSymbol = "C", AtomName = "Carbon", AtomMass = 12.0107, AtomRadius = 70 });

                elements.Add(new Dictionary<string, Atom>());
                elements[2].Add("N", new Atom() { AtomId = 7, AtomSymbol = "N", AtomName = "Nitrogen", AtomMass = 14.0067, AtomRadius = 65 });

                elements.Add(new Dictionary<string, Atom>());
                elements[3].Add("O", new Atom() { AtomId = 8, AtomSymbol = "O", AtomName = "Oxygen", AtomMass = 15.9994, AtomRadius = 60 });

                elements.Add(new Dictionary<string, Atom>());
                elements[4].Add("P", new Atom() { AtomId = 15, AtomSymbol = "P", AtomName = "Phosphorus", AtomMass = 30.9730, AtomRadius = 100 });

                elements.Add(new Dictionary<string, Atom>());
                elements[4].Add("S", new Atom() { AtomId = 16, AtomSymbol = "S", AtomName = "Sulfur", AtomMass = 32.0600, AtomRadius = 127 });

                elements.Add(new Dictionary<string, Atom>());
                elements[5].Add("Fe", new Atom() { AtomId = 26, AtomSymbol = "Fe", AtomName = "Iron", AtomMass = 55.8450, AtomRadius = 140 });

                elements.Add(new Dictionary<string, Atom>());
                elements[6].Add("Co", new Atom() { AtomId = 27, AtomSymbol = "Co", AtomName = "Cobalt", AtomMass = 58.9332, AtomRadius = 135 });

                elements.Add(new Dictionary<string, Atom>());
                elements[7].Add("Au", new Atom() { AtomId = 79, AtomSymbol = "Au", AtomName = "Gold", AtomMass = 196.9665, AtomRadius = 135 });

                elements.Add(new Dictionary<string, Atom>());
                elements[8].Add("Pb", new Atom() { AtomId = 82, AtomSymbol = "Pb", AtomName = "Lead", AtomMass = 207.2000, AtomRadius = 180 });

            Console.WriteLine("AtomId: {0}   AtomSymbol: {1}   AtomName: {2}   AtomMass: {3}", 
                              elements[0]["H"].AtomId,
                              elements[0]["H"].AtomSymbol,
                              elements[0]["H"].AtomName,
                              elements[0]["H"].AtomMass);
            Console.WriteLine("AtomId: {0}   AtomSymbol: {1}   AtomName: {2}     AtomMass: {3}",
                              elements[1]["C"].AtomId,
                              elements[1]["C"].AtomSymbol,
                              elements[1]["C"].AtomName,
                              elements[1]["C"].AtomMass);
            Console.WriteLine();
            Console.WriteLine("\t    HHC=C(CHHH)(CHHH)"); // Butene(c4h8)
                                   //abc d efgh  ijkl
                                  // a->c b c->d d->e d->i  e->f e->g  e->h  i->j  i->k  i->l
                                     
            var graph = new Molecule();

            var a = graph.CreateRoot(elements[0]["H"].AtomSymbol);
            var b = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var c = graph.CreateNode(elements[1]["C"].AtomSymbol);
            var d = graph.CreateNode(elements[1]["C"].AtomSymbol);
            var e = graph.CreateNode(elements[1]["C"].AtomSymbol);
            var f = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var g = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var h = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var i = graph.CreateNode(elements[1]["C"].AtomSymbol);
            var j = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var k = graph.CreateNode(elements[0]["H"].AtomSymbol);
            var l = graph.CreateNode(elements[0]["H"].AtomSymbol);

            a.AddArc(c, 1); //edge, typeRelation

            b.AddArc(c, 1);

            c.AddArc(d, 2);

            d.AddArc(e, 1)
                .AddArc(i, 1);

            e.AddArc(f, 1)
                .AddArc(g, 1)
                .AddArc(h, 1);

            i.AddArc(j, 1)
                .AddArc(k, 1)
                .AddArc(l, 1);

            //Adds double sided relations//
            ///////////////////////////////


            void AddAtom(int i, string symbol)
            {
                //Regex reg = new Regex(@" ^[A - Z] + $");
                var z = graph.CreateNode(elements[i][symbol].AtomSymbol);
                if (i == 1) //add Hydrogen
                {
                    z.AddArc(c, 1);
                }
                else if (i == 2) //add Carbon
                {
                    z.AddArc(c, 2);
                }

            } // OOP problem
            //AddAtom(1, "H");

            void DeleteAtom(int i, string symbol) 
            {
                var z = graph.CreateNode(elements[i][symbol].AtomSymbol);
                b.AddArc(c, 0);
            } // OOP problem
            //DeleteAtom(1, "H");

            //Functions 

            int?[,] adj = graph.CreateAdjMatrix();

            PrintMatrix(ref adj, graph.AllNodes.Count);

            static void PrintMatrix(ref int?[,] matrix, int Count)
            {
                Console.Write("       ");

                Console.WriteLine();

                for (int i = 0; i < Count; i++)
                {
                    Console.Write(" [ ");

                    for (int j = 0; j < Count; j++)
                    {
                        if (i == j)
                        {
                            Console.Write("   ");
                        }
                        else if (matrix[i, j] == null)
                        {
                            Console.Write(" 0 ");
                        }
                        else
                        {
                            if (matrix[i, j] == 1)
                            {
                                Console.Write(" - ", matrix[i, j]); // - single relation
                            }
                            else if (matrix[i, j] == 2)
                            {
                                Console.Write(" = ", matrix[i, j]); // = double relation
                            }
                            else if (matrix[i, j] == 3)
                            {
                                Console.Write(" # ", matrix[i, j]); // # triple relation
                            }
                        }
                    }
                    Console.Write(" ]\r\n");
                }
                Console.Write("\r\n");
            }

            Molecule BFS = new Molecule();
            BFS.BFS(graph.Root, graph.AllNodes);
        }
    }
}


