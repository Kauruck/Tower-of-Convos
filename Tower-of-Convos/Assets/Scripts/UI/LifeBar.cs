using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    [SerializeProperty("Filled")]
    public float _filled = 1;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = this.sprites[0];
    }

    void UpdateBar(){
        if(spriteRenderer == null)
            return;
        int level = Mathf.RoundToInt(_filled/0.1f);
        level = sprites.Length - level -1;
        if(level < sprites.Length && level >= 0)
        {
            spriteRenderer.sprite = sprites[level];
        }
    }

}
