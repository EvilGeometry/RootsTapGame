using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mission/MissionReward/PowerUp", fileName = "PowerUp_Reward")]
public class PowerUpsReward : RewardMission
{
    [SerializeField]
    private int multiplierTaps;
    [SerializeField]
    private float cooldown = 1f;

    public int MultiplierTaps { get => multiplierTaps; set => multiplierTaps = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
}
