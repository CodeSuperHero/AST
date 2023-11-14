using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.ECS.Authoring
{
    public class Spawner : MonoBehaviour
    {
        public float radius;

        public GameObject prefab;

        public int num;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            
        }
#endif
    }
}
