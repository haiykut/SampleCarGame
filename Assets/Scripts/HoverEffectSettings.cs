using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace haiykut
{
    [CreateAssetMenu(menuName = "haiykut/HoverSettings")]
    public class HoverEffectSettings : ScriptableObject
    {
        [Header("Hover Effect")]
        public Effect effect;
        [Header("Is it a button?")]
        public bool button = false;
        public enum Effect{
            Scale,
            Color,
            ScaleAndColor
        }
        [Header("Color Settings")]
        public Color initialColor = Color.white;
        public Color hoverColor = Color.black;

        [Header("Scale Settings")]
        public int initialSize = 20;
        public int hoverSize = 40;

    }
}

