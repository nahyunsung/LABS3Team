using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour // 소리 루프 담당
{
	AudioClip page1;
	AudioClip page2;
	AudioClip page3;
	AudioClip page4;
	AudioClip page5;

	AudioSource AS;

	BossManagerInterface Boss;
    bool IsBossBattleStart = true;
    public float[] page_LoopTime = { 3.5f, 3.5f, 2.5f, 4.0f, 3.0f };
    public float[] page_SumTime = { 14f, 14f, 15f, 16f, 12f };
    private void Start()
	{
		Boss = GameObject.FindWithTag("Boss").GetComponent<BossManagerInterface>();
    }
    float skillTime = 0.0f;
    float loopTime = 0.0f;
    int nowPage = 0;
    private void Update()
    {
        /*
        if (IsBossBattleStart)
        {
            skillTime += Time.deltaTime;
            loopTime += Time.deltaTime;
            if(loopTime > page_SumTime[nowPage])
            {
                loopTime = 0.0f;
                skillTime = 0.0f;
                AudioClipEnd();
            }
            if(skillTime > page_LoopTime[nowPage])
            {
                skillTime -= page_LoopTime[nowPage];
                PatenStart();
            }
        }*/
        skillTime += Time.deltaTime;
        if (skillTime > 3.5f)
        {
            skillTime -= 3.5f;
            PatenStart();
        }
    }
    void PatenStart()
    {
        Boss.BossManagerStartSkill();
    }

	void AudioClipEnd() // 오디오 클립이 끝날때 호출되는 함수
	{
		if(Boss.IsNextHP())
		{
			// 다음 노래 시작
			Boss.NextPage();// 보스 다음 페이지 시작
        }
		else
		{
			// 노래 루프
		}
	}
}
