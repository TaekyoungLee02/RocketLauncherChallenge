using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 aesteriod를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 aesteriod들을 인식할 수 있음.
    [SerializeField] private float radius = 10f;
    [SerializeField] LayerMask aesteriodLayer;
    private float alertThreshold;

    private Animator animator;
    private static readonly int blinking = Animator.StringToHash("isBlinking");

    private void Start()
    {
        animator = GetComponent<Animator>();
        // FOV를 라디안으로 변환하고 코사인 값을 계산

        alertThreshold = Mathf.Cos(Mathf.Deg2Rad * fov / 2);
    }

    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        // 주변 반경의 소행성들을 확인하고 이를 감지하여 Alert를 발생시킴(isBlinking -> true)

        var col = Physics2D.OverlapCircleAll(transform.position, radius, aesteriodLayer);

        foreach(var aesteriod in col)
        {
            Vector2 up = transform.TransformDirection(Vector2.up).normalized;
            Vector2 dist = (aesteriod.transform.position - transform.position).normalized;

            if (Vector2.Dot(up, dist) > alertThreshold)
            {
                animator.SetBool(blinking, true);
                return;
            }
        }

        animator.SetBool(blinking, false);
    }
}