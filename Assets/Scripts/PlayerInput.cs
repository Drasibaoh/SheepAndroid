using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    bool slash; 
    Controls input;
    Vector2 pos;
    Vector2 oldPos;
    bool click;
    Vector2 grid;
    Vector2 fenceNm;
    [SerializeField] Text antiFence;
    [SerializeField] Text fence;
    private void Awake()
    {
        input = new Controls();
        input.Fence.Drop.started += Drop;
        input.Fence.Drop.canceled += Stop;
        input.Fence.Antislash.started += Slash;
        input.Fence.Drop.canceled += Stop;
        input.Fence.Newaction.performed += Mouse;
    }

    private void Stop(CallbackContext obj)
    {
        click=false;
        slash = false;
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void Mouse(CallbackContext ctx)
    {
        pos = ctx.ReadValue<Vector2>();
    }

    void Start()
    {
        grid=LevelManager._instance.GetGridSize();
        Debug.Log(grid);
        fenceNm = new Vector2(LevelManager._instance.GetSFence(), LevelManager._instance.GetASFence());
    }

    void Update()
    {
        if (!LevelManager._instance.GetPhase())
        {
            if (click)
            {
                LevelManager._instance.GetCase(Camera.main.ScreenToWorldPoint(pos), false);
                //ClickPos();
                // Debug.Log(Camera.main.ScreenToWorldPoint(pos).x + "x value");
                click = false;
                // Debug.Log("e");
                //  Debug.Log(Camera.main.ScreenToWorldPoint(pos).y +"y value");
            }
            if (slash)
            {
                slash = false;
                LevelManager._instance.GetCase(Camera.main.ScreenToWorldPoint(pos), true);
            }
        }
        fence.text = "X " + LevelManager._instance.GetFence().x;
        antiFence.text = "X " + LevelManager._instance.GetFence().y;
    }

    private void ClickSPos()
    {
        Debug.Log("e");
        Debug.Log(grid.y);
        for (int i = 0; i < grid.x; i++)
        {
            for (int j = 0; j < grid.y; j++)
            {    
                if (pos.x > i * .98f+LevelManager._instance.pointZero.position.x && pos.x < (i + 1) * .98f  + LevelManager._instance.pointZero.position.x && pos.y > j * .98f + LevelManager._instance.pointZero.position.y && pos.y < (j + 1) * .98f + LevelManager._instance.pointZero.position.y)
                {
                    Debug.Log("ee");
                    LevelManager._instance.GetCase(Camera.main.ScreenToWorldPoint(pos), false);
                }
            }
        }
    }

    void ClickPos()
    {
        Debug.Log("e");
        for (int i = 0; i < grid.x; i++)
        {
            for (int j = 0; j < grid.y; j++)
            {
                Debug.Log((i+1)*.98f + LevelManager._instance.pointZero.position.x);
                if (pos.x < (i + 1) * .98f + LevelManager._instance.pointZero.position.x)
                    Debug.Log("ret00");
                if (pos.x > i * .98f + LevelManager._instance.pointZero.position.x && pos.x < (i + 1) * .98f + LevelManager._instance.pointZero.position.x && pos.y > j * .98f + LevelManager._instance.pointZero.position.y && pos.y < (j + 1) * .98f + LevelManager._instance.pointZero.position.y)
                {
                    Debug.Log("ee");
                  //  SpawnSFence(new Vector2(i + LevelManager._instance.pointZero.position.x+.5f, j + LevelManager._instance.pointZero.position.y + .5f));
                }
            }
        }
    }
    /*void SpawnSFence(Vector2 posGrid)
    {
        Debug.Log("eee");
        if (fenceNm.x > 0)
        {
            Debug.Log("eeee");
            GameObject newfence = Instantiate(fences[0], posGrid, new Quaternion(0, 0, 0, 0));
            inLvlFences.Add(newfence) ;
        }
    }
    void SpawnASFence(Vector2 posGrid)
    {
        if (fenceNm.y > 0)
        {
            GameObject newfence = Instantiate(fences[1], posGrid, new Quaternion(0, 0, 0, 0));
            inLvlFences.Add(newfence);
        }
    }
    public void Clear()
    {
        for (int i = inLvlFences.Count; i < 0; i--)
        {
            Destroy(inLvlFences[i]);
            inLvlFences.RemoveAt(i);
        }

    }*/
    void Drop(CallbackContext ctx)
    {
        click = ctx.ReadValueAsButton();
    }
    void Slash(CallbackContext ctx)
    {
        slash = ctx.ReadValueAsButton();
    }
}
