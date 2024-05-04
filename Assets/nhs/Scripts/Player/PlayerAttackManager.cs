using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] private Transform AttackRange;
    [SerializeField] private LayerMask AttackMonster;
    [SerializeField] private float PlayerAttackRange;

    [SerializeField] GameObject Attackeffect; // 추후 간략한 작업필요

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject monster = isMonster().gameObject;
            //monster.SendMessage(); 공격 피깍는거
            Instantiate(Attackeffect, monster.transform.position, Quaternion.identity);
            
        }
    }

    
    private Collider2D isMonster()
    {
        return Physics2D.OverlapCircle(AttackRange.position, PlayerAttackRange, AttackMonster);
    }

}
