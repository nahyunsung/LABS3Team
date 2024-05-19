using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClass : MonoBehaviour
{


    protected List<List<GameObject>> SkillsList = new List<List<GameObject>>();
    
    public enum MoveState
    {
        trans,
        rigid,
        grape,
        tp,
        back_tp,
        stop
    }
    public int[] NextPageHP = { 20, 20, 30, 30 };
    protected int nowPageNUmber;
    //List<> page_skill_List = new
    
    protected float maxHP;
    protected float bossHP;
    public virtual void AniMationStart(AnimationClip ap)
    {
        Debug.Log("이 함수는 override되야 합니다 지금 이 함수가 실행되었다면 해당 스테이지의 보스가 이 함수를 override하지 않은 것입니다. 확인해 주십시오");
    }
    public virtual int Vector_RL()
    {
        Debug.Log("이 함수는 override되야 합니다 지금 이 함수가 실행되었다면 해당 스테이지의 보스가 이 함수를 override하지 않은 것입니다. 확인해 주십시오");
        return 0;
    }
    public virtual void BossMove(MoveState ms, float lenspeed) { }
}
