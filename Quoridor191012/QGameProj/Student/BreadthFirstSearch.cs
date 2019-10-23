using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


class BreadthFirstSearch
{
    private bool[,] marked;
    private Point[,] edgeTo;
    private Point s;

    public BreadthFirstSearch(Graph G, Point s)
    {
        marked = new bool[G.V, G.V];
        edgeTo = new Point[G.V, G.V];
        this.s = s;
        bfs(G, s);
    }

    private void bfs(Graph G, Point s)
    {
        Queue<Point> queue = new Queue<Point>();
        marked[s.X, s.Y] = true;
        queue.Enqueue(s);

        while (queue.Any())
        {
            Point v = queue.Dequeue();

            foreach (Point p in G.adj[v.X,v.Y])
            {
                if (!marked[p.X, p.Y])
                {
                    edgeTo[p.X, p.Y] = v;
                    marked[p.X, p.Y] = true;
                    queue.Enqueue(p);
                }
            }
        }
    }

    public IEnumerable <Point> PathTo(Point v)
    {
        if (!HasPathTo(v))
        {
            return null;
        }
        Stack<Point> path = new Stack<Point>();        
        for (Point x = v; x != s;x = edgeTo[x.X,x.Y])
        {
            path.Push(x);
        }
        path.Push(s);
        return path;
    }

    public bool HasPathTo(Point v)
    {
        return marked[v.X, v.Y];
    }

}

