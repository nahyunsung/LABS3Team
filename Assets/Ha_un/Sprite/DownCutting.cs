using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCutting : Skill
{
    public override void CheckSkill()
    {
        
    }

    public override void StartSkill()
    {
        Boss.AniMationStart(motion);
    }

    public override void Start_(BossClass boss_)
    {
        Boss = boss_;
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("1111111111111공격 성공 (플레이어에게 피격판정 닿고, 공격 한번만");
        if (other.tag == "Player" && !isAttack && nowTime >= dealStart)
        {
            Debug.Log("공격 성공 (플레이어에게 피격판정 닿고, 공격 한번만");
            isAttack = true;
        }
    }
}
