using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationSheet : MonoBehaviour {
    public enum Mode { UpDown,  DownUp}

    public Mode animationMode;
    public bool playAutomatic;
    public bool loop;
    public bool destroyOnFinish;
    public Sprite[] spritesToAnimate;
    public float framesPerSecond;

    float changeInterval;

    void Start()
    {
        if (playAutomatic)
        {
            Play();
        }
    }

    public void Play()
    {
        changeInterval = 1 / framesPerSecond;
        StartCoroutine("AnimateSprites");
    }

    public void Stop()
    {
        StopCoroutine("AnimateSprites");
    }

    int _currentSprite;
    IEnumerator AnimateSprites()
    {
        if(animationMode == Mode.UpDown)
        {
            _currentSprite = 0;
            while (true)
            {
                GetComponent<SpriteRenderer>().sprite = spritesToAnimate[_currentSprite];
                _currentSprite++;
                if (_currentSprite == spritesToAnimate.Length)
                {
                    if (loop)
                    {
                        if (destroyOnFinish) Destroy(gameObject);
                        _currentSprite = 0;
                    }
                    else StopCoroutine("AnimateSprites");
                }
                yield return new WaitForSeconds(changeInterval);
            }
        }
        else
        {
            _currentSprite = spritesToAnimate.Length - 1;
            while (true)
            {
                GetComponent<SpriteRenderer>().sprite = spritesToAnimate[_currentSprite];
                _currentSprite--;
                if (_currentSprite == 0)
                {
                    if (loop)
                    {
                        if (destroyOnFinish) Destroy(gameObject);
                        _currentSprite = spritesToAnimate.Length - 1;
                    }
                    else StopCoroutine("AnimateSprites");
                }
                yield return new WaitForSeconds(changeInterval);
            }
        }
    }
}
