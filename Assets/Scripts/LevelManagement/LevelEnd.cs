using System;
using Targets;

namespace LevelManagement
{
    public static class LevelEnd
    {
        public static Action OnEnemyDead;
        public static Action OnLevelWin;
        public static Action OnLevelLose;

        private static int deadEnemyCount = 0;
        public static int DeadEnemyCount { get => deadEnemyCount; }

        static LevelEnd()
        {
            OnEnemyDead += IncreaseDeadEnemyCount;
            OnEnemyDead += CheckLevelEnd;
        }

        private static void CheckLevelEnd()
        {
            if (deadEnemyCount == TargetManager.TotalEnemyCount)
                OnLevelWin?.Invoke();
        }

        private static void IncreaseDeadEnemyCount()
        {
            deadEnemyCount++;
        }
    }
}
