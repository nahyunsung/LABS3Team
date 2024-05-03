using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] private Transform AttackRange;
    [SerializeField] private LayerMask AttackMonster;
    [SerializeField] private float PlayerAttackRange;

    [SerializeField] GameObject Attackeffect; // ���� ������ �۾��ʿ�

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject monster = isMonster().gameObject;
            //monster.SendMessage(); ���� �Ǳ�°�
            Instantiate(Attackeffect, monster.transform.position, Quaternion.identity);
            
        }
    }

    
    private Collider2D isMonster()
    {
        return Physics2D.OverlapCircle(AttackRange.position, PlayerAttackRange, AttackMonster);
    }

}
