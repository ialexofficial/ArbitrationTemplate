using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
        [field: SerializeField] public Button NextButton { get; private set; }
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public Button HomeButton { get; private set; }
}