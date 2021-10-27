using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Preview : MonoBehaviour
{
    [SerializeField] Image preview;
    [SerializeField] Image cursor;
    [SerializeField] List<Sprite> levels;
    public int curr;
    [SerializeField] List<Sprite> anim;
    int index;
    float time;
    RectTransform rec;
    // Start is called before the first frame update
    void Start()
    {
        rec = cursor.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > .85f)
        {
       index++;
        if (index > 1)
        {
            index = 0;
            
        }
        cursor.sprite = anim[index];
            time = 0;
        }
 
    }
    public void ShowPre(int lvlInd)
    {

        preview.sprite = levels[lvlInd-1];
        curr = lvlInd;
        switch (curr)
        {
            case 1:
                rec.position = new Vector3(-732.4437f+970, rec.position.y, rec.position.z);
                break;
            case 2:
                rec.position = new Vector3(-732.4437f+370+970, rec.position.y, rec.position.z);
                break;
            case 3:
                rec.position = new Vector3(-732.4437f + 370+370+970, rec.position.y, rec.position.z);
                break;
        }
    }
}
