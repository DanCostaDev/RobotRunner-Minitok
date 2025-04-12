using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GameOver();

    }
}
