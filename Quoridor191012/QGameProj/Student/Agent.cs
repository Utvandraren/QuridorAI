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
        Graph aiGraph = new Graph(9,bräde);
        BreadthFirstSearch dragSearch = new BreadthFirstSearch(aiGraph, playerPos);
        for (int i = 0; i < 9; i++)
        {
            foreach (Point x in dragSearch.PathTo(new Point(i,8)))
            {
                //fixa till att den väljer den kortaste vägen till andra sidan av alla punkterna
                if (x.X < playerPos.X)
                {
                    drag.typ = Typ.Flytta;
                    drag.point = playerPos;
                    drag.point.X--;
                    return drag;
                }
                if (x.X > playerPos.X)
                {
                    drag.typ = Typ.Flytta;
                    drag.point = playerPos;
                    drag.point.X++;
                    return drag;
                }
                if (x.Y < playerPos.Y)
                {
                    drag.typ = Typ.Flytta;
                    drag.point = playerPos;
                    drag.point.Y--;
                    return drag;
                }
                if (x.Y > playerPos.Y)
                {
                    drag.typ = Typ.Flytta;
                    drag.point = playerPos;
                    drag.point.Y++;
                    return drag;
                }
            }
        }

        //if (jag.antalVäggar == 10) {
        //    drag.typ = Typ.Horisontell;
        //    drag.point = new Point(3, 6);
        //}
        //else if (jag.antalVäggar == 9) {
        //    drag.typ = Typ.Horisontell;
        //    drag.point = new Point(5, 6);
        //}
        //else {
        //    drag.typ = Typ.Flytta;
        //    drag.point = playerPos;
        //    drag.point.Y++;
        //}
        return drag;
    }
    public override Drag GörOmDrag(SpelBräde bräde, Drag drag) {
        //Om draget ni försökte göra var felaktigt så kommer ni hit
        System.Diagnostics.Debugger.Break();    //Brytpunkt
        return SökNästaDrag(bräde);
    }
}
//enum Typ { Flytta, Horisontell, Vertikal }
//struct Drag {
//    public Typ typ;
//    public Point point;
//}