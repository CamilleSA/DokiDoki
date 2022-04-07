using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

#if UNITY_EDITOR
public class TestTools : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    Sprite background;
    Sprite spriteDialog;
    public GameObject canvas;
    float objectScale;
    float spawnRadius = 5f;
    Canvas myCanvas;
    RectTransform rectTransform;

    [MenuItem("Tools/Doki Doki Scene")]
    public static void ShowWindow() {
        GetWindow(typeof(TestTools));
    }

    private void OnGUI() {
        GUILayout.Label("Create Visual Novel Scene", EditorStyles.boldLabel);

        objectBaseName = EditorGUILayout.TextField("Name of object", objectBaseName);
        //objectID = EditorGUILayout.IntField("Object ID", objectID);
        //objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f, 3f);
        //spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        background = EditorGUILayout.ObjectField("Sprite of background", background, typeof(Sprite), false) as Sprite;
       // canvas = EditorGUILayout.ObjectField("Canvas to Spawn", canvas, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Spawn GUI")) {
            SpawnGUI();
        }
    }
    // Start is called before the first frame update
    void SpawnGUI()
    {
        GameObject myUI;
        myUI = new GameObject();
        myUI.name = objectBaseName;
        myUI.AddComponent<Canvas>();

        myCanvas = myUI.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myUI.AddComponent<CanvasScaler>();
        myUI.AddComponent<GraphicRaycaster>();

        var pathImage = background.name;

        GameObject imgObjectBackground = new GameObject("ImageBackground");
        GameObject imgObjectDialog = new GameObject("ImageDialog");

        RectTransform trans = imgObjectBackground.AddComponent<RectTransform>();
        trans.transform.SetParent(myCanvas.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta= new Vector2(myCanvas.GetComponent<RectTransform>().rect.width, myCanvas.GetComponent<RectTransform>().rect.height); // custom size

        Image imageBackground = imgObjectBackground.AddComponent<Image>();
        Texture2D texBackground = Resources.Load<Texture2D>(pathImage);
        imageBackground.sprite = Sprite.Create(texBackground, new Rect(0, 0, texBackground.width, texBackground.height), new Vector2(1.5f, 1.5f));
        imgObjectBackground.transform.SetParent(myCanvas.transform);

        Image imageDialog = imgObjectDialog.AddComponent<Image>();
        Texture2D texDialog = Resources.Load<Texture2D>(pathImage);
        imageDialog.sprite = Sprite.Create(texDialog, new Rect(0, 0, texDialog.width, texDialog.height), new Vector2(1.5f, 1.5f));
        imgObjectDialog.transform.SetParent(myCanvas.transform);
        

        Debug.Log(pathImage);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
#endif
