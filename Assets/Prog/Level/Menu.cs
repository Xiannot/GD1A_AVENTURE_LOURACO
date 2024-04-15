using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    // Start is called before the first frame update
    public void Jouer()
    {
        SceneManager.LoadSceneAsync("Village");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            setMusicVolume();
        }
        
    }

    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        setMusicVolume();
    }
}