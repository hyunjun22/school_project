using UnityEngine;

public static class Extensions // Ȯ�� �޼���
{
    // transform.DotTest�� ����� �� �ִ�.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection)  > 0.25f;
    }

    //#.���� ���ϱ�
    public static Vector2 direction(this Transform transform, Transform other)
    {
        // other(���) -> transfrom(����)�� ���ϴ� ����
        Vector2 dir = transform.position - other.position;
        return dir.normalized;
    }

    //#.���� ���ϱ�
    public static float GetAngle (this Transform transform, Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        // ���� vStart ���� vEnd : 0��
        // �Ʒ� vStart �� vEnd  : 90��
        // ���� vEnd ���� vStart : 180��
        // �Ʒ� vEnd �� vStart  : 270��

        // return : -180 ~ 180 degree (for unity)
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
