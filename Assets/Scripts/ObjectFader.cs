using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{

    public float fadeSpeed = 10f;
    public float fadeAmount = 0.4f;
    float originalOpacity;
    SpriteRenderer sr;
    public bool doFade = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalOpacity = sr.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (doFade){
            FadeNow();
        }else{
            ResetFade();
        }
    }

    // Object Fader works better when there is 1 large object the player is behind, as opposed to multiple objects.
    // Such as 1 tree as opposed to a forrest
    void FadeNow()
    {
        Color currentColour = sr.color;
        Color smoothColour = new Color(currentColour.r, currentColour.g, currentColour.b,
            Mathf.Lerp(currentColour.a, fadeAmount, fadeSpeed * Time.deltaTime));
            sr.color =smoothColour;
    }

    void ResetFade()
    {
        Color currentColour = sr.color;
        Color smoothColour = new Color(currentColour.r, currentColour.g, currentColour.b,
            Mathf.Lerp(currentColour.a, originalOpacity, fadeSpeed * Time.deltaTime));
            sr.color =smoothColour;
    }
}
