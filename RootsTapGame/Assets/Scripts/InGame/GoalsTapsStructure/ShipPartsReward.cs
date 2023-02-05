using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mission/MissionReward/ShipPart", fileName = "ShipPart_Reward")]
public class ShipPartsReward : RewardMission
{
    [SerializeField]
    private Sprite shipPart;

    public Sprite ShipPart { get => shipPart; set => shipPart = value; }
}
