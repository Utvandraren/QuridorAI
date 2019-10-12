using Microsoft.Xna.Framework;
using System;

class Agent:BaseAgent {
    [STAThread]
    static void Main() {
        Program.Start(new Agent());
    }
    public Agent() { }
    public override Drag SökNästaDrag(SpelBräde bräde) {
        //Så ni kan kolla om systemet fungerar!
        Spelare jag = bräde.spelare[0];
        Point playerPos = jag.position;
        Drag drag = new Drag();



        if (jag.antalVäggar == 10)
        {
            drag.typ = Typ.Horisontell;
            drag.point = new Point(3, 6);
        }
        else if (jag.antalVäggar == 9)
        {
            drag.typ = Typ.Horisontell;
            drag.point = new Point(5, 6);
        }
        else
        {
            drag.typ = Typ.Flytta;
            drag.point = playerPos;
            drag.point.Y++;
        }
        return drag;
    }
    public override Drag GörOmDrag(SpelBräde bräde, Drag drag) {
        //Om draget ni försökte göra var felaktigt så kommer ni hit
        System.Diagnostics.Debugger.Break();    //Brytpunkt
        return SökNästaDrag(bräde);
    }

    //public void CreateGraph()
    //{
    //    Point[,] posArray = new Point[8, 8];

    //    for (int i = 0; i < 8; i++)
    //    {
    //        for (int j = 0; j < 8; j++)
    //        {
    //            if (i + 1 > 8 || j + 1 > 8 || i - 1 < 0 || j - 1 < 0)
    //            {
    //                //Utanför brädan
    //            }
    //        }
    //    }
    //}

    public void Graph()
    {

    }
}

//enum Typ { Flytta, Horisontell, Vertikal }
//struct Drag
//{
//    public Typ typ;
//    public Point point;
//}