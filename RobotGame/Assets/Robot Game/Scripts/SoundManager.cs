using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource ambience;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource sfx1;
    [SerializeField] private AudioSource sfx2;
    [SerializeField] private AudioSource sfx3;

    [SerializeField] private AudioClip fallBgMusic;
    [SerializeField] private AudioClip ambienceSound;
    [SerializeField] private AudioClip level1BgMusic;
    [SerializeField] private AudioClip level2BgMusic;
    [SerializeField] private AudioClip level3BgMusic;
    [SerializeField] private AudioClip level4BgMusic;

    [SerializeField] private AudioClip[] walkSfx;
    [SerializeField] private AudioClip rollSfx;
    [SerializeField] private AudioClip hitGroundSfx;
    [SerializeField] private AudioClip hitGrassSfx;
    [SerializeField] private AudioClip hitWaterSfx;
    [SerializeField] private AudioClip robotShootSfx;
    [SerializeField] private AudioClip playerShootSfx;
    [SerializeField] private AudioClip robotMoveSfx;
    [SerializeField] private AudioClip jumpMoveSfx;

    public bool soundOn = true;
    public int level;
    public enum SFX_TYPES { rollSfx, hitGroundSfx, hitGrassSfx, hitWaterSfx, robotShootSfx, playerShootSfx, robotMoveSfx, jumpMoveSfx};

    void Start()
    {
        playBGMusic(level);
    }

    void Update()
    {

    }

    public void toggleSound()
    {
        soundOn = !soundOn;
        if (soundOn)
        {
            bgMusic.UnPause();
            ambience.UnPause();
        }
        else
        {
            bgMusic.Pause();
            ambience.Pause();
        }


    }


    public void playBGMusic(int level)
    {
        if(!soundOn)
            return;
        switch (level)
        {
            case 0:
                if(fallBgMusic != null) bgMusic.clip = fallBgMusic;
                break;
            case 1:
                if(level1BgMusic != null) bgMusic.clip = level1BgMusic;
                break;
            case 2:
                if(level2BgMusic != null) bgMusic.clip = level2BgMusic;
                break;
            case 3:
                if(level3BgMusic != null) bgMusic.clip = level3BgMusic;
                break;
            case 4:
                if(level4BgMusic != null) bgMusic.clip = level4BgMusic;
                break;
        }
        ambience.clip = ambienceSound;
        ambience.Play();
        bgMusic.Play();

    }

    public void playSfx(SFX_TYPES type)
    {
        if(!soundOn) return;
        switch (type)
        {
            case SFX_TYPES.rollSfx:
                chooseSfxSource(rollSfx);
                break;
            case SFX_TYPES.hitGroundSfx:
                chooseSfxSource(hitGroundSfx);
                break;
            case SFX_TYPES.hitGrassSfx:
                chooseSfxSource(hitGrassSfx);
                break;
            case SFX_TYPES.hitWaterSfx:
                chooseSfxSource(hitWaterSfx);
                break;
            case SFX_TYPES.robotShootSfx:
                chooseSfxSource(robotShootSfx);
                break;
            case SFX_TYPES.playerShootSfx:
                chooseSfxSource(playerShootSfx);
                break;
            case SFX_TYPES.robotMoveSfx:
                chooseSfxSource(robotMoveSfx);
                break;
            case SFX_TYPES.jumpMoveSfx:
                chooseSfxSource(jumpMoveSfx);
                break;
        }

    }

    public void playWalkLoop(bool value)
    {
        if (value == false)
        {
            //walk.Pause();
            return;
        }
        if(walk.clip != null) return;
        
        //walk.UnPause();
        int index = Random.Range(0, walkSfx.Length);
        walk.clip = walkSfx[index];
        walk.Play();
        Invoke(nameof(removeWalkSfxClip), walkSfx[index].length);

    }

    public void chooseSfxSource(AudioClip sfxToPLay)
    {
        if (sfx1.clip == null)
        {
            sfx1.clip = sfxToPLay;
            Invoke(nameof(removeSfx1Clip), sfxToPLay.length);
            sfx1.Play();
        }
        else if (sfx2.clip == null)
        {
            sfx2.clip = sfxToPLay;
            Invoke(nameof(removeSfx2Clip), sfxToPLay.length);
            sfx2.Play();
        }
        else if (sfx3.clip == null)
        {
            sfx3.clip = sfxToPLay;
            Invoke(nameof(removeSfx3Clip), sfxToPLay.length);
            sfx3.Play();
        }



    }

    public void removeSfx1Clip()
    {
        sfx1.clip = null;
    }
    public void removeSfx2Clip()
    {
        sfx2.clip = null;
    }
    public void removeSfx3Clip()
    {
        sfx3.clip = null;
    }

    public void removeWalkSfxClip()
    {
        walk.clip = null;
    }


}
