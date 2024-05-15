using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCutting : Skill // 가만히 서서 공격
{

    private void Update()
    {
        nowTime += Time.deltaTime;
        if (EndingTime <= nowTime) End();
    }


    public override void StartSkill()
    {
        Boss.AniMationStart(motion);
        
    }
    public override void Setting(BossClass boss_)
    {
        Boss = boss_;
        player = GameObject.FindWithTag("Player");
    }
    public override void End()
    {

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1111111111111공격 성공 (플레이어에게 피격판정 닿고, 공격 한번만");
        if (other.tag == "Player" && !isAttack && nowTime >= AttackStartTime)
        {
            Debug.Log("공격 성공 (플레이어에게 피격판정 닿고, 공격 한번만");
            isAttack = true;
        }
    }
}
