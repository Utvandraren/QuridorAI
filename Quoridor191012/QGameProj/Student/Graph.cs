﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Graph
{
    Point[,] posArray;
    Point vertices;
    List<Point>[,] adj;
    int E;
    int V;

    public Graph(int V)
    {
        vertices = new Point(V, V);
        adj = new List<Point>[V, V];
        E = 0;
        this.V = V;

        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                adj[i, j] = new List<Point>();
            }
        }

        Startup();
    }

    void Startup()
    {
        //  För alla rutor(R) i grafen.
        //• För alla omgivande rutor(4 stycken) A
        //• Kolla att A är inom spelbrädet
        //• Om R.X == A.X kolla att det inte finns en horisontell vägg
        //ivägen.
        //• Om R.Y == A.Y kolla att det inte finns en vertikal vägg ivägen.
        //• Lägg till A till som angränsande ruta till R.

        for (int i = 0; i < vertices.X; i++)
        {
            for (int j = 0; j < vertices.Y; j++)
            {
                for (int l = i - 1; l < i + 2; l++)
                {
                    for (int k = j - 1; k < j + 2; k++)
                    {
                        if (l > 9 || l < 0 || k > 9 || k < 0 || i == l || j == l)
                        {
                            //Dont add
                        }
                        else
                        {
                            AddEdge(new Point(i, j), new Point(l, k));
                        }
                    }
                }
            }
        }
    }

    public void AddEdge(Point v, Point w)
    {
        adj[v.X, v.Y].Add(w);
        adj[w.X, w.Y].Add(v);
        ++E;
    }

    //public void reverse()
    //{
    //    Graph R = new Graph(V);
    //    for (int i = 0; i < V; i++)
    //    {
    //        for (int i = 0; i < V; i++)
    //        {
    //            for (int j = 0; j < V; j++)
    //            {
    //                R.AddEdge()
    //            }
    //        }
    //    }
    //}


}