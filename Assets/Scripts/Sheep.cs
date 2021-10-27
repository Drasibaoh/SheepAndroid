using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public enum Type
    {
        Lead,
        Follow,
        Contact,
        Free
    }
    Transform initTransform;
    Sheep initSheep;
    [SerializeField]Type me;
    [SerializeField]bool isActive;
    [SerializeField] float speed;
    [SerializeField] Vector2 dir;
    public float cooldown;
    public int index;
    Vector3 oldPos;
    private void Awake()
    {
       
    }
    void Start()
    {
        if (me == Type.Lead)
        {
            SheepManager._instance.AddSheepAsLead(this);
        }
        LevelManager._instance.startOver.AddListener(OnRestart);
        if (dir==Vector2.zero)
        dir = Vector2.right;

         if (me == Type.Follow)
        {
            SheepManager._instance.AddSheep(this);
        }
        else if (me == Type.Contact)
        {
            SheepManager._instance.AddSheep(this);
        }
        initTransform = transform;
        initSheep = this;
       
    }
    public void OnRestart()
    {
        me = initSheep.me;
        dir = initSheep.dir;
        gameObject.transform.position = initTransform.position;
        gameObject.transform.rotation = initTransform.rotation;
        gameObject.transform.localScale = initTransform.localScale;
    }
    public Vector2 GetDir()
    {
        return dir;
    }
    public void SetDir(Vector2 yo)
    {
        Debug.Log(yo);
        dir=yo;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isActive && me==Type.Lead)
        {
           // Move();

        }
        else if (isActive && (me==Type.Contact || me == Type.Follow))
        {
            //MoveFollower();
        }
    }

    public void MoveFollower()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= .4f)
        {
            Vector3 follow =SheepManager._instance.GetPrevious(index).transform.position;
       //     Debug.Log(follow);
            transform.position = follow - new Vector3(dir.x,dir.y, 0);
            oldPos = transform.position;
            //transform.position += new Vector3( dir.x, dir.y, 0)*Time.deltaTime*speed; déplacement smooth
            cooldown = 0;
            //       Debug.Log(oldPos);
        }
    }

    public void Move()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 0.4f)
        {
            oldPos = transform.position;
            transform.position += new Vector3(dir.x, dir.y, 0);
            //transform.position += new Vector3( dir.x, dir.y, 0)*Time.deltaTime*speed; déplacement smooth
            cooldown = 0;
          //  Debug.Log(oldPos);
        }

    }

    public void ChangeDir(bool cw, GameObject fence = null)
    {
        /* if (me == type.Lead)
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
         }*/
        Debug.Log(dir+"oldDir");
        if (fence.transform.rotation.z > 0.1f)
        {
            if (dir == new Vector2(0, 1) && cw)//
            {
                dir = new Vector2(1, 0);
            }
            if (dir == new Vector2(0, -1) && cw)//
            {
                dir = new Vector2(-1, 0);
            }
            else if (dir == new Vector2(0, 1) && !cw)//
            {
                dir = new Vector2(-1, 0);
            }
            else if (dir == new Vector2(0, -1) && !cw)//
            {
                dir = new Vector2(1, 0);
            }
            SheepManager._instance.ChangeDirection(dir);
        }
        else
        {
            if (dir == new Vector2(1, 0) && cw)//
            {
                dir = new Vector2(0, -1);
            }
            else if (dir == new Vector2(-1, 0) && cw)
            {
                dir = new Vector2(0, 1);
            }
            else if (dir == new Vector2(1, 0) && !cw)//
            {
                dir = new Vector2(0, 1);
            }
            else if (dir == new Vector2(-1, 0) && !cw)//
            {
                dir = new Vector2(0, -1);
            }

            SheepManager._instance.ChangeDirection(dir);
        }
        Debug.Log(dir + "NewDir");
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
        if (collision.CompareTag("FenceCW")&& me==Type.Lead)
        {
            Debug.Log(oldPos);
            Debug.Log(transform.position + "ed");
         // transform.position = oldPos;
          //transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
            ChangeDir(true,collision.gameObject);
            //stop les moutons suivants
        }
        else if (collision.CompareTag("FenecCCW") && me==Type.Lead)
        {
            //transform.position = oldPos;
            //transform.position = new Vector3(Mathf.Round( transform.position.x), Mathf.Round(transform.position.y), 0);
            ChangeDir(false, collision.gameObject);

        }
        else if (collision.CompareTag("Sheep") && me==Type.Lead)
        {
            Sheep other = collision.GetComponent<Sheep>();
            if (other.me==Type.Free && SheepManager._instance.allSheep.Count > 3)
            {
                other.me = Type.Contact;
                other.isActive = true;
                SheepManager._instance.AddSheep(other);
            }
            else if (other.me==Type.Free && SheepManager._instance.allSheep.Count >= 1)
            {
                other.me = Type.Follow;
                other.isActive = true;
                other.GetComponent<Collider2D>().isTrigger = true;
                SheepManager._instance.AddSheep(other);

            }
            else if (other.me == Sheep.Type.Contact || other.me == Sheep.Type.Lead)
            {
                SheepManager._instance.ShortCircuit(other.index);
                Debug.Log("you ded you buffon");
            }
        }
    }
    public void ChangeType(int typeIndex)
    {
        switch (typeIndex)
        {
            case 0:
                me = Sheep.Type.Lead;
                break;
            case 1:
                me = Sheep.Type.Follow;
                break;
            case 2:
                me = Sheep.Type.Contact;
                break;
        }
    }

    public Type GetSType()
    {
        return me;
    }
}
