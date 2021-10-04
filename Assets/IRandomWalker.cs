using UnityEngine;

interface IRandomWalker
{
    string GetName();

    Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight);

    Vector2 Movement();
}