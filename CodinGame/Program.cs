using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);

        Batman batman = new Batman(X0, Y0);

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            Direction directionValue = (Direction)Enum.Parse(typeof(Direction), bombDir);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Building building = new Building(W, H, N);
            
            int jump = building.DistanceBetweenBatmanAndWindow(batman,  directionValue);

            batman.SaveLastPosition();
            string nextWindow = batman.Move(jump, directionValue);
            batman.LastMoveDirection = directionValue;

            // the location of the next window Batman should jump to.
            Console.WriteLine(nextWindow);
            Console.ReadKey();
        }
    }
}

public class Building
{
    public int W { get; set; }
    public int H { get; set; }
    public int N { get; set; }

    public Building(int w, int h, int n)
    {
        W = w;
        H = h;
        N = n;
    }

    public int DistanceBetweenBatmanAndWindow(Batman batman, Direction direction)
    {
        int valueX;
        int valueY;
        int maxH;
        int maxW;
        int value = 0;

        if (batman.LastMoveDirection != null && direction == OppositeDirection((Direction)batman.LastMoveDirection))
        {
            maxH = batman.LastY;
            maxW = batman.LastX;
        }
        else
        {
            maxH = H;
            maxW = W;
        }

        switch (direction)
        {
            case Direction.R:
                value = Math.Abs((maxW - batman.X)/2);
                break;
            case Direction.L:
                value = Math.Abs(batman.X / 2);
                break;
            case Direction.U:
                value = Math.Abs(batman.Y / 2);
                break;
            case Direction.D:
                value = Math.Abs((maxH - batman.Y) / 2);
                break;
            case Direction.UR:
                valueX = Math.Abs((maxW - batman.X) / 2);
                valueY = Math.Abs((batman.Y) / 2);
                value = Math.Min(valueX, valueY);
                break;
            case Direction.UL:
                valueX = Math.Abs((batman.X) / 2);
                valueY = Math.Abs((batman.Y) / 2);
                value = Math.Min(valueX, valueY);
                break;
            case Direction.DR:
                valueX = Math.Abs((maxW - batman.X) / 2);
                valueY = Math.Abs((maxH - batman.Y) / 2);
                value = Math.Min(valueX, valueY);
                break;
            case Direction.DL:
                valueX = Math.Abs((batman.X) / 2);
                valueY = Math.Abs((maxH - batman.Y) / 2);
                value = Math.Min(valueX, valueY);
                break;
        }

        return (value > 0 ? value : 1);
    }

    public Direction OppositeDirection(Direction direction)
    {
        switch(direction)
        {
            case Direction.U:
                return Direction.D;
            case Direction.UR:
                return Direction.DL;
            case Direction.R:
                return Direction.L;
            case Direction.DR:
                return Direction.UL;
            case Direction.D:
                return Direction.U;
            case Direction.DL:
                return Direction.UR;
            case Direction.L:
                return Direction.R;
            case Direction.UL:
                return Direction.DR;
            default:
                throw new ArgumentOutOfRangeException("direction", direction, null);
        }
    }
}

public class Batman
{
    public int X { get; set; }
    public int Y { get; set; }
    public int LastX { get; set; }
    public int LastY { get; set; }
    public Direction? LastMoveDirection { get; set; }

    public Batman(int x, int y)
    {
        X = x;
        Y = y;

        LastX = x;
        LastY = y;
        LastMoveDirection = null;
    }

    protected bool Equals(Batman other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Batman)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = 1861411795;
        hashCode = hashCode * -1521134295 + X.GetHashCode();
        hashCode = hashCode * -1521134295 + Y.GetHashCode();
        return hashCode;
    }

    public string Move(int jump, Direction direction)
    {
        switch (direction)
        {
            case Direction.U:
                Y -= jump;
                break;
            case Direction.UR:
                X += jump;
                Y -= jump;
                break;
            case Direction.R:
                X += jump;
                break;
            case Direction.DR:
                X += jump;
                Y += jump;
                break;
            case Direction.D:
                Y += jump;
                break;
            case Direction.DL:
                X -= jump;
                Y += jump;
                break;
            case Direction.L:
                X -= jump;
                break;
            case Direction.UL:
                X -= jump;
                Y -= jump;
                break;
        }
        return X + " " + Y;
    }

    public void SaveLastPosition()
    {
        LastX = X;
        LastY = Y;
    }
}

public enum Direction
{
    U,
    UR,
    R,
    DR,
    D,
    DL,
    L,
    UL
}