using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance = null;
    public static AudioManager Instance()
    {
        return _instance;
    }

    public AudioClip bgm;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        GetComponent<AudioSource>().clip = bgm;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }

    public void PlaySfx(AudioClip sfx)
    {
        GetComponent<AudioSource>().PlayOneShot(sfx);
    }

    public void SetBgmVolme()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }
}
