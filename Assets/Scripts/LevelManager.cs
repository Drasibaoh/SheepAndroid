using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager _instance;
    [SerializeField] int sheepToWin; //percentage of sheep to win
    [SerializeField] int sheepToPerfect; //max number of sheep to enter
    [SerializeField]int sheepIn;
    [SerializeField] int antiSlashFence;
    [SerializeField] int slashFence;
    public UnityEvent startOver;
    [SerializeField] bool playerPhase;
    [SerializeField] int levelIndex;
    Vector2 gridSize=new Vector2(12,10);
    public Transform pointZero;
    [SerializeField] Transform grid;
    [SerializeField] GameObject pFence;
    [SerializeField] GameObject paFence;
    [SerializeField] List<GameObject> inLvlFences;
    [SerializeField] List<GameObject> inLvlAFences;
    [SerializeField] GameObject win;
    [SerializeField] GameObject perfect;
    [SerializeField] RectTransform fill;
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
        startOver.AddListener(EndPhase);
    }
    private void Update()
    {
        fill.localScale =new Vector3(1, 0.125f * sheepIn,1);
    }
    public Vector2 GetCase(Vector3 worldPos, bool anti=false)
    {
        Debug.Log("Case : "+grid.InverseTransformPoint(worldPos));
        Vector3 locPos= grid.InverseTransformPoint(worldPos);
        
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                if (locPos.x>i && locPos.x<i+1 && locPos.y>j && locPos.y<j+1 )
                    SpawnFence( new Vector2(Mathf.Floor(locPos.x)+0.5f, Mathf.Floor(locPos.y)+0.5f), anti);
                  //  return new Vector2(Mathf.Floor(locPos.x)+0.5f, Mathf.Floor(locPos.y)+0.5f);
            }
        }
                return Vector2.zero;
    }
    public Vector2 GetFence() 
    {
        return new Vector2(slashFence, antiSlashFence);
    }
    private void SpawnFence(Vector2 pos, bool anti)
    {
        if (!anti)
        {
            if (slashFence > 0)
            {
               /* if ()
                {
                    inLvlAFences[]
                }*/
                GameObject newFence= Instantiate(pFence, new Vector3(pos.x, pos.y, 0), transform.rotation);
                slashFence--;
                inLvlFences.Add(newFence);
            }
        }
        else
        {
            if (antiSlashFence > 0)
            {
                antiSlashFence--;

                GameObject newfence = Instantiate(paFence, new Vector3(pos.x, pos.y, 0), transform.rotation);
                inLvlAFences.Add(newfence);
            }
            
        }

    }
    public void Restart()
    {
        for (int i = inLvlFences.Count; i > 0; i--)
        {
            Destroy(inLvlFences[i-1]);
            inLvlFences.RemoveAt(i-1);
            slashFence++;
        }
        for (int i = inLvlAFences.Count; i >0; i--)
        {
            Destroy(inLvlAFences[i-1]);
            inLvlAFences.RemoveAt(i-1);
            antiSlashFence++;
        }
        startOver.Invoke();
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
    public void StartPhase()
    {
        playerPhase = true;
        SheepManager._instance.allSheep[0].Activate(true);
       // SheepManager._instance.CanMove(true);
    }
    public void EndPhase()
    {
        playerPhase = false;
    //    SheepManager._instance.CanMove(false);
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
            // perfect.SetActive(true);
            win.SetActive(true);
            GameManager._instance.levelsStatus[levelIndex] = GameManager.levelStatus.Perfected;
        }
        else if (sheepIn*100/sheepToPerfect>= sheepToWin || GameManager._instance.levelsStatus[levelIndex] == GameManager.levelStatus.Perfected)
        {
            //win.SetActive(true);
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
