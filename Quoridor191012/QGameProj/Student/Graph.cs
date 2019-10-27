using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Graph
{
    public List<Point>[,] adj;
    public int E;
    public int V;
    private SpelBräde bräde;

    public Graph(int V,SpelBräde bräde)
    {
        this.bräde = bräde;
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
        //För alla rutor(R) i grafen.
        //• För alla omgivande rutor(4 stycken) A
        //• Kolla att A är inom spelbrädet
        //• Om R.X == A.X kolla att det inte finns en horisontell vägg
        //ivägen.
        //• Om R.Y == A.Y kolla att det inte finns en vertikal vägg ivägen.
        //• Lägg till A till som angränsande ruta till R.

        for (int x = 0; x < V; x++)
        {
            for (int y = 0; y < V; y++)
            {               
                if (x-1 >= 0)
                {
                    if (!bräde.vertikalaVäggar[x - 1,y])
                    {
                        AddEdge(new Point(x, y), new Point(x - 1, y));
                    }
                }
                if (x+1 < V)
                {                  
                   if (!bräde.vertikalaVäggar[x, y])
                   {
                       AddEdge(new Point(x, y), new Point(x + 1, y));
                   }
                }
                if (y-1 >= 0)
                {
                    if (!bräde.horisontellaVäggar[x, y - 1])
                    {
                        AddEdge(new Point(x, y), new Point(x, y - 1));
                    }
                }
                if (y+1 < V)
                {                   
                    if (!bräde.horisontellaVäggar[x, y])
                    {
                        AddEdge(new Point(x, y), new Point(x, y + 1));
                    }                                     
                }
            }
        }
    }

    public void AddEdge(Point v, Point w)
    {
        adj[v.X, v.Y].Add(w);
        //adj[w.X, w.Y].Add(v);
        ++E;
    }
    
}