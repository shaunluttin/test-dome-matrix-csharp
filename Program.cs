using System;

public class Platformer
{
    private const int _stepsPerJump = 2;

    private int _currentPosition;

    private bool[] _isTileGone;

    public Platformer(int numberOfTiles, int position)
    {
        _currentPosition = position;
        _isTileGone = new bool[numberOfTiles];
    }

    private void StepInDirectionAndSkipMissingTiles(Func<int> stepInDirection)
    {
        _isTileGone[_currentPosition] = true;

        int steps = 0;
        while (steps < _stepsPerJump)
        {
            do
            {
                stepInDirection();
            }
            while (_isTileGone[_currentPosition]);
            steps++;
        }
    }

    public void JumpLeft()
    {
        Func<int> stepLeft = () => _currentPosition--;
        StepInDirectionAndSkipMissingTiles(stepLeft);
    }

    public void JumpRight()
    {
        Func<int> stepRight = () => _currentPosition++;
        StepInDirectionAndSkipMissingTiles(stepRight);
    }

    public int Position()
    {
        return _currentPosition;
    }

    public static void Main(string[] args)
    {
        Platformer platformer = new Platformer(6, 3);
        Console.WriteLine("Current position:" + platformer.Position()); // should print 3

        platformer.JumpLeft();
        Console.WriteLine("Current position:" + platformer.Position()); // should print 1

        platformer.JumpRight();
        Console.WriteLine("Current position:" + platformer.Position()); // should print 4
    }
}