using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelManager : MonoBehaviour
{
    public static LevelManager _instance;
    [SerializeField] int sheepToWin; //percentage of sheep to win
    [SerializeField] int sheepToPerfect; //max number of sheep to enter
    int sheepIn;
    [SerializeField] int antiSlashFence;
    [SerializeField] int slashFence;
    public UnityEvent startOver;
    [SerializeField] bool playerPhase;
    [SerializeField] int levelIndex;
    Vector2 gridSize=new Vector2(12,10);
    public Transform pointZero;
    [SerializeField] Transform grid;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager._instance.levelsStatus[levelIndex] == GameManager.levelStatus.NotTried)
        {
            GameManager._instance.levelsStatus[levelIndex] = GameManager.levelStatus.Tried;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 GetCase(Vector3 worldPos)
    {
        Debug.Log("Case : "+grid.InverseTransformPoint(worldPos));
       Vector3 locPos= grid.InverseTransformPoint(worldPos);
        
        return new Vector2(Mathf.Floor(locPos.x),Mathf.Floor(locPos.y));
    }
    public Vector3 GetReversCase(Vector3 worldPos)
    {
        Vector3 locPos = grid.TransformPoint(worldPos);

        return new Vector3(Mathf.Floor(locPos.x), Mathf.Floor(locPos.y),0);
    }
    public bool GetPhase()
    {
        return playerPhase;
    }

    public void SheepIsIn()
    {
        sheepIn++;
        CheckWin();
    }
    public Vector2 GetGridSize()
    {
        return gridSize;
    }
    public void CheckWin()
    {
        if (sheepIn == sheepToPerfect)
        {
            //victoire
            GameManager._instance.levelsStatus[levelIndex] = GameManager.levelStatus.Perfected;
        }
        else if (sheepIn*100/sheepToPerfect>= sheepToWin || GameManager._instance.levelsStatus[levelIndex] == GameManager.levelStatus.Perfected)
        {
            //victoire
            GameManager._instance.levelsStatus[levelIndex] = GameManager.levelStatus.Done;
        }
    }
    public int GetSFence()
    {
        return slashFence;
    }
    public int GetASFence()
    {
        return antiSlashFence;
    }
}
