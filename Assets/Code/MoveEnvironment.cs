using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Rigidbody rb;
    [SerializeField]private float levelSpeed;
    private float width;
    private LaserTowerController laserTowerController;
    [SerializeField] private float height;
    [SerializeField] private float elevationSpeed;
    [SerializeField] private int totalPlatforms;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        laserTowerController = GetComponent<LaserTowerController>();
        width = boxCollider.size.z;
        boxCollider.enabled = false;
    }

    private void Update()
    {
        levelSpeed = GameManager.Instance.levelSpeed;
        rb.linearVelocity = levelSpeed * Vector3.forward;
        if(transform.position.y != 0 && rb.linearVelocity.y == 0)
        {
            StartCoroutine(ElevatePlatform());
        }
        if(transform.position.z < -width)
        {
            laserTowerController.SetLasers();
            Vector3 resetPosition = new Vector3(0, height, width* totalPlatforms);
            transform.position = (Vector3)transform.position + resetPosition;
        }
    }

    private IEnumerator ElevatePlatform()
    {
        rb.linearVelocity += (Vector3.up * elevationSpeed);
        while(transform.position.y < 0)
        {
            yield return null;
        }
        transform.position = new Vector3(0, 0, transform.position.z);
        rb.linearVelocity = levelSpeed * Vector3.forward;
    }
}
