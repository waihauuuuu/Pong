using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioClip wall;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            audioSource.PlayOneShot(wall);

            SpriteRenderer wallRenderer = GetComponent<SpriteRenderer>();
            wallRenderer.color = Color.magenta;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            StartCoroutine(ChangeColorBack());   
        }
    }

    private IEnumerator ChangeColorBack() {
        yield return new WaitForSeconds(0.5f);

        SpriteRenderer wallRenderer = GetComponent<SpriteRenderer>();
        wallRenderer.color = Color.white;
    }
}
