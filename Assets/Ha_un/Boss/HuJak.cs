using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuJak : BossClass , BossManagerInterface, BossBattleInterface
{
    Modified_Data GameDate;
    BossManager bossManager;
    GameObject player;
    public List<GameObject> Skills = new List<GameObject>();
    private GameObject nowSkillGameObject;

    int MaxPage_indexNumber = 4;
    //List<List<Skill>> SkillsList = new List<List<Skill>>();
    void Start()
    {
        GameDate = GameObject.Find("Modified Data Object").GetComponent<Modified_Data>();
        bossManager = GameObject.Find("BossManager").GetComponent<BossManager>();
        player = GameObject.FindWithTag("Player");

        maxHP = GameDate.MaxHP;
        bossHP = maxHP;
        Debug.Log(nowPageNUmber);
        //리셋할거 -_-
        for (int i = 0; i < MaxPage_indexNumber + 1; i++)
        {
            SkillsList.Add(new List<GameObject>());
        }
        Start_SkillSetting();

    }
    void Start_SkillSetting()
    {
        foreach (var item in Skills)
        {
            item.GetComponent<Skill>().Setting(this);
            SkillsList[item.GetComponent<Skill>().PageIndex].Add(item);
        }
    }
    
    void Update()
    {
        BossMoveCheck();
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
        int a = (Random.Range(0, 1000000 * SkillsList[nowPageNUmber].Count)) % SkillsList[nowPageNUmber].Count;
        
        // 방향에 따라서 생성해야 하는거 아닌가??......
        nowSkillGameObject = Instantiate(SkillsList[nowPageNUmber][a], transform);

        nowSkillGameObject.GetComponent<Skill>().Setting(this);
        nowSkillGameObject.GetComponent<Skill>().StartSkill();
        BossF();
    }

    //----------------------------------------------------
    public override void AniMationStart(AnimationClip ap)
    {
        Animator AA = GetComponent<Animator>();
        AA.Play(ap.name);
        BossF();
    }

    int BossManagerInterface.NowPageNumber()
    {
        return nowPageNUmber;
    }
    public override int Vector_RL()
    {
        if (player.transform.position.x > transform.position.x) // 오른쪽 방향 입력
        {
            return 1;
        }
        return -1;
    }
    private void BossF()
    {
        if (Vector_RL() == 1)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Vector_RL() == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private float MoveSpeed;

    MoveState moveState = MoveState.stop;
    public override void BossMove(MoveState ms, float lenspeed)
    {
        MoveSpeed = lenspeed;
        moveState = ms;
        switch(ms)
        {
            case MoveState.stop:
                break;
            case MoveState.trans:
                if (Vector_RL() == 1) MovePoint = bossManager.MapRight.position;
                else MovePoint = bossManager.MapLeft.position;
                break;
            case MoveState.tp:
                transform.position += new Vector3(Vector_RL() * lenspeed, 0, 0);
                break;
            case MoveState.back_tp:
                if (transform.rotation.y == 0) transform.position += new Vector3(lenspeed, 0, 0);
                else transform.position += new Vector3(-lenspeed, 0, 0);
                break;

        }
    }
    Vector3 MovePoint;
    private void BossMoveCheck()
    {
        switch(moveState)
        {
            case MoveState.trans:
                transform.position = Vector3.MoveTowards(transform.position, MovePoint, Time.deltaTime * MoveSpeed);
                break;
            case MoveState.rigid:
                break;
            case MoveState.grape:
                break;
        }
    }

}