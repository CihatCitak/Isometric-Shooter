using UnityEngine;

namespace SaveLoad
{
    public class CustomPlayerPref
    {
        private const string LevelIndexStr = "LevelIndex";

        public static int LevelIndex
        {
            get
            {
                return PlayerPrefs.GetInt(LevelIndexStr, 0);
            }
            set
            {
                PlayerPrefs.SetInt(LevelIndexStr, value);
            }
        }
    }
}
