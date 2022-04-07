using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public GameObject PanelName;

    public void ActiveName() {
        PanelName.SetActive(true);
    }
}
