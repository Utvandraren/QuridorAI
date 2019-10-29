using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class Agent :BaseAgent {
    [STAThread]
    static void Main() {
        Program.Start(new Agent());
    }
    public Agent() { }
    public override Drag SökNästaDrag(SpelBräde bräde) {
        Spelare jag = bräde.spelare[0];
        Point playerPos = jag.position;
        Drag drag = new Drag();
        Graph aiGraph = new Graph(9,bräde);
        BreadthFirstSearch search = new BreadthFirstSearch(aiGraph, playerPos);
        int currentSteps = 0;
        int lowestSteps = 100;
        int pathPos = 0;
        Point lowestPathPos = new Point(0,0);

        for (int i = 0; i < 9; i++)
        {
            foreach (Point x in search.PathTo(new Point(i, 8)))
            {
                ++currentSteps;
            }

            if (currentSteps < lowestSteps)
            {
                lowestSteps = currentSteps;
                lowestPathPos = new Point(i, 8);
                pathPos = i;
            }
            currentSteps = 0;
        }

        foreach (Point nextStep in search.PathTo(new Point(pathPos, 8)))
        {
            if (nextStep.X < playerPos.X)
            {
                drag.typ = Typ.Flytta;
                drag.point = playerPos;
                drag.point.X--;
                return drag;
            }
            if (nextStep.X > playerPos.X)
            {
                drag.typ = Typ.Flytta;
                drag.point = playerPos;
                drag.point.X++;
                return drag;
            }
            if (nextStep.Y < playerPos.Y)
            {
                drag.typ = Typ.Flytta;
                drag.point = playerPos;
                drag.point.Y--;
                return drag;
            }
            if (nextStep.Y > playerPos.Y)
            {
                drag.typ = Typ.Flytta;
                drag.point = playerPos;
                drag.point.Y++;
                return drag;
            }
        }

        return drag;
    }
    public override Drag GörOmDrag(SpelBräde bräde, Drag drag) {
        //Om draget ni försökte göra var felaktigt så kommer ni hit
        System.Diagnostics.Debugger.Break();    //Brytpunkt
        return SökNästaDrag(bräde);
    }

    private Drag whatDirection(Point x,Point playerPos,Drag drag)
    {
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

        return drag;

    }
}
//enum Typ { Flytta, Horisontell, Vertikal }
//struct Drag {
//    public Typ typ;
//    public Point point;
//}