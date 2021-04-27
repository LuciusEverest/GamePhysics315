using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public struct Circle
{
    public float radius { get; set; }
    public Vector2 center { get; set; }

    public Circle(Vector2 center, float radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public bool Contains(Vector2 point)
    {
        Vector2 direction = center - point;
        float sqrDistance = direction.sqrMagnitude;
        float sqrRadius = (radius * radius);

        return (sqrDistance <= sqrRadius);
    }

    public bool Contains(Circle circle)
    {
        Vector2 direction = center - circle.center;
        float sqrDistance = direction.sqrMagnitude;
        float sqrRadius = ((radius + circle.radius) * (radius + circle.radius));

        return (sqrDistance <= sqrRadius);
    }
}
