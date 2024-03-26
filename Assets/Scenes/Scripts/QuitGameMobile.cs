using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class QuitGameMobile : MonoBehaviour
{
    Vector3 Balloon = new Vector3(0,18,23);
    [SerializeField] Transform balloonTransform;
    private float speed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        balloonTransform.position = Balloon;
        Balloon.z += speed*Time.deltaTime;
    }
    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void startGame()
    {
        StartCoroutine("_QuitGame");
    }
    public IEnumerator _QuitGame()
    {
        speed = 48f;
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameMobile",LoadSceneMode.Single);
    }
}
