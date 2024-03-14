using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource FXSource;
    public static SoundManager Instance;
    void Awake() {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip){
        FXSource.PlayOneShot(clip);
    }
}
