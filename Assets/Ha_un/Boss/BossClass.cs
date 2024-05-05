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

}
