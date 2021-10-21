using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public static SheepManager _instance;
    Sheep leadingSheep;
    public List<Sheep> allSheep;
    bool isChanging;
    Vector2 direction;
    float cooldown;
    int a=1;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanging)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= 0.4f)
            {
                if (a > allSheep.Count)
                {
                    isChanging = false;
                    a = 1;
                    return;
                }
                allSheep[a].SetDir(direction);
                cooldown = 0;
                a++;

            }
        }
    }
    private void FixedUpdate()
    {
        if (allSheep.Count > 2)
        {
            for (int i = allSheep.Count - 1; i > 0; i--)
            {
                allSheep[i].transform.position = allSheep[i - 1].transform.position;
                //allSheep[i].MoveFollower();
            }
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
        isChanging = true;
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
