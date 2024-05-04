using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected BossClass Boss;
    protected GameObject player;
    public Animation motion;
    public ParticleSystem ef;

    public int PagePatenNmber; // index번호로 저장 -> 0 = 1페이지

    //무적인지, 데미지는 몇인지, 등의 변수 추가
    abstract public void StartSkill();
    abstract public void CheckSkill();
    abstract public void Start_(BossClass boss_); // 메모리 할당 같은 개념

}
