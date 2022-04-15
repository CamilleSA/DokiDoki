using UnityEngine;
using System.Collections.Generic;

[HelpURL("https://docs.unity3d.com/Manual/class-ScriptableObject.html")]
[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    [Tooltip("Name of speaker")]
    public string speakerName;

    [Tooltip("Color of the speaker name")]
    public Color textColor;

    [Tooltip("List of speaker sprites")]
    public List<Sprite> sprites;

    [Tooltip("Object of speaker")]
    public SpriteController prefab;
}
