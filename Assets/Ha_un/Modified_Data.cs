using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modified_Data : MonoBehaviour
{
    [Header("Date Setting")]
    public int[] NextPageHP = { 20, 20, 30, 30 };
    public int sumHP;

    HuJak Boss;
    public int MaxHP = 100;
    [Header("스킬 종류")]
    public List<Skill> Skills = new List<Skill>();

    [Header("UI Object")]
    public Text PageText;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindWithTag("Boss").GetComponent<HuJak>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss != null)
        {
            Boss.NextPageHP = this.NextPageHP;
            PageText.text = "Page " + Boss.BossPageCheck();

            
        }
        else
		{
            Debug.Log("Boss 오브젝트를 찾을 수 없음. 보스가 있는지, 보스 태그가 붙어있는지 확인 바람");
		}

        int a = 0;
        foreach (int item in NextPageHP)
        {
            a += item;
        }
        sumHP = a;
    }

}
