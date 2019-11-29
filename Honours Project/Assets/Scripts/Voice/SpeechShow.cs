using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechShow : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private MeshRenderer thisMesh;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //initialize
        thisMesh = this.gameObject.GetComponentInParent<MeshRenderer>();
        canvas = this.gameObject.GetComponent<Canvas>();

        keywords.Add("Hide", () =>
        {
            HideDisplayCalled();
        });

        keywords.Add("Show", () =>
        {
            ShowDisplayCalled();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    private void HideDisplayCalled()
    {
        thisMesh.enabled = false;
        canvas.enabled = false;
    }

    private void ShowDisplayCalled()
    {
        thisMesh.enabled = true;
        canvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
