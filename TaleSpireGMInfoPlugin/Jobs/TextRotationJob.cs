using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace GMInfoPlugin.Jobs
{
    [BurstCompile]
    struct TextRotationJob : IJobParallelFor
    {
        public NativeArray<Vector3> CreaturePositions;
        public NativeArray<Quaternion> BlockRotation;
        public Vector3 CameraPosition;

        public void Execute(int i)
        {
            BlockRotation[i] = Quaternion.LookRotation(CreaturePositions[i] - CameraPosition);
        }
    }
}
