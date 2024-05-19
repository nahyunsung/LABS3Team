using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    //Skill할당하면 조건. collider있어야함?아마도?, 애니메이션 넣야함, 시간 다 입력 해야함
    protected Collider2D c2;
    protected BossClass Boss;
    protected GameObject player;
    public AnimationClip motion;
    public ParticleSystem ef;

    public float skillDamage;
    protected enum SkillState
    {
        wait,
        motionStart,
        attackStart,
        attackEnd,
        end
    }
    protected SkillState skillState = SkillState.wait;
    [Header("timer")]
    protected bool isAttack = false;
    protected float nowTime = 0.0f;

    public float motionStartTime;
    public float AttackStartTime;
    public float AttackEndTime;
    public float EndingTime;

    public int PageIndex; // index번호로 저장 -> 0 = 1페이지


    

    //무적인지, 데미지는 몇인지, 등의 변수 추가
    abstract public void StartSkill();
    abstract public void Setting(BossClass boss_); // 메모리 할당 같은 개념
    abstract public void End();

}
