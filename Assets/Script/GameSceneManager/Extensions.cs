using UnityEngine;

public static class Extensions // 확장 메서드
{
    // transform.DotTest로 사용할 수 있다.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection)  > 0.25f;
    }

    //#.각도 구하기
    public static Vector2 direction(this Transform transform, Transform other)
    {
        // other(상대) -> transfrom(본인)로 향하는 방향
        Vector2 dir = transform.position - other.position;
        return dir.normalized;
    }

    //#.각도 구하기
    public static float GetAngle (this Transform transform, Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        // 우측 vStart 좌측 vEnd : 0도
        // 아래 vStart 위 vEnd  : 90도
        // 우측 vEnd 좌측 vStart : 180도
        // 아래 vEnd 위 vStart  : 270도

        // return : -180 ~ 180 degree (for unity)
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
