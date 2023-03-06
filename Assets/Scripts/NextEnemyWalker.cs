using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextEnemyWalker : MonoBehaviour
{
    public enum MovmentType
    {
        Moving,
        Lerping
    }

    public MovmentType Type = MovmentType.Moving;
    public EnemyWalker MyPath;
    public float spped = 1;
    public float maxDistance = .1f;

    public IEnumerator<Transform> pointInPath;

    void Start()
    {
        if(MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;


    }
    public void Spawn()
    {
        transform.position = pointInPath.Current.position;
    }

    void Update()
    {
        if(pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if(Type == MovmentType.Moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * spped);
        }
        else if(Type == MovmentType.Lerping)
        {
            transform.position = Vector2.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * spped);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;

        if (distanceSqure < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }



    }


}
