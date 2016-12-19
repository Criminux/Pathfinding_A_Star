using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{

    public struct Point
    {
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X;
        public int Y;
    }

    public class Node
    {
        public const int MapLenghtX = 5;
        public const int MapLenghtY = 5;

        public Point Position;

        public Node Parent;
        public Point leftNode;
        public Point rightNode;
        public Point upNode;
        public Point downNode;

        public int G_Cost; //From Start to this Node
        public int H_Cost; //Estimated cost to end

        public bool isWalkable;

        public int F_Cost
        {
            get { return G_Cost + H_Cost; }
        }


        public Node (Point position, bool isWalkable)
        {
            this.Position = position;
            this.isWalkable = isWalkable;

            if (Position.X != 0) leftNode = new Point(Position.X - 1, Position.Y); else leftNode = new Point(100, 100);
            if (Position.X != MapLenghtX - 1) rightNode = new Point(Position.X + 1, Position.Y); else rightNode = new Point(100, 100);
            if (Position.Y != 0) upNode = new Point(Position.X, Position.Y - 1); else upNode = new Point(100, 100);
            if (Position.Y != MapLenghtY - 1) downNode = new Point(Position.X, Position.Y + 1); else downNode = new Point(100, 100);
        }
    }
}
