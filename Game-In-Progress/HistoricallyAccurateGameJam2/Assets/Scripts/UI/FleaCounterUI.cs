using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace HAGJ2.UI
{
    public class FleaCounterUI : MonoBehaviour
    {
        [SerializeField] IntVariable fleasGlobalVal = null;
        [SerializeField] TMP_Text myText = null;

        private void Start() 
        {
            myText.text = fleasGlobalVal.GetValue().ToString("##0");
        }

        public void UpdateFleas()
        {
            myText.text = fleasGlobalVal.GetValue().ToString("##0");
        }
        
    }

}