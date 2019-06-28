using System.Collections.Generic;
using System.Linq;

public class PlatformerFast : Platformer
{
    private const int _stepsPerJump = 2;

    private int _currentIndex;

    private List<int> _remainingTiles;

    public PlatformerFast(int numberOfTiles, int position)
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
}