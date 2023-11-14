using Infinity.ECS.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.Infinity.ECS.System
{
    [BurstCompile]
    public partial struct CreateEntitySys : ISystem
    {

        void OnCreate(ref SystemState state)
        {
        }

        void OnDestroy(ref SystemState state)
        {
        }

        void OnUpdate(ref SystemState state)
        {
            var ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
            state.Dependency = new CreateHumanJob() { ecbParallelWrite = ecb.AsParallelWriter() }.ScheduleParallel(state.Dependency);

            state.Enabled = false;
        }

        [BurstCompile]
        private partial struct CreateHumanJob : IJobEntity
        {
            public EntityCommandBuffer.ParallelWriter ecbParallelWrite;
            void Execute([ChunkIndexInQuery] int chunkIndex, RefRO<SpawnerComp> spawnerComp)
            {
                var eArr = new NativeArray<Entity>(spawnerComp.ValueRO.num, Allocator.Temp);
                ecbParallelWrite.Instantiate(chunkIndex, spawnerComp.ValueRO.entity, eArr);
            }
        }
    }
}