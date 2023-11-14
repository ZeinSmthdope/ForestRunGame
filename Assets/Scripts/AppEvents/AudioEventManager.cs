using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;

    public AudioClip bearGrowlAudio;
    public AudioClip catMeowAudio;
    public AudioClip NatureBackgroundAudio;
    public AudioClip playerJumpingAudio;
    public AudioClip playerWalkingAudio;
    public AudioClip SnowBackgroundAudio;
    public AudioClip collectablePickUpAudio;
    public AudioClip playerDamageAudio;
    public AudioClip gameOverAudio;
    public AudioClip collectableDropAudio;

    private UnityAction<string> genericEventListener;
    private AudioSource currBackgroundMusic;


    void Awake()
    {
        genericEventListener = new UnityAction<string>(genericEventHandler);
    }


    // Use this for initialization
    void Start()
    {
    }


    void OnEnable()
    {
        EventManager.StartListening<GenericEvent, string>(genericEventListener);

        // send starting background music
        EventManager.TriggerEvent<GenericEvent, string>("natureBackground");
    }

    void OnDisable()
    {
        EventManager.StopListening<GenericEvent, string>(genericEventListener);
    }

    void genericEventHandler(string clipName)
    {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, GameObject.Find("Player").transform);

            configureClip(clipName, snd);
            snd.audioSrc.Play();
        }
    }

    private void configureClip(string clipName, EventSound3D snd)
    {

        snd.audioSrc.volume = 1.0f;
        snd.audioSrc.spatialBlend = 0.0f; // makes volume 2D to be louder

        // decide which audio clip to use based on string
        switch (clipName) {
            case "collectablePickUp":
                snd.audioSrc.clip = this.collectablePickUpAudio;
                break;
            case "playerDamage":
                snd.audioSrc.clip = this.playerDamageAudio;
                break;
            case "gameOver":
                snd.audioSrc.clip = this.gameOverAudio;
                break;
            case "collectableDrop":
                snd.audioSrc.clip = this.collectableDropAudio;
                break;
            case "bearGrowl":
                snd.audioSrc.clip = this.bearGrowlAudio;
                break;
            case "catMeow":
                snd.audioSrc.clip = this.catMeowAudio;
                break;
            case "natureBackground":
                snd.audioSrc.clip = this.NatureBackgroundAudio;
                snd.audioSrc.volume = 1.0f;
                configureLoopingClip(snd);
                break;
            case "playerJumping":
                snd.audioSrc.clip = this.playerJumpingAudio;
                snd.audioSrc.volume = 0.35f;
                break;
            case "playerWalking":
                snd.audioSrc.clip = this.playerWalkingAudio;
                break;
            case "snowBackground":
                snd.audioSrc.clip = this.SnowBackgroundAudio;
                snd.audioSrc.volume = 1.0f;
                configureLoopingClip(snd);
                break;
            default:
                snd.audioSrc.clip = this.collectableDropAudio;
                break;
        }
    }

    private void configureLoopingClip(EventSound3D snd)
    {
        // stop any running background music        
        if (this.currBackgroundMusic != null)
        {
            this.currBackgroundMusic.Stop();
        }

        snd.audioSrc.loop = true;
        this.currBackgroundMusic = snd.audioSrc;
    }
}