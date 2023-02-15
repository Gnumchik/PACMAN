using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalker : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }

    public PathTypes pathTypes;
    public int movmentDirection = 1;
    public int movingTo = 0;
    public Transform[] PathElements;

    public void OnDrawGizmos()
    {
        if(PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for(var i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);

        }

        if(pathTypes == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);

        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if(PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[movingTo];

            if(PathElements.Length == 1)
            {
                continue;
            }

            if(pathTypes == PathTypes.linear)
            {
                if(movingTo <= 0)
                {
                    movmentDirection = 1;
                }
                else if (movingTo >= PathElements.Length - 1)
                {
                    movmentDirection = -1;
                }
            }

            movingTo = movingTo + movmentDirection;

            if(pathTypes == PathTypes.loop)
            {
                if(movingTo>= PathElements.Length)
                {
                    movingTo = 0;
                }

                if(movingTo < 0)
                {
                    movingTo = PathElements.Length - 1;
                }
            }

        }

    }
}
