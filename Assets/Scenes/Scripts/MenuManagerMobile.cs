using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManagerMobile : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = PlayerPrefs.GetFloat("EndTime").ToString();
        HighScoreText.text = PlayerPrefs.GetFloat("BestTime").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameMobile", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuMobile", LoadSceneMode.Single);
    }
}
