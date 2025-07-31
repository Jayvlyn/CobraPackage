using UnityEngine;

namespace Cobra.Utilities
{
    public static class MathUtils
    {
        public static bool Chance(float value)
        {
            return UnityEngine.Random.Range(0f, 100f) < value;
        }

        public static bool CompareLayerMask(LayerMask layerMask, int layer)
        {
            return (layerMask & (1 << layer)) != 0;
        }
    }
}
