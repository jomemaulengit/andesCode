using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseM;
    private bool isPaused=false;
    // Start is called before the first frame update
    void Start()
    {
        this.pauseM.SetActive(false);
        this.enabled=false;        
    }
    // pause game
    public void  pauseGame(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("pause");
            isPaused=true;
            this.pauseM.SetActive(true);
            Time.timeScale=0f;
        }
    }
    public void resumeGame(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("resume");
            isPaused=false;
            this.pauseM.SetActive(false);
            Time.timeScale=1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused==false){
            this.pauseGame();
        }
        else
        {
            this.resumeGame();
        }
    }
}
