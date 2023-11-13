using Unity.Entities;
using UnityEngine;

namespace Infinity.ECS.Authoring
{
    public class HumanAuthoring : MonoBehaviour
    {
        public float xWidth;
        public float yWidth;
        public float moveSpeed;


        public class HumanAuthoringBaker : Baker<HumanAuthoring>
        {
            public override void Bake(HumanAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new HumanProperty
                {
                    xWidth = authoring.xWidth,
                    yWidth = authoring.yWidth,
                    moveSpeed = authoring.moveSpeed,
                    human = GetEntity(authoring.gameObject, TransformUsageFlags.Dynamic),
                }) ;
            }
        }

        public struct HumanProperty : IComponentData
        {
            public float xWidth;
            public float yWidth;
            public float moveSpeed;
            public Entity human;
        }
    }

}
