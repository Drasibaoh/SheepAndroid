using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int sheepToWin; //percentage of sheep to win
    [SerializeField] int sheepToPerfect; //max number of sheep to enter
    int sheepIn;
    [SerializeField] int levelIndex;
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
    public void SheepIsIn()
    {
        sheepIn++;
        CheckWin();
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
}
