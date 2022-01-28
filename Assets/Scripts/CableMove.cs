using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableMove : MonoBehaviour
{
    Vector2 tileCheckerSize = new Vector2(0.9f,0.9f);    // used to quickly edit the size of all overlap boxes
    public void MoveCable(char direction)
    {
        switch (direction)
        {
            case 'R':
                if(!Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f))
                {
                    transform.Translate(Vector3.right);
                }
                break;
            case 'L':
                if (!Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f))
                {
                    transform.Translate(Vector3.right);
                }
                break;
            case 'U':
                if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f))
                {
                    transform.Translate(Vector3.right);
                }
                break;
            case 'D':
                if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f))
                {
                    transform.Translate(Vector3.right);
                }
                break;
        }
    }
}
