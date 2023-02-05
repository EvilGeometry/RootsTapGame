using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusGame {InMap, Idle, Play, Pause, GameOver}

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController instance;

    public static GameController Instance { get => instance;}
    #endregion

    #region properties
    public MissionInfo_SO CurrentMissionToPlay { get => currentMissionToPlay; set => currentMissionToPlay = value; }
    public StatusGame CurrentStatusGame { get => currentStatusGame; set => currentStatusGame = value; }
    #endregion

    [SerializeField]
    private StatusGame currentStatusGame;

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
