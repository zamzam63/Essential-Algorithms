using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SelfAvoidingWalk{

    class Program{

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = FindWalk(300,300);
            foreach (Point point in result){
                Console.WriteLine("X = {0}, Y = {1}", point.X, point.Y);
            }
        }

        // Find a random self-avoiding walk.
        static private List<Point> FindWalk(int width, int height)
        {
            // Make an array to show where we have been.
            bool[,] visited = new bool[width, height];

            // Start at a random vertex.
            Random rand = new Random();
            int x = rand.Next(0, width);
            int y = rand.Next(0, height);

            // Start the walk at (x, y).
            List<Point> walk = new List<Point>();
            walk.Add(new Point(x, y));
            visited[x, y] = true;

            // Repeat until we can no longer move.
            for (;;)
            {
                // Make a list of potential neighbors.
                List<Point> candidates = new List<Point>();
                candidates.Add(new Point(x - 1, y));
                candidates.Add(new Point(x + 1, y));
                candidates.Add(new Point(x, y - 1));
                candidates.Add(new Point(x, y + 1));

                // See which neighbors are on the lattice and unvisited.
                List<Point> neighbors = new List<Point>();
                foreach (Point point in candidates)
                    if ((point.X >= 0) && (point.X < width) &&
                        (point.Y >= 0) && (point.Y < height) &&
                        !visited[point.X, point.Y])
                        neighbors.Add(point);

                // If we have no unvisited neighbors, then we're stuck.
                if (neighbors.Count == 0) break;

                // Pick a random neighbor to visit.
                Point next = neighbors.Random();

                // Go there.
                walk.Add(next);
                visited[next.X, next.Y] = true;
                x = next.X;
                y = next.Y;
            }

            return walk;
        }
        
    }

    class Point{
        public int X {get; set;}
        public int Y {get; set;}

        public Point(int x, int y){
            this.X = x;
            this.Y = Y;
        }
    }
}

