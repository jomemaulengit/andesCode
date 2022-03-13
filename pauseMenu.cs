using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseM;
    public Image image;
    private bool isPaused=false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("coinst");
        this.pauseM.SetActive(false);
        this.enabled=false;        
    }
    // ============================PUBLIC FUNCTIONS====================================================
    public void  pauseGame(){
            player = GameObject.FindGameObjectWithTag("coinst");
            player.GetComponent<AudioSource>().Pause();
            isPaused=true;
            this.pauseM.SetActive(true);
            Time.timeScale=0f;
    }
    public void resumeGame(){
            isPaused=false;
            this.pauseM.SetActive(false);
            Time.timeScale=1f;
    }

    public void quitGame(){
            this.resumeGame();
            Application.Quit();
    }

    public void restartGame(){
            this.resumeGame();
            StartCoroutine("FadeOut");
    }

    // ==============COROUTINES=======================================================
        IEnumerator FadeOut(){
        for(float fo =0f; fo<255f; fo+=0.1f){
            image.color=new Color(0,0,0,fo);
			if(image.color.a>=0.98f)
			SceneManager.LoadScene(0);
            yield return new WaitForSeconds(0.007f);
        }
    }

    // ==============UPDATE===========================================================
    void Update()
    {
        if(isPaused==false){
            if(Input.GetKeyDown(KeyCode.Tab)){
                this.pauseGame();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Tab)){
                this.resumeGame();
            }
        }
    }
}
