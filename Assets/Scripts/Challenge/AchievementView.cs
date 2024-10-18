using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        for(int i = 0; i < achievements.Length; i++)
        {
            var achieveSlot = Instantiate(achievementSlotPrefab, transform).GetComponent<AchievementSlot>();
            achieveSlot.Init(achievements[i]);

            achievementSlots.Add(achievements[i].threshold, achieveSlot);
        }
    }

    public void UnlockAchievement(int threshold)
    {
        achievementSlots[threshold].MarkAsChecked();
    }
}