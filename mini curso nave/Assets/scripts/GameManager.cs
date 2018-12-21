using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
    public GameObject startUI;
    public GameObject endUI;

    public int myLevel=0;
    public Player player;

    public bool getControlOfPlayerAtStart = false;

    #region solo video 6
    public SoundManager soundPrefab;

    protected SoundManager sound;

    public SoundManager Sound
    {
        get
        {
            return sound;
        }
    }
    #endregion

    // Use this for initialization
    void Start () {
        //Used to be able to play directly from play when testing levels
        if (getControlOfPlayerAtStart)
        {
            player.hasControl = false;
        }
        //If we are at a start level
        if (startUI != null)
        {
            startUI.SetActive(true);
        }
        else
        {
            startGame();
        }
        //If we are at an end level
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        player.manager = this;

        #region solo video 6
        if (soundPrefab != null) //esta comprobación solo la hago para que no te pete en las escenas del video5
        {
            sound = Instantiate<SoundManager>(soundPrefab);
        }
      
        #endregion
    }

    /// <summary>
    /// This is called from the UI button
    /// </summary>
    public void startGame()
    {
        if (startUI != null)
        {
            startUI.SetActive(false);
        }
        
        player.hasControl = true;
    }

    /// <summary>
    /// This is called when the player ends a level
    /// </summary>
    public void endLevel()
    {
        if (endUI != null)
        {
            endUI.gameObject.SetActive(true);
        }
        else
        {
            loadLevel(myLevel+1);
        }

    }
    

    public void loadLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
	
	
}
