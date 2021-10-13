using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanel : MonoBehaviour {
    [Header("Speaker settings")]
    [SerializeField]
    private Image panelImage;
    public Image PanelImage => panelImage;
    [SerializeField]
    private RawImage rightSpeakerImage;
    public RawImage[] SpeakerImages { get; private set; }

    [Header("Text settings")]
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    public TextMeshProUGUI DialogueText => dialogueText;

    private void Awake() {
        SpeakerImages = new RawImage[] {
             rightSpeakerImage
        };
    }
}