using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private bool _isDead = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle") && !_isDead)
            Death();
        else if (col.gameObject.CompareTag("Objective"))
            col.gameObject.GetComponent<ObjectiveMovement>().FisherObj.StartLeaving();
        else if (col.gameObject.CompareTag("TriggerEnd Left"))
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("TriggerEnd Right").transform.position.x -
                                  1.5f, transform.position.y, transform.position.z);
        else if (col.gameObject.CompareTag("TriggerEnd Right"))
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("TriggerEnd Left").transform.position.x + 2.0f, 
                transform.position.y, transform.position.z);
    }

    private void Death()
    {
        _isDead = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        AudioManager.Instance.PlaySFX("morte");
        Invoke("Restart", 1.5f);
    }

    private void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
