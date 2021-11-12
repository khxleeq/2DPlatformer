
using UnityEngine;

public class BossFireBallHolder : MonoBehaviour
{
    [SerializeField] private Transform boss;

    private void Update()
    {
        transform.localScale = boss.localScale;
    }
}
