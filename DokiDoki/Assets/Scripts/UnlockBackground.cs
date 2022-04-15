using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html")]
public class UnlockBackground : MonoBehaviour
{
    [Header("Background Settings")]
    [Tooltip("Image locked")]
    public GameObject CanvasLock;

    [Tooltip("Image unlocked")]
    public GameObject CanvasUnlock;
    
    //public Image whiteScreen;

    void Start () {
      //  whiteScreen.canvasRenderer.SetAlpha(0.0f);
    }

    public void UnlockCanvas () {
        CanvasLock.SetActive(false);
        CanvasUnlock.SetActive(true);
        StartCoroutine(GoToMenu());
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }

    
}
