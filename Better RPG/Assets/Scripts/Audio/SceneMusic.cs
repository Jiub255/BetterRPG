using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip sceneMusic;
    public GameEventAudioClip gameEventAudioClip;

    // need to raise this after prefabs have been instantiated
    public void StartSceneMusic()
    {
        gameEventAudioClip.Raise(sceneMusic);
    }
}