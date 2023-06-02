using UnityEngine;

public static class Extensions // 확장 메서드
{
    // transform.DotTest로 사용할 수 있다.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection)  > 0.25f;
    }

    public static Vector2 direction(this Transform transform, Transform other)
    {
        // other -> transfrom(본인)로 향하는 방향
        Vector2 dir = transform.position - other.position;
        return dir.normalized;
    }
}
