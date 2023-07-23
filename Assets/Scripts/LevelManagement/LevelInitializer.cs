using SaveLoad;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    [DefaultExecutionOrder(-9999999)]
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] List<GameObject> levelPrefabs;

        private const float LevelChangeWaitTime = 3f;

        private void OnEnable()
        {
            Instantiate(levelPrefabs[CustomPlayerPref.LevelIndex]);

            LevelEnd.ResetEnemyCounterData();
            LevelEnd.OnLevelWin += NextLevel;
            LevelEnd.OnLevelLose += RestartLevel;
        }

        private void OnDisable()
        {
            LevelEnd.OnLevelWin -= NextLevel;
            LevelEnd.OnLevelLose -= RestartLevel;
        }

        private void NextLevel()
        {
            IncreaseLevelIndex();

            StartCoroutine(WaitThenChangeLevel());
        }

        private void RestartLevel()
        {
            StartCoroutine(WaitThenChangeLevel());
        }

        private void IncreaseLevelIndex()
        {
            if (CustomPlayerPref.LevelIndex < levelPrefabs.Count - 1)
                CustomPlayerPref.LevelIndex++;
            else
                CustomPlayerPref.LevelIndex = 0;
        }

        private IEnumerator WaitThenChangeLevel()
        {
            yield return new WaitForSeconds(LevelChangeWaitTime);

            SceneManager.LoadScene("GamePlay");
        }
    }
}
