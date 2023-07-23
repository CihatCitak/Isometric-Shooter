using TMPro;
using SaveLoad;
using UnityEngine;
using LevelManagement;

namespace UI
{
    [DefaultExecutionOrder(-99999999)]
    public class GamePlayUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI levelWinLoseText;

        private const string LevelWinStr = "Level {0} Win";
        private const string LevelLoseStr = "Level {0} Lose";

        private void OnEnable()
        {
            LevelEnd.OnLevelWin += SetLevelWinText;
            LevelEnd.OnLevelLose += SetLevelLoseText;
        }
        private void OnDisable()
        {
            LevelEnd.OnLevelWin -= SetLevelWinText;
            LevelEnd.OnLevelLose -= SetLevelLoseText;
        }

        private void SetLevelWinText()
        {
            SetLevelWinLoseText(LevelWinStr);
        }

        private void SetLevelLoseText()
        {
            SetLevelWinLoseText(LevelLoseStr);
        }

        private void SetLevelWinLoseText(string str)
        {
            string formatStr = string.Format(str, CustomPlayerPref.LevelIndex + 1);

            levelWinLoseText.SetText(formatStr);
        }
    }
}
