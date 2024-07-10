using UnityEngine;
using System.Collections;

public class CloudFloatDown : MonoBehaviour
{
    public float floatHeight = 2.0f; 
    public float floatSpeed = 2.0f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StartCoroutine(FloatObject(other.gameObject));
        }
    }

    private IEnumerator FloatObject(GameObject obj)
    {
        Vector3 startPos = obj.transform.position;
        Vector3 endPos = new Vector3(startPos.x, startPos.y - floatHeight, startPos.z);

        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime);
            elapsedTime += Time.deltaTime * floatSpeed;
            yield return null;
        }

        // Ensure the object stays at the end position
        obj.transform.position = endPos;

        // Disable the Rigidbody2D gravity and velocity to stop it from moving
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
    }
}
