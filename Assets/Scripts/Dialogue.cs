using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public TMPro.TextMeshProUGUI dialogText;
    public string[] sentences;
    public float typingSpeed;
    public GameObject nextButton;
    public GameObject startButton;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogText.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Next()
    {
        nextButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogText.text = "";
            startButton.SetActive(true);
        }
    }
}
