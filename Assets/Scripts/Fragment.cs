using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{

    public bool fragment1Clear;
    public bool fragment2Clear;
    public bool fragment3Clear;

    public GameObject fragment1;
    public GameObject fragment2;
    public GameObject fragment3;

    public GameObject promptText;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (fragment1Clear)
        {
            fragment1.SetActive(true);
        }
        if (fragment2Clear)
        {
            fragment2.SetActive(true);
        }
        if (fragment3Clear)
        {
            fragment3.SetActive(true);
        }
        if (!fragment1Clear)
        {
            promptText.SetActive(true);
        }
    }

    public void Load()
    {
        if (PlayerPrefs.GetString("level1Cleared") == "true")
        {
            fragment1Clear = true;
        }
        if (PlayerPrefs.GetString("level2Cleared") == "true")
        {
            fragment2Clear = true;
        }
        if (PlayerPrefs.GetString("level3Cleared") == "true")
        {
            fragment3Clear = true;
        }
    }
}
