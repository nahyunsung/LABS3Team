using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuJak : BossClass , BossManagerInterface, BossBattleInterface
{
    Modified_Data GameDate;
    BossManager bossManager;
    GameObject player;
    Rigidbody2D rb;

    public List<Skill> Skills = new List<Skill>();

    int MaxPage_indexNumber = 4;
    //List<List<Skill>> SkillsList = new List<List<Skill>>();
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GameDate = GameObject.Find("Modified Data Object").GetComponent<Modified_Data>();
        bossManager = GameObject.Find("BossManager").GetComponent<BossManager>();
        player = GameObject.FindWithTag("Player");

        maxHP = GameDate.MaxHP;
        bossHP = maxHP;
        Debug.Log(nowPageNUmber);
        //리셋할거 -_-
        for (int i = 0; i < MaxPage_indexNumber + 1; i++)
        {
            SkillsList.Add(new List<Skill>());
        }
        Start_SkillSetting();

    }
    void Start_SkillSetting()
    {
        foreach (var item in Skills)
        {
            item.Start_(this);
            SkillsList[item.PageIndex].Add(item);
        }
    }
    
    void Update()
    {

    }



    public void BossManagerStartSkill()
    {
        
    }
    

    //---------------------------------테스트 용 정보 열람 허용 코드들
    public string BossPageCheck() { return nowPageNUmber.ToString(); }
    



    public bool Attacked(float demage)
    {
        if (true) // 보스가 공격을 당하는 상태(무적X,회피X) 면 = true   공격을 맞지 않으면 = false
        {
            bossHP -= demage;
            return true;
        }
        else
        {
            return false;
        }
    }

    bool BossManagerInterface.IsNextHP()
    {
        if (nowPageNUmber == 0)
        {
            if (bossHP > maxHP * GameDate.NextPageHP[0] / 100)
            {
                return true;
            }
        }
        else if (0 < nowPageNUmber && nowPageNUmber < 3)
        {
            if (maxHP * GameDate.NextPageHP[1] / 100 > bossHP && bossHP > maxHP * GameDate.NextPageHP[2] / 100)
            {
                return true;
            }
        }
        else if (nowPageNUmber == 3)
        {
            if (maxHP * GameDate.NextPageHP[3] / 100 > bossHP)
            {
                return true;
            }
        }
        return false;
    }

    void BossManagerInterface.NextPage()
    {
        nowPageNUmber += 1;
    }

    void BossManagerInterface.BossManagerStartSkill()
    {
        if(SkillsList[nowPageNUmber].Count == 0)
        {
            Debug.Log("아직 해당 패턴에 할당된 스킬이 없습니다! 해당 페이지 인덱스 번호가 PageIndex에 할당된 스킬을 Hujak.Skills 리스트에 넣어 주세요");
            return;
        }
        int a = (Random.Range(0, 10000 * SkillsList[nowPageNUmber].Count)) % SkillsList[nowPageNUmber].Count;
        SkillsList[nowPageNUmber][a].StartSkill();
    }
}