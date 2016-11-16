using UnityEngine;
using System.Collections;
using SmartLocalization;
using UnityEngine.UI;
public class SmartLocalizeIngame : MonoBehaviour {

    public Text results;
    public Text earnings;
    public Text conticoins;
    public Text score;
    public Text correct;
    public Text instruction;
    public Text taptocontinue;
    public Text[] sentence;
	// Use this for initialization
	 void Start()
    {
        LanguageManager languageManager = LanguageManager.Instance;
        languageManager.OnChangeLanguage += OnChangeLanguage;
       
    }
	void OnDestroy()
    {
        if(LanguageManager.HasInstance)
        {
            LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
        }
    }
	// Update is called once per frame
    void OnChangeLanguage(LanguageManager thisLanguageManager)
    {
        results.text = PlayerPrefs.GetString("results");
        earnings.text = PlayerPrefs.GetString("earnings");
        conticoins.text = PlayerPrefs.GetString("conticoins");
        score.text = PlayerPrefs.GetString("score");
        instruction.text = PlayerPrefs.GetString("instruction");
        correct.text = PlayerPrefs.GetString("correct");
        taptocontinue.text = PlayerPrefs.GetString("taptocontinue");
        sentence[0].text = PlayerPrefs.GetString("sentence_1");
        sentence[1].text = PlayerPrefs.GetString("sentence_2");
        sentence[2].text = PlayerPrefs.GetString("sentence_3");
    }
    public void isEnglish()
    {
      
        LanguageManager.Instance.ChangeLanguage("en");
    }
    public void isGerman()
    {

        LanguageManager.Instance.ChangeLanguage("de-DE");
    }
}
