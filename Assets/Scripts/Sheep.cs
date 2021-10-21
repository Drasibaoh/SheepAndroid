using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public enum type
    {
        Lead,
        Follow,
        Contact,
        Free
    }
    [SerializeField]type me;
    [SerializeField]bool isActive;
    [SerializeField] float speed;
    [SerializeField] Vector2 dir;
    float cooldown;
    public int index;
    Vector3 oldPos;
    bool firstTime=true;
    Sheep before;
    private void Awake()
    {
        if (me == type.Lead)
        {
            SheepManager._instance.AddSheepAsLead(this);
        }
    }
    void Start()
    {
        dir = Vector2.right;

         if (me == type.Follow)
        {
            SheepManager._instance.AddSheep(this);
        }
        else if (me == type.Contact)
        {
            SheepManager._instance.AddSheep(this);
        }
        if (isActive && me == type.Lead)
        {
           // Move();

        }
        //  Time.timeScale = 0.5f;
    }
    public void SetDir(Vector2 yo)
    {
        dir=yo;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive && me==type.Lead)
        {
            Move();

        }
        else if (isActive && (me==type.Contact || me == type.Follow))
        {
            //MoveFollower();
        }
    }

    public void MoveFollower()
    {
        if (firstTime)
        {
            before = SheepManager._instance.allSheep[0];
            firstTime = false;
        }
        cooldown += Time.deltaTime;
        if (cooldown >= .4f)
        {
            Vector3 follow =SheepManager._instance.GetPrevious(index).transform.position;
            Debug.Log(follow);
            transform.position = follow - new Vector3(dir.x,dir.y, 0);
            oldPos = transform.position;
            //transform.position += new Vector3( dir.x, dir.y, 0)*Time.deltaTime*speed; déplacement smooth
            cooldown = 0;
            //       Debug.Log(oldPos);
        }
    }

    private void Move()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 0.4f)
        {
            oldPos = transform.position;
            transform.position += new Vector3(dir.x, dir.y, 0);
            //transform.position += new Vector3( dir.x, dir.y, 0)*Time.deltaTime*speed; déplacement smooth
            cooldown = 0;
     //       Debug.Log(oldPos);
        }

    }

    public void ChangeDir(bool cw)
    {
        if (me == type.Lead)
        {

            if (dir == new Vector2(0, 1))//
            {
                if (cw)
                    dir = new Vector2(1, 0);
                else
                    dir = new Vector2(-1, 0);
            }
            else if (dir == new Vector2(0, -1))//
            {
                if (cw)
                    dir = new Vector2(-1, 0);
                else
                    dir = new Vector2(1, 0);
            }
            else if (dir == new Vector2(1, 0))//
            {
                if (cw)
                    dir = new Vector2(0, -1);
                else
                    dir = new Vector2(0, 1);
            }
            else if (dir == new Vector2(-1, 0))//
            {
                if (cw)
                    dir = new Vector2(0, 1);
                else
                    dir = new Vector2(0, -1);
            }
            SheepManager._instance.ChangeDirection(dir);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fence"))
        {
            Debug.Log("isSheep");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FenceCW"))
        {
            Debug.Log(oldPos);
            Debug.Log(transform.position + "ed");
          transform.position = oldPos;
          //transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
            ChangeDir(true);
            //stop les moutons suivants
        }
        else if (collision.CompareTag("FenecCCW"))
        {            Debug.Log(oldPos);
            Debug.Log(transform.position + "ed");
            transform.position = oldPos;
            //transform.position = new Vector3(Mathf.Round( transform.position.x), Mathf.Round(transform.position.y), 0);
            Debug.Log(dir);
            ChangeDir(false);
            Debug.Log(dir);
        }
        else if (collision.CompareTag("Sheep") && me==type.Lead)
        {
            Sheep other = collision.GetComponent<Sheep>();
            if (other.me==type.Free && SheepManager._instance.allSheep.Count > 3)
            {
                other.me = type.Contact;
                other.isActive = true;
                SheepManager._instance.AddSheep(other);
            }
            else if (other.me==type.Free && SheepManager._instance.allSheep.Count >= 1)
            {
                other.me = type.Follow;
                other.isActive = true;
                other.GetComponent<Collider2D>().isTrigger = true;
                SheepManager._instance.AddSheep(other);

            }
            else if (other.me == Sheep.type.Contact || other.me == Sheep.type.Lead)
            {
                Debug.Log("you ded you buffon");
            }
        }
    }
    public void ChangeType(int typeIndex)
    {
        switch (typeIndex)
        {
            case 0:
                me = Sheep.type.Lead;
                break;
            case 1:
                me = Sheep.type.Follow;
                break;
            case 2:
                me = Sheep.type.Contact;
                break;
        }
    }

    public type GetSType(Sheep sheep)
    {
        return me;
    }
}
