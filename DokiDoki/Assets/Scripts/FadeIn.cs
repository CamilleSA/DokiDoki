using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private float Transparence;
    public bool FadeOut;
    public float Step = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transparence = Mathf.Clamp(Transparence, 0, 1);

        if (FadeOut) {
            Transparence += Step;
        } else {
            Transparence -= Step;
        }

        GetComponent<CanvasGroup>().alpha = Transparence;
        
    }
}
