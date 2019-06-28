using System;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();

        p.TestSmall((tiles, position) => new PlatformerFast(tiles, position));
        p.TestSmall((tiles, position) => new PlatformerSlow(tiles, position));

        p.TestLarge((tiles, position) => new PlatformerSlow(tiles, position));
        p.TestLarge((tiles, position) => new PlatformerFast(tiles, position));
    }

    public void TestSmall(Func<int, int, Platformer> build)
    {
        Platformer platformer = build(6, 3);
        Debug.Assert(platformer.Position() == 3);

        platformer.JumpLeft();
        Debug.Assert(platformer.Position() == 1);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == 4);
    }

    public void TestLarge(Func<int, int, Platformer> build)
    {
        Console.WriteLine("Running large test...");

        const int tiles = int.MaxValue / 2;
        const int center = tiles / 2;

        Platformer platformer = build(tiles, center + 3);
        Debug.Assert(platformer.Position() == center + 3);

        var watch = Stopwatch.StartNew();

        platformer.JumpLeft();
        Debug.Assert(platformer.Position() == center + 1);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 4);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 6);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 8);

        platformer.JumpLeft();
        Debug.Assert(platformer.Position() == center + 5);

        platformer.JumpLeft();
        Debug.Assert(platformer.Position() == center + 0);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 7);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 10);

        platformer.JumpRight();
        Debug.Assert(platformer.Position() == center + 12);

        platformer.JumpLeft();
        Debug.Assert(platformer.Position() == center + 9);

        Console.WriteLine($"{platformer.GetType().Name} completes in {watch.ElapsedMilliseconds} ms");
    }
}