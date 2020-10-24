using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToOtherScene : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go(string scene)
    {
        TimeManager.isPaused = false;
        SceneManager.LoadScene(scene);
    }
}
