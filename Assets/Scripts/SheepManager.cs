using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public static SheepManager _instance;
    [SerializeField]Sheep leadingSheep;
    public List<Sheep> allSheep;
    public List<PortalSwitch> portals;
    int portCount;
    Vector2 direction;
    float time;
    private bool dontmove;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    internal void KillLead()
    {
        if (leadingSheep == allSheep[0] && allSheep.Count>=2)
        {
            leadingSheep = allSheep[1];
           leadingSheep.ChangeType(0);
            Destroy(allSheep[0].gameObject);
            allSheep.RemoveAt(0);
            
        }
        else
        {
            Debug.Log("game over");
            Destroy(allSheep[0].gameObject);
            allSheep.RemoveAt(0);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (allSheep.Count > 1 && LevelManager._instance.GetPhase())
            {
                time += Time.deltaTime;
                if (time >= 0.4f)
                {
                    if (!dontmove)
                    {
                        MoveF();
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
    {            for (int i = allSheep.Count - 1; i > 0; i--)
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
        dontmove = true;
    }
    public Sheep GetNext(Sheep sheep)
    {
        if (sheep.index >=0)
        {
            return (allSheep[sheep.index + 1]);
        }
        return null;
    }
}
