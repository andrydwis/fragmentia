using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public bool level1Clear;
    public bool level2Clear;
    public bool level3Clear;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public TMPro.TextMeshProUGUI level1Text;
    public TMPro.TextMeshProUGUI level2Text;
    public TMPro.TextMeshProUGUI level3Text;
    public TMPro.TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (level1Clear)
        {
            PlayerPrefs.SetString("level1Cleared", "true");
            level1Text.gameObject.SetActive(true);
            level2.SetActive(true);
        }
        if (level2Clear)
        {
            PlayerPrefs.SetString("level2Cleared", "true");
            level2Text.gameObject.SetActive(true);
            level3.SetActive(true);
        }
        if (level3Clear)
        {
            PlayerPrefs.SetString("level3Cleared", "true");
            level3Text.gameObject.SetActive(true);
        }
        if (level1Clear && level2Clear && level3Clear)
        {
            winText.gameObject.SetActive(true);
        }
    }

    public void Load()
    {
        if (PlayerPrefs.GetString("level1Cleared") == "true")
        {
            level1Clear = true;
        }
        if (PlayerPrefs.GetString("level2Cleared") == "true")
        {
            level2Clear = true;
        }
        if (PlayerPrefs.GetString("level3Cleared") == "true")
        {
            level3Clear = true;
        }
    }
}
