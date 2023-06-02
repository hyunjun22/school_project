using UnityEngine;

public static class Extensions // Ȯ�� �޼���
{
    // transform.DotTest�� ����� �� �ִ�.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection)  > 0.25f;
    }

    public static Vector2 direction(this Transform transform, Transform other)
    {
        // other -> transfrom(����)�� ���ϴ� ����
        Vector2 dir = transform.position - other.position;
        return dir.normalized;
    }
}
