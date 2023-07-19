using Targets;
using TMPro;
using UnityEngine;

namespace LevelManagement
{
    [DefaultExecutionOrder(99999)]
    public class EnemyCounterText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemyCounterText;

        private void OnEnable()
        {
            SetEnemyCounter();
            LevelEnd.OnEnemyDead += SetEnemyCounter;
        }

        private void OnDisable()
        {
            LevelEnd.OnEnemyDead -= SetEnemyCounter;
        }

        private void SetEnemyCounter()
        {
            var str = string.Format("{0}/{1}", LevelEnd.DeadEnemyCount, TargetManager.TotalEnemyCount);

            enemyCounterText.SetText(str);
        }
    }
}
