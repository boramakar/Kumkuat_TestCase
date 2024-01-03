using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

    [CreateAssetMenu(fileName = "ColorData", menuName = "Kumkuat/SO/Color Data", order = 2)]
    public class ColorData : SerializedScriptableObject
    {
        public Dictionary<Enums.ListItemBackgroundColorType, Color> ListItemBackgroundColors;
    }