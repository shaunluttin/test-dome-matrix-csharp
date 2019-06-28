using System;
using System.Collections.Generic;
using System.Linq;

public class Platformer
{
    private const int _stepsPerJump = 2;

    private int _currentIndex;

    private List<int> _remainingTiles;

    public Platformer(int numberOfTiles, int position)
    {
        _currentIndex = position;
        _remainingTiles = Enumerable.Range(0, numberOfTiles).ToList();
    }

    public void JumpLeft()
    {
        _remainingTiles.RemoveAt(_currentIndex);
        _currentIndex -= 2;
    }

    public void JumpRight()
    {
        _remainingTiles.RemoveAt(_currentIndex);
        _currentIndex += 1;
    }

    public int Position()
    {
        return _remainingTiles[_currentIndex];
    }

    public static void Main(string[] args)
    {
        Platformer platformer = new Platformer(6, 3);
        Console.WriteLine("Current position:" + platformer.Position()); // should print 3

        platformer.JumpLeft();
        Console.WriteLine("Current position:" + platformer.Position()); // should print 1

        platformer.JumpRight();
        Console.WriteLine("Current position:" + platformer.Position()); // should print 4

        /**
         * Test with large number of tiles for performance.
         */

        const int tiles = 214748364;
        const int center = tiles / 2;

        Platformer platformerToo = new Platformer(tiles, center + 3);
        Console.WriteLine(platformerToo.Position() == center + 3);

        platformerToo.JumpLeft();
        Console.WriteLine(platformerToo.Position() == center + 1);

        platformerToo.JumpRight();
        Console.WriteLine(platformerToo.Position() == center + 4);

        platformerToo.JumpRight();
        Console.WriteLine(platformerToo.Position() == center + 6);

        platformerToo.JumpRight();
        Console.WriteLine(platformerToo.Position() == center + 8);

        platformerToo.JumpLeft();
        Console.WriteLine(platformerToo.Position() == center + 5);

        platformerToo.JumpLeft();
        Console.WriteLine(platformerToo.Position() == center + 0);

        platformerToo.JumpRight();
        Console.WriteLine(platformerToo.Position() == center + 7);
    }
}