using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class LifeBar : MonoBehaviour
{


    public Sprite[] sprites;

    public float Filled {
        get { return _filled; }
        set { 
                _filled = Mathf.Clamp(value, 0, 1); 
                UpdateBar();
            }
    }

    private float _filled = 1;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = this.sprites[0];
    }

    void UpdateBar(){
        int level = Mathf.RoundToInt(_filled/0.1f);
        if(level < sprites.Length && level >= 0)
        {
            spriteRenderer.sprite = sprites[level];
        }
    }
}
