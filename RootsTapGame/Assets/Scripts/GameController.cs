using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public static GameController Instance { get => instance;}

    public MissionInfo_SO CurrentMissionToPlay { get => currentMissionToPlay; set => currentMissionToPlay = value; }

    [SerializeField]
    private MissionInfo_SO currentMissionToPlay;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }    
    }
}
