using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[HelpURL("https://www.youtube.com/watch?v=ZVh4nH8Mayg")]
public class WriteScript : MonoBehaviour 
{
    [Header("Write Speed")]
    [Tooltip("Write speed")]
    [Range(0, 2)]
    public float speedText = 0.05f;

    [Header("Text Settings")]
    [Tooltip("Warning Text 1")]
	public Text text1;
    
    [Tooltip("Warning Text 2")]
    public Text text2;

    [Tooltip("Warning Text 3")]
    public Text text3;

    [Header("Active Button")]
    [Tooltip("For Active the button agree when writting is stopped")]
    public GameObject agreeButton;

    [HideInInspector]
	string story;

    [HideInInspector]
    string story2;

    [HideInInspector]
    string story3;

	void Awake () 
	{
		story = text1.text;
		text1.text = "";		
        story2 = text2.text;
		text2.text = "";
        story3 = text3.text;
		text3.text = "";
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			text1.text += c;
			yield return new WaitForSeconds (speedText);

		}
        text1.text = "";
        foreach (char c in story2) {
            text2.text += c;
            yield return new WaitForSeconds(speedText);
        }
        text2.text = "";
        foreach (char c in story3) {
            text3.text += c;
            yield return new WaitForSeconds(speedText);
        }
        agreeButton.SetActive(true);
	}

}