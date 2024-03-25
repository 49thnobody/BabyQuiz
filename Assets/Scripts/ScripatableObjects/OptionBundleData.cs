using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New OptionBundleData", menuName = "Option Bundle Data")]
    public class OptionBundleData : ScriptableObject
    {
        [SerializeField]
        private OptionDataData[] optionData;

        public OptionDataData[] OptionData => optionData;

        public int Size => optionData.Length;
    }
}