using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Geekbrains
{
    public class CameraShake:MonoBehaviour
    {
        
        public void CaughtPlayer2()
        {
            Debug.Log("Попався");
        }
        public void Test() 
        {
            Debug.Log("Вы проиграли");
            SceneManager.LoadScene(0);
        }
    }
}
