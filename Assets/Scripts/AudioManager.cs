using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public Slider _slider;

    [SerializeField]
    public Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene");
        } else
        {
            instance = this;
        }

        _slider.value = sounds[0].volume;
    }

    void Start ()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
        }

        
    }

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return; 
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
    }

    public void ChangeVolume ()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].volume = _slider.value;
        }
    }
}
