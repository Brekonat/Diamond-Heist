using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    Vector2 tileCheckerSize = new Vector2(0.9f,0.9f);    // used to quickly edit the size of all overlap boxes

    public List<Cable> connections;
    public MiniGameManager manager;
    public bool startEndConnection { get; private set; } = false;
    LayerMask mask;

    private void Start()
    {
        if (name.Equals("Start Cable") || name.Equals("End Cable"))
            startEndConnection = true;
        manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<MiniGameManager>();
        mask = LayerMask.GetMask("PuzzleColliders");
    }

    public void MoveCable(char direction)
    {
        if (!startEndConnection)
        {
            Collider2D col;
            switch (direction)
            {
                case 'R':
                    col = Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f, mask);
                    //print(col + " " + Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f));
                    //if (!Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f) || (!Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f) && Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f).CompareTag("Connection")))
                    //{
                    //    transform.Translate(Vector3.right);
                    //}
                    if (!Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), tileCheckerSize, 0f, mask))
                    {
                        transform.Translate(Vector3.right);
                    }
                    break;
                case 'L':
                    col = Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f, mask);
                    //print(col + " " + Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f));
                    //if (!Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f) || (!Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f) && Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f).CompareTag("Connection")))
                    //{
                    //    transform.Translate(Vector3.left);
                    //}
                    if (!Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), tileCheckerSize, 0f, mask))
                    {
                        transform.Translate(Vector3.left);
                    }
                    break;
                case 'U':
                    col = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f, mask);
                    //print(col + " " + Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y +1), tileCheckerSize, 0f));
                    //if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f) || (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f) && Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f).CompareTag("Connection")))
                    //{
                    //    transform.Translate(Vector3.up);
                    //}
                    if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), tileCheckerSize, 0f, mask))
                    {
                        transform.Translate(Vector3.up);
                    }
                    break;
                case 'D':
                    col = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f, mask);
                    //print(col + " " + Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y -1), tileCheckerSize, 0f));
                    //if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f) || (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f) && Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f).CompareTag("Connection")))
                    //{
                    //    transform.Translate(Vector3.down);
                    //}
                    if (!Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), tileCheckerSize, 0f, mask))
                    {
                        transform.Translate(Vector3.down);
                    }
                    break;
            }
        }
    }
}
