using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossManagerInterface // bossManager가 boss들을 관리하기 위한 목적의 인터페이스
{
    public bool IsNextHP();
    public void NextPage();
    public void BossManagerStartSkill();
    public int NowPageNumber();
}

public interface BossBattleInterface // bossManager가 boss들을 관리하기 위한 목적의 인터페이스
{
    public bool Attacked(float demage_);
}
