using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour
{
    Preview screen;
    [SerializeField] GameObject title;
    [SerializeField] GameObject lvlSelect;
    [SerializeField] GameObject ld;
    [SerializeField] GameObject story;
    [SerializeField] GameObject controls;
    private void Start()
    {
        screen = GetComponent<Preview>();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelLoad()
    {
        if (screen.curr > -1) { }
      SceneManager.LoadScene(screen.curr);
    }
    public void SelectToTitle(bool inTitle)
    {
        title.SetActive(!inTitle);
        lvlSelect.SetActive(inTitle);
    }
    public void SeeStory(bool b)
    {
        controls.SetActive(false);
        title.SetActive(b);
        story.SetActive(b);
        lvlSelect.SetActive(!b);
    }
    public void SeeControls(bool b)
    {
        controls.SetActive(b);
        title.SetActive(b);
        story.SetActive(false) ;
        lvlSelect.SetActive(!b);
    }

}
