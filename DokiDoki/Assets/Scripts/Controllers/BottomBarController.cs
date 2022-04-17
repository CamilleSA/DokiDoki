using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[HelpURL("https://www.youtube.com/watch?v=_nRzoTzeyxU")]
public class BottomBarController : MonoBehaviour
{
    [Header("Text Settings")]
    [Space]
    [Tooltip("Dialog Text")]
    public TextMeshProUGUI barText;

    [Space]
    [Tooltip("Pseudo Text")]
    public TextMeshProUGUI personNameText;

    [Space]
    [Header("Text Engine")]
    [SerializeField]
    private int sentenceIndex = -1;

    [Space]
    [Tooltip("Current Scene, by default = 1")]
    [SerializeField]
    private StoryScene currentScene;

    [Space]
    [Tooltip("Status of dialog")]
    [SerializeField]
    private State state = State.COMPLETED;

    [Space]
    [Header("Animation Show / Hide Dialog Box")]
    [Tooltip("Animation Show / Hide Dialog Box if scene is finish")]
    [SerializeField]
    private Animator animator;

    [Space]
    [Tooltip("Sprites Characters")]
    [SerializeField]
    private bool isHidden = false;

    [Space]
    [Header("Sprites Controller")]
    [Space]
    public Dictionary<Speaker, SpriteController> sprites;
    
    [Space]
    public GameObject spritesPrefab;
    
    [Space]
    [SerializeField]
    private Coroutine typingCoroutine;
    
    [Space]
    [SerializeField]
    private float speedFactor = 1f;

    private enum State
    {
        PLAYING, SPEEDED_UP, COMPLETED
    }

    private void Start()
    {
        sprites = new Dictionary<Speaker, SpriteController>();
        animator = GetComponent<Animator>();
    }

    public int GetSentenceIndex()
    {
        return sentenceIndex;
    }

    public void Hide()
    {
        if (!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
    }

    public void ClearText()
    {
        barText.text = "";
        personNameText.text = "";
    }

    public void PlayScene(StoryScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        currentScene = scene;
        this.sentenceIndex = sentenceIndex;
        PlayNextSentence(isAnimated);

        if (currentScene.ToString() == "9 (StoryScene)") {
            SceneManager.LoadScene("End");

        }
    }

    public void PlayNextSentence(bool isAnimated = true)
    {
        sentenceIndex++;
        PlaySentence(isAnimated);
    }

    public void GoBack()
    {
        sentenceIndex--;
        StopTyping();
        HideSprites();
        PlaySentence(false);
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED || state == State.SPEEDED_UP;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public bool IsFirstSentence()
    {
        return sentenceIndex == 0;
    }

    public void SpeedUp()
    {
        state = State.SPEEDED_UP;
        speedFactor = 0.25f;
    }

    public void StopTyping()
    {
        state = State.COMPLETED;
        StopCoroutine(typingCoroutine);
    }

    public void HideSprites()
    {
        while(spritesPrefab.transform.childCount > 0)
        {
            DestroyImmediate(spritesPrefab.transform.GetChild(0).gameObject);
        }
        sprites.Clear();
    }

    private void PlaySentence(bool isAnimated = true)
    {
        
        if (currentScene.sentences[sentenceIndex].speaker.ToString() == "Author (Speaker)") {
            currentScene.sentences[sentenceIndex].speaker.speakerName = PlayerPrefs.GetString("name");
        }
        speedFactor = 1f;
        typingCoroutine = StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;

       // personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        ActSpeakers(isAnimated);
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(speedFactor * 0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }

    private void ActSpeakers(bool isAnimated = true)
    {
        List<StoryScene.Sentence.Action> actions = currentScene.sentences[sentenceIndex].actions;
        for(int i = 0; i < actions.Count; i++)
        {
            ActSpeaker(actions[i], isAnimated);
        }
    }

    private void ActSpeaker(StoryScene.Sentence.Action action, bool isAnimated = true)
    {
        SpriteController controller;
        if (!sprites.ContainsKey(action.speaker))
        {
            controller = Instantiate(action.speaker.prefab.gameObject, spritesPrefab.transform)
                .GetComponent<SpriteController>();
            sprites.Add(action.speaker, controller);
        }
        else
        {
            controller = sprites[action.speaker];
        }
        switch (action.actionType)
        {
            case StoryScene.Sentence.Action.Type.APPEAR:
                controller.Setup(action.speaker.sprites[action.spriteIndex]);
                controller.Show(action.coords, isAnimated);
                return;
            case StoryScene.Sentence.Action.Type.MOVE:
                controller.Move(action.coords, action.moveSpeed, isAnimated);
                break;
            case StoryScene.Sentence.Action.Type.DISAPPEAR:
                controller.Hide(isAnimated);
                break;
        }
        controller.SwitchSprite(action.speaker.sprites[action.spriteIndex], isAnimated);
    }
}
