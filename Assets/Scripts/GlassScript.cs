using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
    private float hitPoints = 3;
    private Breakable breakscript;
    private SpriteRenderer sp;
    //[SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    // Start is called before the first frame update
    void Start()
    {
        breakscript = GetComponent<Breakable>();
        sp = GetComponent<SpriteRenderer>();
    }
    public void GlassSmash()
    {
        if (hitPoints > 0)
        {
            hitPoints--;
            if (hitPoints == 2)
            {
                sp.sprite = stage2;
            }
            if (hitPoints == 1)
            {
                sp.sprite = stage3;
            }
        }
        else
        {
            breakscript.Wreck();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
