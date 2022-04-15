using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://docs.unity3d.com/Manual/class-ScriptableObject.html")]
[CreateAssetMenu(fileName = "NewStoryScene", menuName ="Data/New Story Scene")]
[System.Serializable]
public class StoryScene : GameScene
{
    [Tooltip("Sentence list")]
    public List<Sentence> sentences;

    [Tooltip("Background of this scene")]
    public Sprite background;

    [Tooltip("Next scene when all sentences of this scene are finished")]
    public GameScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        [Tooltip("Text Sentence")]
        public string text;

        [Tooltip("Speaker Name")]
        public Speaker speaker;

        [Tooltip("List of actions to be performed during this sentence")]
        public List<Action> actions;

        [Tooltip("Music of this sentence")]
        public AudioClip music;

        [Tooltip("Sound of this sentence")]
        public AudioClip sound;

        [System.Serializable]
        public struct Action
        {
            [Tooltip("Name of person conducting the action")]
            public Speaker speaker;

            [Tooltip("Number of the sprite that performs the speaker action")]
            public int spriteIndex;

            [Tooltip("Action Type = None / Appear / Move / Disapear")]
            public Type actionType;

            [Tooltip("Coordinates of the sprite in the scene")]
            public Vector2 coords;

            [Tooltip("Speed of action of the sprite")]
            public float moveSpeed;

            [System.Serializable]
            public enum Type
            {
                NONE, APPEAR, MOVE, DISAPPEAR
            }
        }
    }
}

public class GameScene : ScriptableObject { }
