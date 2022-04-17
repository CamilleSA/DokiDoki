using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSettings : MonoBehaviour
{
    public GameObject PanelSettings;

    public void ActiveName() {
        PanelSettings.SetActive(true);
    }
    
    public void ClosePanel() {
        PanelSettings.SetActive(false);
    }

    public void ReturnMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
