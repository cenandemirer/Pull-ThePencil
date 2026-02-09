using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip ballTouch, bomb, intoTheBox, lose, pencilMove, win, bigBallPop, ballonBurst;
    [SerializeField] AudioSource audioSource;


    public static SoundManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ballTouch = Resources.Load<AudioClip>("ballTouch");
        bomb = Resources.Load<AudioClip>("bomb");
        intoTheBox = Resources.Load<AudioClip>("intoTheBox");
        lose = Resources.Load<AudioClip>("lose");
        pencilMove = Resources.Load<AudioClip>("pencilMove");
        win = Resources.Load<AudioClip>("win");
        bigBallPop = Resources.Load<AudioClip>("bigBallPop");
        ballonBurst = Resources.Load<AudioClip>("ballonBurst");

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "balltouch":
                audioSource.PlayOneShot(ballTouch);
                break;
            case "bomb":
                audioSource.PlayOneShot(bomb);
                break;
            case "intoTheBox":
                audioSource.PlayOneShot(intoTheBox);
                break;
            case "lose":
                audioSource.PlayOneShot(lose);
                break;
            case "pencilMove":
                audioSource.PlayOneShot(pencilMove);
                break;
            case "win":
                audioSource.PlayOneShot(win);
                break;
            case "bigBallPop":
                audioSource.PlayOneShot(bigBallPop);
                break;

            case "ballonBurst":
                audioSource.PlayOneShot(ballonBurst);
                break;
        }
    }

}
