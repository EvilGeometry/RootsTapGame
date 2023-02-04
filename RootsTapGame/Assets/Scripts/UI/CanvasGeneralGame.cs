using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGeneralGame : MonoBehaviour
{
    private static CanvasGeneralGame instance;

    public static CanvasGeneralGame Instance {get => instance;}
    public Fade Fade { get => fade;}

    [SerializeField]
    private Fade fade;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
