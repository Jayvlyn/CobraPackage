using NaughtyAttributes;
using UnityEngine;

namespace Cobra
{
    public class WCT_BlackoutSceneTransition : SceneTransitionDeparture
    {
        [SerializeField] private RectTransform blackoutScene;
        [SerializeField] private float speed;
        

        protected override void Transition()
        {
            blackoutScene.transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }

        protected override void StartTransition()
        {
            blackoutScene.gameObject.SetActive(true);
        }

        protected override bool IsTransitionComplete()
        {
            return blackoutScene.anchoredPosition.x > 0;
        }
    }
}
