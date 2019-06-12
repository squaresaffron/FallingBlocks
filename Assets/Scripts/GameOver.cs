using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameoverScreen;
    public Text Score;
    public Text bestScore;
    bool gameover;

	// Use this for initialization
	void Start () {
        FindObjectOfType<PlayerController>().onPlayerDeath += onGameOver;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameover)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
	}

    void onGameOver()
    {
        
        gameoverScreen.SetActive(true);
        
        Score.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        
        gameover = true;
    }
}
