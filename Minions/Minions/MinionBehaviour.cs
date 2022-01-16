using UnityEngine;

namespace Minions
{
    internal class MinionBehaviour : MonoBehaviour
    {
        private static float _baseSize = 1f;
        private static float _minionSize = 0.999f;

        public void SetMinionState()
        {

        }

        public static bool IsMinion(GameObject obj)
        {
            if (obj.transform.localPosition.x != _minionSize)
            {
                return false;
            }
            if (obj.GetComponent<MinionBehaviour>() == null)
            {
                return false;
            }
            return true;
        }
    }
}
