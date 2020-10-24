using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        Audio.volume = volumeSlider.value;
    }

    public void Load()
    {
        volumeSlider.value = Audio.volume;
    }
}
