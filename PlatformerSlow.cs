using System.Collections.Generic;
using System.Linq;

public class PlatformerSlow : Platformer
{
    private const int _stepsPerJump = 2;

    private int _currentPosition;

    private List<int> _remainingTiles;

    public PlatformerSlow(int numberOfTiles, int position)
    {
        _currentPosition = position;
        _remainingTiles = Enumerable.Range(0, numberOfTiles).ToList();
    }

    public void JumpLeft()
    {
        var index = _remainingTiles.IndexOf(_currentPosition);
        _remainingTiles.RemoveAt(index);
        _currentPosition = _remainingTiles[index - 2];
    }

    public void JumpRight()
    {
        var index = _remainingTiles.IndexOf(_currentPosition);
        _remainingTiles.RemoveAt(index);
        _currentPosition = _remainingTiles[index + 1];
    }

    public int Position()
    {
        return _currentPosition;
    }
}