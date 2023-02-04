using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Animator fadeController;

    public void FadeIn()
    {
        fadeController.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        fadeController.SetTrigger("FadeOut");
    }
}
