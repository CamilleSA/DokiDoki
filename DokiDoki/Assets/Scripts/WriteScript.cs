using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WriteScript : MonoBehaviour 
{

	public Text txt;
    public Text txt2;
    public Text txt3;
    public GameObject agree;
	string story;
    string story2;
    string story3;

	void Awake () 
	{
		story = txt.text;
		txt.text = "";		
        story2 = txt2.text;
		txt2.text = "";
        story3 = txt3.text;
		txt3.text = "";
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (0.05f);

		}
        txt.text = "";
        foreach (char c in story2) {
            txt2.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        txt2.text = "";
        foreach (char c in story3) {
            txt3.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        agree.SetActive(true);
	}

}