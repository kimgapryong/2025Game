using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance {  get  { Init(); return _instance; } }

    private ResourcesManager _resources = new ResourcesManager();
    public static ResourcesManager Resources { get { return Instance._resources; } }

    private UiManager _ui = new UiManager();
    public static UiManager Ui { get { return Instance._ui; } } 

    private ItemManager _item = new ItemManager();
    public static ItemManager Item { get { return Instance._item; } }

    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }

    private StageManager _stage = new StageManager();
    public static StageManager Stage { get { return Instance._stage; } }
    public static PlayerController Player { get; set; }

    private void Awake()
    {
        Init();
    }

    public static void Init()
    {
        if (_instance != null)
            return;

        GameObject go = GameObject.Find("@Manager");
        if(go == null)
        {
            go = new GameObject("@Manager");
            go.AddComponent<Manager>();
        }
        _instance = go.GetComponent<Manager>();
        DontDestroyOnLoad(go);
    }

    public void Clear()
    {

    }
}
