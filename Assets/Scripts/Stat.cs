using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stat : MonoBehaviour
{
    public FirstPersonAIO firstPersonAIO;

    public static int point = 0;
    public int objective;
    public static int ammo;
    public static int life = 3;
    public string levelRightNow;

    public TMPro.TextMeshProUGUI ammoText;
    public TMPro.TextMeshProUGUI pointText;
    public TMPro.TextMeshProUGUI lifeText;
    public TMPro.TextMeshProUGUI objectiveText;

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = ammo.ToString();
        pointText.text = point.ToString();
        lifeText.text = life.ToString();
        objectiveText.SetText("Objective : Collect " + point.ToString() + "/" + objective.ToString() + " Points");

        IsWin();
    }

    IEnumerator OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Enemy") || hit.CompareTag("DeathZone"))
        {
            Stat.life--;
            point = 0;
            if (life <= 0)
            {
                TimeManager.isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                losePanel.SetActive(true);
                firstPersonAIO.controllerPauseState = true;
            }
            else
            {
                deathPanel.SetActive(true);
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void IsWin()
    {
        if (point == objective)
        {
            TimeManager.isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winPanel.SetActive(true);
            firstPersonAIO.controllerPauseState = true;

            if (levelRightNow == "Level1")
            {
                PlayerPrefs.SetString("level1Cleared", "true");
            }
            if (levelRightNow == "Level2")
            {
                PlayerPrefs.SetString("level2Cleared", "true");
            }
            if (levelRightNow == "Level3")
            {
                PlayerPrefs.SetString("level3Cleared", "true");
            }
        }
    }
}
