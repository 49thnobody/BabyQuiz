using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New OptionBundleData", menuName = "Option Bundle Data")]
    public class OptionBundleData : ScriptableObject
    {
        [SerializeField]
        private OptionData[] optionData;

        public OptionData[] OptionData => optionData;

        public int Size => optionData.Length;
    }
}