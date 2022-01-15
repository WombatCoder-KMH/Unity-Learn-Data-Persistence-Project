using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayerNameChanged(string name) {
        ScessionManager.Instance.playerName = name;
    }

    public void ResetHighScore() {
        ScessionManager.Instance.highScore = 0;
        ScessionManager.Instance.highScorePlayerName = "";
    }
}
