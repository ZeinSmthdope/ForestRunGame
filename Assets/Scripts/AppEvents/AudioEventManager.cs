using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;

    public AudioClip bearGrowlAudio;
    public AudioClip catMeowAudio;
    public AudioClip wolfHowlAudio;
    public AudioClip boarOinkAudio;
    public AudioClip spiderHissAudio;
    public AudioClip natureBackgroundAudio;
    public AudioClip playerJumpingAudio;
    public AudioClip playerWalkingAudio;
    public AudioClip snowBackgroundAudio;
    public AudioClip desertBackgroundAudio;
    public AudioClip collectablePickUpAudio;
    public AudioClip playerDamageAudio;
    public AudioClip gameOverAudio;
    public AudioClip collectableDropAudio;
    public AudioClip playerConsumingAudio;
    public AudioClip speedBoostAudio;

    private UnityAction<string> genericEventListener;
    private AudioSource currBackgroundMusic;
    private AudioSource currWalkingAudio;


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
            case "wolfHowl":
                snd.audioSrc.clip = this.wolfHowlAudio;
                snd.audioSrc.volume = 0.5f;
                break;
            case "spiderHiss":
                snd.audioSrc.clip = this.spiderHissAudio;
                break;
            case "boarOink":
                snd.audioSrc.clip = this.boarOinkAudio;
                break;
            case "natureBackground":
                snd.audioSrc.clip = this.natureBackgroundAudio;
                snd.audioSrc.volume = 0.25f;
                configureLoopingClip(snd);
                break;
            case "playerJumping":
                snd.audioSrc.clip = this.playerJumpingAudio;
                snd.audioSrc.volume = 0.35f;
                break;
            case "playerWalking":
                snd.audioSrc.clip = this.playerWalkingAudio;
                snd.audioSrc.volume = 0.5f;
                this.currWalkingAudio = snd.audioSrc;
                break;
            case "stopPlayerWalking":
                if (currWalkingAudio != null && currWalkingAudio.isPlaying) {
                    this.currWalkingAudio.Stop();
                }
                break;
            case "snowBackground":
                snd.audioSrc.clip = this.snowBackgroundAudio;
                snd.audioSrc.volume = 0.25f;
                configureLoopingClip(snd);
                break;
            case "desertBackground":
                snd.audioSrc.clip = this.desertBackgroundAudio;
                snd.audioSrc.volume = 0.25f;
                configureLoopingClip(snd);
                break;
            case "speedBoost":
                snd.audioSrc.clip = this.speedBoostAudio;
                snd.audioSrc.volume = 0.10f;
                break;
            case "playerConsuming":
                snd.audioSrc.clip = this.playerConsumingAudio;
                snd.audioSrc.volume = 1.0f;
                break;
            default:
                Debug.LogError("No valid clip found for '" + clipName + "'.");
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