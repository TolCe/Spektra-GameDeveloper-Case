using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float _viewRadius;
    [Range(0, 360)][SerializeField] private float _viewAngle;

    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstacleMask;

    [SerializeField] private Character _attachedCharacter;
    public List<Character> VisibleTargets { get; private set; }

    [SerializeField] private float _meshResolution;
    [SerializeField] private int _edgeResolveIterations;
    [SerializeField] private float _edgeDistanceThreshold;

    [SerializeField] private float _maskCutawayDistance = 0.1f;

    [SerializeField] private MeshFilter _viewMeshFilter;
    private Mesh _viewMesh;

    private const string ViewMeshKey = "ViewMesh";

    private void Awake()
    {
        SetViewMesh();
        VisibleTargets = new List<Character>();
    }

    private void Update()
    {
        FindVisibleTargets();
        DrawFieldOfView();
    }

    private void SetViewMesh()
    {
        _viewMesh = new Mesh();
        _viewMesh.name = ViewMeshKey;
        _viewMeshFilter.mesh = _viewMesh;
    }

    private void FindVisibleTargets()
    {
        VisibleTargets.Clear();
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);

        for (int i = 0; i < collidersInRange.Length; i++)
        {
            Character character = collidersInRange[i].GetComponentInParent<Character>();
            if (character != null && character.HealthController.IsAlive && character != _attachedCharacter)
            {
                Vector3 targetPosition = character.GetPosition();
                Vector3 directionToTarget = (targetPosition - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < _viewAngle * 0.5f)
                {
                    float distanceFromTarget = Vector3.Distance(transform.position, targetPosition);
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceFromTarget, _obstacleMask))
                    {
                        VisibleTargets.Add(character);
                    }
                }
            }
        }

        for (int i = VisibleTargets.Count - 1; i < 0; i++)
        {
            if (i + 1 < VisibleTargets.Count)
            {
                if (Vector3.Distance(VisibleTargets[i].GetPosition(), transform.position) < Vector3.Distance(VisibleTargets[i - 1].GetPosition(), transform.position))
                {
                    Character cacheTarget = VisibleTargets[i - 1];
                    VisibleTargets[i - 1] = VisibleTargets[i];
                    VisibleTargets[i] = cacheTarget;
                }
            }
        }
    }

    private void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
        float stepAngleSize = _viewAngle / stepCount;

        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - _viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i > 0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.Distance - newViewCast.Distance) > _edgeDistanceThreshold;
                if (oldViewCast.Hit != newViewCast.Hit || (oldViewCast.Hit && newViewCast.Hit && edgeDstThresholdExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.PointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.PointA);
                    }
                    if (edge.PointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.PointB);
                    }
                }
            }

            viewPoints.Add(newViewCast.Point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.forward * _maskCutawayDistance;

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        _viewMesh.Clear();

        _viewMesh.vertices = vertices;
        _viewMesh.triangles = triangles;
        _viewMesh.RecalculateNormals();
    }

    private EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.Angle;
        float maxAngle = maxViewCast.Angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < _edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.Distance - newViewCast.Distance) > _edgeDistanceThreshold;
            if (newViewCast.Hit == minViewCast.Hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.Point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.Point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }

    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 direction = DirectionFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, _viewRadius, _obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * _viewRadius, _viewRadius, globalAngle);
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfo
    {
        public bool Hit;
        public Vector3 Point;
        public float Distance;
        public float Angle;

        public ViewCastInfo(bool hit, Vector3 point, float distance, float angle)
        {
            Hit = hit;
            Point = point;
            Distance = distance;
            Angle = angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 PointA;
        public Vector3 PointB;

        public EdgeInfo(Vector3 pointA, Vector3 pointB)
        {
            PointA = pointA;
            PointB = pointB;
        }
    }
}
