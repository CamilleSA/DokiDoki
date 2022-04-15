using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://medium.com/nerd-for-tech/easy-parallax-scrolling-in-unity-515c5fff7d89")]
public class MoveBackground : MonoBehaviour
{
    
    [Header("Speed Background Movement")]
    [Tooltip("Speed Background Movement")]
    [Range(0,10)]
    public float speedMovement = 5f;

    [Header("Expand Background")]
    [Tooltip("Number of Expand Background")]
    [SerializeField]
    private float clampPosition;

    [Header("Start Position of Background")]
    [Tooltip("Coordinates of The Beginning of The Background Scroll")]
    [SerializeField]
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float newpos = Mathf.Repeat(Time.time * speedMovement, clampPosition);
        transform.position = startPosition + Vector3.left * newpos;
        
    }
}
