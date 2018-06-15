using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {
    public FloatValue scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;
    public Renderer rend;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        /*float newPosition = Mathf.Repeat(Time.time * scrollSpeed.floatValue, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;*/
        Vector2 offest = new Vector2(0, Time.time * scrollSpeed.floatValue*-1);

        rend.material.mainTextureOffset = offest;

    }
}
