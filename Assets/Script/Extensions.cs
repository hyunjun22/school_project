using UnityEngine;

public static class Extensions // 확장 메서드
{
    // transform.DotTest로 사용할 수 있다.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection)  > 0.25f;
    }
}
