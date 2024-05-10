using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClass : MonoBehaviour
{


    protected List<List<Skill>> SkillsList = new List<List<Skill>>();

    public int[] NextPageHP = { 20, 20, 30, 30 };
    protected int nowPageNUmber;
    //List<> page_skill_List = new
    private enum BossState
    {
        skill,
        skillEnd,
        wait,
        idel,
        endAttack,
        die
    }
    BossState bossState;
    protected float maxHP;
    protected float bossHP;
    public virtual void AniMationStart(AnimationClip ap)
    {
        Debug.Log("이 함수는 override되야 합니다 지금 이 함수가 실행되었다면 해당 스테이지의 보스가 이 함수를 override하지 않은 것입니다. 확인해 주십시오");
    }
}
