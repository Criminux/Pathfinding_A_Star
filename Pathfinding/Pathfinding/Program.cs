using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Program
    {
        public const int MapLenghtX = 5;
        public const int MapLenghtY = 5;


        static Node[,] map = new Node[MapLenghtX, MapLenghtY];


        static void Main(string[] args)
        {
            GenerateMap();

            AddObstacles();


            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(4, 4);

            FindPath(map, startPoint, endPoint);
        }

        private static void FindPath(Node[,] map, Point startPoint, Point endPoint)
        {
            Node endNode = map[endPoint.X, endPoint.Y];

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(map[startPoint.X, startPoint.Y]);
            openList[0].G_Cost = 0;

            while (!closedList.Contains(endNode))
            {
                foreach (Node node in openList)
                {
                    if (node.isWalkable == true)
                    {
                        if (node.Parent != null) node.G_Cost = node.Parent.G_Cost + 1;
                        node.H_Cost = Math.Abs(node.Position.X - endNode.Position.X) + Math.Abs(node.Position.Y - endNode.Position.Y);
                    }
                }

                for (int i = openList.Count - 1; i >= 0; i--)
                {
                    if (openList[i].isWalkable)
                    {
                        closedList.Add(openList[i]);



                        if (!(openList[i].leftNode.X == 100))
                        {
                            Node tempNode = map[openList[i].leftNode.X, openList[i].leftNode.Y];
                            tempNode.Parent = openList[i];
                            openList.Add(tempNode);
                        }

                        if (!(openList[i].rightNode.X == 100))
                        {
                            Node tempNode = map[openList[i].rightNode.X, openList[i].rightNode.Y];
                            tempNode.Parent = openList[i];
                            openList.Add(tempNode);
                        }

                        if (!(openList[i].upNode.X == 100))
                        {
                            Node tempNode = map[openList[i].upNode.X, openList[i].upNode.Y];
                            tempNode.Parent = openList[i];
                            openList.Add(tempNode);
                        }

                        if (!(openList[i].downNode.X == 100))
                        {
                            Node tempNode = map[openList[i].downNode.X, openList[i].downNode.Y];
                            tempNode.Parent = openList[i];
                            openList.Add(tempNode);
                        }
                    }
                    


                }
            }

            Stack<Node> path = new Stack<Node>();
            Node current = endNode;
            while (true)
            {
                path.Push(current);

                if (current.Position.X == 0 && current.Position.Y == 0) break;

                current = current.Parent;
            }
            
            foreach (Node node in path)
            {
                Console.Write(node.Position.X.ToString());
                Console.WriteLine(node.Position.Y.ToString());

            }

            Console.Read();

        }

        private static void GenerateMap()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = new Node(new Point(i,j), true);
                }
            }
        }

        private static void AddObstacles()
        {
            map[2, 0].isWalkable = false;
            map[2, 1].isWalkable = false;
            map[2, 2].isWalkable = false;
            map[1, 2].isWalkable = false;
            map[3, 4].isWalkable = false;


            /*      
             *      O O X O O
             *      O O X O O
             *      O X X O O
             *      O O O O O
             *      O O O X O
             */
        }
    }
}
