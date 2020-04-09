using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace HAGJ2.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] TMP_Text timeTextToUpdate = null;
        float startTime = 0f;

        void Start()
        {
            startTime = Time.time;
        }

        void Update()
        {
            float time = Time.time - startTime;

            string minutes = ((int) time / 60).ToString("00");
            string seconds = (time % 60).ToString("0#");

            timeTextToUpdate.text = minutes + ":" + seconds; 
        }
    }
}
