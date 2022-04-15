using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivePanel : MonoBehaviour
{
    public InputField nameBox;
    public GameObject PanelName;

    public void ActiveName() {
        PanelName.SetActive(true);
    }

    public void SaveNamePlayer() {
        PanelName.SetActive(false);
        PlayerPrefs.SetString("name", nameBox.text);
        SceneManager.LoadScene("Game");
    }
}
