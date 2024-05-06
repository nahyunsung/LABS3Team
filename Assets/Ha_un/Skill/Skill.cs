using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected BossClass Boss;
    protected GameObject player;
    public AnimationClip motion;
    public ParticleSystem ef;

    public float skillDamage;

    [Header("timer")]
    protected bool isAttack = false;
    protected float nowTime = 0.0f;

    public float dealStart;
    
    public float EndingTime;

    public int PageIndex; // index번호로 저장 -> 0 = 1페이지


    private void Update()
    {
        nowTime += Time.deltaTime;
    }

    //무적인지, 데미지는 몇인지, 등의 변수 추가
    abstract public void StartSkill();
    abstract public void CheckSkill();
    abstract public void Start_(BossClass boss_); // 메모리 할당 같은 개념

    
}
