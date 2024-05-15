using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCutting : Skill
{
    public override void Setting(BossClass boss_)
    {
        c2 = GetComponent<Collider2D>();
        c2.enabled = false;
        Boss = boss_;
        player = GameObject.FindWithTag("Player");
    }
    public float dashSpeed;
    void Update()
    {
        switch(skillState)
        {
            case SkillState.motionStart:
                nowTime += Time.deltaTime;
                if (AttackStartTime <= nowTime) SkillStateChange(SkillState.attackStart);
                break;
            case SkillState.attackStart:
                nowTime += Time.deltaTime;
                if (AttackEndTime <= nowTime) SkillStateChange(SkillState.attackEnd);
                break;
            case SkillState.attackEnd:
                nowTime += Time.deltaTime;
                if (EndingTime <= nowTime) SkillStateChange(SkillState.end);
                break;
        }
        
    }

    void SkillStateChange(SkillState sk)
    {
        skillState = sk;
        switch(sk)
        {
            case SkillState.attackStart:
                Boss.BossMove(BossClass.MoveState.trans, dashSpeed);
                c2.enabled = true;
                break;
            case SkillState.attackEnd:
                Boss.BossMove(BossClass.MoveState.stop, 0);
                c2.enabled = false;
                break;
            case SkillState.end:
                Boss.BossMove(BossClass.MoveState.stop, 0);
                End();
                break;
        }
    }


    public override void End()
    {
        Destroy(gameObject);
    }

    public override void StartSkill()
    {
        Boss.AniMationStart(motion);
        SkillStateChange(SkillState.motionStart);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asdasdasdasda");
        if (other.tag == "Player" && !isAttack && nowTime >= AttackStartTime)
        {
            Debug.Log("공격 성공 (플레이어에게 피격판정 닿고, 공격 한번만");
            isAttack = true;
        }
    }
}
