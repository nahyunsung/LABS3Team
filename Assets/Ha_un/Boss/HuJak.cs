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
        Start_SkillSetting();
        rb = GetComponent<Rigidbody2D>();
        GameDate = GameObject.Find("Modified Data Object").GetComponent<Modified_Data>();
        bossManager = GameObject.Find("BossManager").GetComponent<BossManager>();
        player = GameObject.FindWithTag("Player");

        maxHP = GameDate.MaxHP;
        bossHP = maxHP;
        Debug.Log(nowPageNUmber);
        //리셋할거 -_-
    }
    void Start_SkillSetting()
    {
        foreach (var item in Skills)
        {
            item.Start_(this);
            SkillsList[item.PagePatenNmber].Add(item);
        }
    }
    
    void Update()
    {

    }



    public void BossManagerStartSkill()
    {
        int a = (Random.Range(0, 10000 * SkillsList[nowPageNUmber].Count)) % SkillsList[nowPageNUmber].Count;
        SkillsList[nowPageNUmber][a].StartSkill();
    }
    

    //---------------------------------테스트 용 정보 열람 허용 코드들
    public string BossPageCheck() { return nowPageNUmber.ToString(); }
    
    public float dashLenght;
    void A_DashSkill()
    {
        RaycastHit2D hit;
        if (transform.position.x - player.transform.position.x > 0)
        {
            transform.position += new Vector3(-dashLenght, 0, 0);
            hit = Physics2D.Raycast(transform.position, -transform.right, dashLenght);
        }
        else
        {
            transform.position += new Vector3(dashLenght, 0, 0);
            hit = Physics2D.Raycast(transform.position, transform.right, dashLenght);
        }
        if (hit.collider.gameObject != null)
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Debug.Log("보스 \"대쉬\" 스킬에 맞음! 구현 위치");
                //hit.transform.gameObject.   플레이어 공격 함수
            }
        }
        else Debug.Log("객체 없음 -> 버그 발생");
        
    }
    bool isGrounded;
    bool wasGroundedLastFrame;
    public float jumpForce = 10f;
    void B_JumpSkill()
    {
        //isGrounded = Physics2D.OverlapCircle(transform.position, 0.16f, groundLayer);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void Cutting()
    {

    }



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

    }
}