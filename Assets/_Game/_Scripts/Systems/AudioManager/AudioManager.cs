using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Music[] musics;
    [SerializeField] private SFX[] sfxs;

    private static float musicCurTime;
    private static string musicCurName;

    private AudioSource curMusicAudioSource;

    private GameObject musicCurObj;

    public static AudioManager Instance;

    private void Awake() => Instance = this;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            PlayMusic("menu");
        else
            PlayMusic("ingame");
    }

    private void Update()
    {
        if (curMusicAudioSource != null) musicCurTime = curMusicAudioSource.time;
    }

    public void PlaySFX(string name)
    {
        foreach (SFX s in sfxs)
        {
            if (s.Clip.name == name)
            {
                var sfx = new GameObject("SFX " + s.Clip.name);
                var sAudioSource = sfx.AddComponent<AudioSource>();
                sAudioSource.clip = s.Clip;
                sAudioSource.volume = s.Volume;
                sAudioSource.pitch = s.Pitch;
                sAudioSource.Play();
                Destroy(sfx, 5f);
                break;
            }
        }
    }

    public void PlayMusic(string name)
    {
        foreach (Music m in musics)
        {
            if (m.Clip.name == name)
            {
                var mObj = new GameObject("Music " + m.Clip.name);
                var mAudioSource = mObj.AddComponent<AudioSource>();
                mAudioSource.clip = m.Clip;
                mAudioSource.volume = m.Volume;
                if (musicCurTime != 0 && m.Clip.name == musicCurName)
                {
                    mAudioSource.time = musicCurTime;
                }
                else
                {
                    Destroy(musicCurObj);
                }

                musicCurObj = mObj;
                musicCurName = m.Clip.name;
                mAudioSource.Play();
                mAudioSource.loop = true;

                curMusicAudioSource = mAudioSource;
            }
        }
    }
}
