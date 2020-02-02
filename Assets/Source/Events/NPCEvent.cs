using UnityEngine;
using UnityEngine.Events;

public class NPCEvent : MonoBehaviour
{
    public MeshRenderer dialogRender;
    
    public void showDialog() {
        dialogRender.enabled = true;
    }

    public void hideDialog() {
        dialogRender.enabled = false;
    }
}
