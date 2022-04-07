using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed = 5f;
    public float clamppos;
    private Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float newpos = Mathf.Repeat(Time.time * speed, clamppos);
        transform.position = startpos + Vector3.left * newpos;
        
    }
}
