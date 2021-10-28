using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public static SheepManager _instance;
    Sheep leadingSheep;
    public List<Sheep> allSheep;
    public List<PortalSwitch> portals;
    int portCount;
    [SerializeField] List<Sheep> deadSheep;
    [SerializeField] Vector2 direction;
    float time;
    private bool dontmove;
    int upIndex;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        
        LevelManager._instance.startOver.AddListener(Restart);
    }
    internal void KillLead()
    {
        if (leadingSheep == allSheep[0] && allSheep.Count >= 2)
        {
            Debug.Log(allSheep[1].GetDir());
            allSheep[1].canChange = false;
            allSheep[1].cooldown = allSheep[0].cooldown;
            allSheep[1].SetDir(allSheep[0].GetDir());
            Debug.Log(allSheep[1].GetDir());
            leadingSheep = allSheep[1];
            leadingSheep.ChangeType(0);

            leadingSheep.GetComponent<Collider2D>().isTrigger = false;
            allSheep[0].gameObject.SetActive(false);
            deadSheep.Add(allSheep[0]);
            allSheep.RemoveAt(0);
            leadingSheep.Move();
        }
        else
        {
            Debug.Log("game over");
            //   Destroy(allSheep[0].gameObject);
            allSheep[0].gameObject.SetActive(false);
            deadSheep.Add(allSheep[0]);
            allSheep.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isChanging)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= 0.4f)
            {
                if (a > allSheep.Count-1)
                {
                    isChanging = false;
                    a = 1;
                    return;
                }
                allSheep[a].SetDir(direction);
                cooldown = 0;
                a++;

            }
        }*/
    }
    private void FixedUpdate()
    {
        if (LevelManager._instance.GetPhase())
        {
            if (allSheep.Count > 1 )
            {
                time += Time.deltaTime;
                if (time >= 0.4f)
                {
                    if (!dontmove)
                    {
                        MoveF();
                        DirectionUpdate();
                        portCount++;
                        PortalsSwitch();
                    }
                    else
                        dontmove = false;
                    time = 0;
                }

            }
            leadingSheep.Move();
        }
    }
    void DirectionUpdate()
    {
        upIndex++;
        if (upIndex > allSheep.Count - 1)
        {
            upIndex = 1;
        }
        Debug.Log("to");
        allSheep[upIndex].SetDir(leadingSheep.GetDir());
        allSheep[upIndex].PlayAnim();
        Debug.Log("nope");
    }
    public void Restart()
    {
        for (int i = allSheep.Count-1; i >0; i--)
        {
            allSheep[i].OnRestart();
            allSheep[i].Activate(false);
            allSheep.RemoveAt(i);
        }
        for (int i = deadSheep.Count - 1; i > -1; i--)
        {
            deadSheep[i].gameObject.SetActive(true);
            deadSheep[i].OnRestart();
            deadSheep[i].Activate(false);
            allSheep.RemoveAt(i);

        }
        allSheep[0].OnRestart();
    }
    private void PortalsSwitch()
    {
        if (portCount > 1)
        {
        for (int i = 0; i < portals.Count; i++)
            portals[i].switchPos();
            portCount = 0;
        }

    }

    public void MoveF()
    {
        for (int i = allSheep.Count-1; i > 0; i--)
        {
            allSheep[i].transform.position = allSheep[i - 1].transform.position;
        }
    }
    public void AddSheep(Sheep other)
    {
        allSheep.Add(other);
        IndexSheep();
    }
    public void IndexSheep()
    {
        for (int i =0; i<allSheep.Count; i++)
        {
            allSheep[i].index = i;
        }
    }
    public void ShortCircuit(int index)
    {
        for (int i = allSheep.Count -1; i >= index; i--)
        {
            Debug.Log(i + "détruit");
            Destroy(allSheep[i].gameObject);
            allSheep.RemoveAt(i);
        }
    } 
    internal void AddSheepAsLead(Sheep other)
    {
        leadingSheep = other;
        AddSheep(leadingSheep);
    }

    public Sheep GetPrevious(int index)
    {
        if (index == 0)
        {
            Debug.Log("isLead");
            return null;
        }
        else if (index > 0)
        {
            return (allSheep[index - 1]);
        }
        return null;
    }
    public void ChangeDirection(Vector2 dir)
    {
        direction = dir;
      //  dontmove = true;
    }
    public Sheep GetNext(Sheep sheep)
    {
        if (sheep.index >=0)
        {
            return (allSheep[sheep.index + 1]);
        }
        return null;
    }
    public void CanMove(bool doesIt)
    {
        dontmove = !doesIt;
    }
}
