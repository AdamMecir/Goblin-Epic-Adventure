using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int PloskaDamage = 5;
    public int SipDamage = 50;
    public int BossDamageCollision = 10;
    public int HurtStoneDamage = 200;
    public int MinionDamage = 5;

    // Speeds

    public float VelocityArrow = 500f;

    public float PlayerMoveSpeed = 150f;
    public float PlayerLimitSpeed = 1.3f;


    public float SlimeNormalSpeed = 100f;
    public float SlimeSpeedIn2rotation = 150f;
    public float SlimeSpeedIn3rotation = 80f;

    public float GolemNormalSpeed = 100f;

    public float HurtStonevelocity = 40f;
    public float PushStoneVelocity = 200f;

    //cooldowns

    public float ArcherSpecialCooldown = 1f;
    public float ArcherSpaceCooldown = 0.3f;

    // Max health

    public int BossMaxHealth = 5000;
    public int GolemMaxHealth = 7000;

    public int PlayerMaxHealth = 2000;
    public int MinionMaxHealth = 500;
    // SlimeHealth Roatation
    public int SlimeHealthFor1Rotation = 4000;
    public int SlimeHealthFor2Rotation = 2500;

    // GolemHealth rotation

    public int GolemHealthFor1Rotation = 6100;
    public int GolemHealthFor2Rotation = 4000;
    public int GolemHealthFor3Rotation = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
