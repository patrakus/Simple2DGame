using UnityEngine;

public static class UnityVectorExtensions
{
    public static Vector3 GetDirectionTo(this Vector3 startPoint, Vector3 endPoint)
    {
        return endPoint - startPoint;
    }
        
    public static Vector2 GetDirectionTo(this Vector2 startPoint, Vector2 endPoint)
    {
        return endPoint - startPoint;
    }
}