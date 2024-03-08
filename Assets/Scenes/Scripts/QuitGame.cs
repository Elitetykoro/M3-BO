using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class QuitGame : MonoBehaviour
{
    Vector3 Balloon = new Vector3(0,18,35);
    [SerializeField] Transform transform;
    private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Balloon;
        Balloon.y += speed;
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
        speed = 4;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("lazers",LoadSceneMode.Single);
    }
}
