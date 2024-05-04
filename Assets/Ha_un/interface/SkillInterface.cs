using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SkillInterface // 많은 스킬들이 있을 것이고, 그 스킬을 외부에서 동일하게 접근할 수 있도록 만듬
{
    public void SkillStart(GameObject Boss);
    
}
