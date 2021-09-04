using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    public float ScrollSpeed=0.5f;
    private float y_scroll;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    private void Scroll()
    {
        y_scroll = ScrollSpeed * Time.time;
        Vector2 offset = new Vector2(0f, y_scroll);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
