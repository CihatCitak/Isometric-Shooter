using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class TargetManager
    {
        private static List<ITarget> allTargets = new List<ITarget>();

        public static int TotalEnemyCount => allTargets.Count - 1;

        public static void AddTarget(ITarget target)
        {
            allTargets.Add(target);
        }

        public static void RemoveTarget(ITarget target)
        {
            allTargets.Remove(target);
        }

        public static ITarget FindTargetFromTransform(Transform transform)
        {
            for (int i = 0; i < allTargets.Count; i++)
            {
                if (allTargets[i].GetTransform() == transform)
                {
                    return allTargets[i];
                }
            }

            return null;
        }
    }
}


