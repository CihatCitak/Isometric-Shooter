using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace Healths
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Health health;

        [Header("Fill Bar Image")]
        [SerializeField] Image healthBarFillImage;

        [Header("Health Bar Canvas Game Object")]
        [SerializeField] GameObject canvasGameObject;

        private const float FILL_DURATION = 0.25f;

        public void SetHealthBarRatio()
        {
            if (healthBarFillImage == null)
                return;

            healthBarFillImage.DOFillAmount(CalculateHealthRatio(), FILL_DURATION);
        }

        private float CalculateHealthRatio()
        {
            return (float)health.CurrentHealth / (float)health.MaxHealth;
        }
    }
}
