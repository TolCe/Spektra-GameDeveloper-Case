using UnityEngine;
using UnityEngine.AI;

public static class NavmeshControl
{
    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance, float yPos)
    {
        Vector3 destination = Vector3.zero;
        Vector3 randomPoint = Random.insideUnitSphere * maxDistance + center;
        randomPoint.y = yPos;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, maxDistance, NavMesh.AllAreas))
        {
            destination = hit.position;
        }

        return hit.position;
    }
}