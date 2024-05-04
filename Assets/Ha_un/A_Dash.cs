using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Dash : Skill
{
    public int dashLen;

    public override void CheckSkill()
    {
        
    }

    public override void Start_(BossClass boss_)
    {
        Boss = boss_;
        player = GameObject.FindWithTag("Player");
        //StartSkill();
        Debug.Log("무사힘 참조 함수 실행()");
        Debug.Log(dashLen);
    }

    public override void StartSkill()
    {
        //motion.Play();
        //ef.Play();
        RaycastHit2D hit;
        if (transform.position.x - player.transform.position.x > 0)
        {
            transform.position += new Vector3(-dashLen, 0, 0);
            hit = Physics2D.Raycast(transform.position, -transform.right, dashLen);
        }
        else
        {
            transform.position += new Vector3(dashLen, 0, 0);
            hit = Physics2D.Raycast(transform.position, transform.right, dashLen);
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
}
