using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Coral {
    public Vector2 centerPosition;
    public float radius;
}
[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class BoundaryBackground : MonoBehaviour
{
    public ComputeShader shader;
    public Coral[] corals = new Coral[5];
    public RenderTexture renderTexture;
    private SpriteRenderer spriteRenderer;

    private int kernalIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        renderTexture = new RenderTexture(256,256,24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
    }

    public void RegenerateTexture()
    {
        //Kernal
        kernalIndex = shader.FindKernel("Boundary");
        //Corals
        int positionSize = sizeof(float) * 2;
        int radiusSize = sizeof(float);
        int totalSize = positionSize + radiusSize;
        ComputeBuffer coralBuffer = new ComputeBuffer(corals.Length, totalSize);
        coralBuffer.SetData(corals);
        shader.SetBuffer(kernalIndex, "corals", coralBuffer);
        //Texture
        shader.SetTexture(kernalIndex, "Result", renderTexture);
        //Dispatch
        shader.Dispatch(kernalIndex, renderTexture.width/8, renderTexture.height/8, 1);
    }

// Update is called once per frame
    /*void Update()
    {
        if(renderTexture != null)
        {
            Texture2D texture = toTexture2D(renderTexture);
            if(texture != null)
            {
                this.spriteRenderer.sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
    }*/

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
