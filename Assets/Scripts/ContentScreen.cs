using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentScreen : MonoBehaviour
{
        [field: SerializeField] public Button NextButton { get; private set; }
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public Button HomeButton { get; private set; }
        [field: SerializeField] public TMP_Text Name { get; private set; }
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public TMP_Text Text { get; private set; }
} 