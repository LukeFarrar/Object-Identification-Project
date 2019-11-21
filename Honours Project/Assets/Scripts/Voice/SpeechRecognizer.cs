using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class SpeechRecognizer : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //initialize
        canvas = this.gameObject.GetComponent<Canvas>();

        keywords.Add("Hide display", () =>
        {
            HideDisplayCalled();
        });

        keywords.Add("Show display", () =>
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

        if(keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    private void HideDisplayCalled()
    {
        canvas.enabled = false;
    }

    private void ShowDisplayCalled()
    {
        canvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
