using System.Linq;
using UnityEngine;
using TMPro;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;        // Content ������Ʈ
    [SerializeField] GameObject rowPrefab;         // RankRow ������

    StageResultList allData;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        // ������ ��� �ڽ� ������Ʈ ����
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }
        for (int stage = 1; stage <= 5; stage++)
        {
            var sortedData = allData.results.Where(r => r.stage == stage).OrderByDescending(x => x.score).ToList();





            // ��ŷ ������ ����
            for (int i = 0; i < sortedData.Count; i++)
            {
                GameObject row = Instantiate(rowPrefab, contentRoot);
                TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
                rankText.text = $"{i + 1}. {sortedData[i].playerName} -{sortedData[i].stage}- {sortedData[i].score}";
            }
        }
    }
}
