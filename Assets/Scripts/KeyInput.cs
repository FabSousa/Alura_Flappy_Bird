using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInput : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private UnityEvent onKeyPressed;

    private void Awake(){
        if(keyCode == KeyCode.None)
            Debug.LogWarning("Nenhuma tecla reservada para o jogador");
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode)){
            onKeyPressed.Invoke();
        }
    }
}
