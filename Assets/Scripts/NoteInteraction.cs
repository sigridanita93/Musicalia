using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
  private void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            Destroy(other.gameObject);
        }
    }
}
