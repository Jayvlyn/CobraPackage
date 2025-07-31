using UnityEngine;

namespace Cobra.GUI
{
    public class PauseController : MonoBehaviour
    {
        private float previousTimeScale;
        public void Pause()
        {
            AudioListener.pause = true;
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void Resume()
        {
            AudioListener.pause = false;
            Time.timeScale = previousTimeScale;
        }
    }
}
