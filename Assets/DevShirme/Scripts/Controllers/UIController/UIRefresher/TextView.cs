using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DevShirme.UIModule
{
    public abstract class TextView : MonoBehaviour
    {
        [SerializeField] protected TMP_Text text;
        public abstract void SetText(int amount);
        public abstract void SetText();
    }
}

