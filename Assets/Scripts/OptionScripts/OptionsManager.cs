using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{

    bool musicOn=true, soundOn=true;

    static OptionsManager instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ManageMusic()
    {
        musicOn = !musicOn;
    }

    public bool GetMusicStatues()
    {
        return musicOn;
    }

    public void ManageSound()
    {
        soundOn= !soundOn;
    }

    public bool GetSoundStatues()
    {
        return soundOn;
    }
}
