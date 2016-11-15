using UnityEngine;
using System.Collections;

using UnityEngine.UI;
/********************************************/
/**
*  \brief
*   - This script handles the fade-in/fade-out that happens during page switching.
***********************************************/
public class LoadingScreenLoading : MonoBehaviour
{
    public LoadingAnim loadingRing;
    public LoadingAnimForText loadingText;
    public GameObject GameplayScene; // for disabling when go back to main menu
    public Text results;
    public Text earnings;
    public Text conticoins;
    public Text score;
    public Text correct;
    public Text instruction;
    public Text taptocontinue;
    public Text[] sentence;
    public float loadingTime = 3.0f;

    void Awake()
    {
        StartLoadingScreen();
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

    public void StartLoadingScreen()
    {
        loadingRing.stopLoading = false;
        loadingText.LoadFinish = false;

        loadingRing.RotateRing();
        loadingText.LoadingTextAnim();
        StartCoroutine(FadeOut());
    }

    public void StartLoadingScreenToMainMenu()
    {
        loadingRing.stopLoading = false;
        loadingText.LoadFinish = false;

        loadingRing.RotateRing();
        loadingText.LoadingTextAnim();
        StartCoroutine(FadeOutToMainMenu());
    }

    public void StartLoadingScreenToGameplay()
    {
        loadingRing.stopLoading = false;
        loadingText.LoadFinish = false;

        loadingRing.RotateRing();
        loadingText.LoadingTextAnim();
        StartCoroutine(FadeOutToGameplay());
    }
	
    IEnumerator FadeOut()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1.0f; // before fade out .. make sure got alpha pls

        yield return new WaitForSeconds(loadingTime);

        while (cg.alpha > 0.0f)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, -1.0f, Time.deltaTime * 1.0f);

            yield return null;
        }

        loadingRing.stopLoading = true;
        loadingText.LoadFinish = true;

        yield return null;
    }

    IEnumerator FadeOutToMainMenu()
    {
        GameManager.instance.GotoScene("MainScene");

        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1.0f; // before fade out .. make sure got alpha pls

        GameplayScene.SetActive(false);

        cg = this.transform.parent.GetComponent<CanvasGroup>();

        yield return new WaitForSeconds(1.25f);

        while (cg.alpha > 0.0f)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, -1.0f, Time.deltaTime * 1.0f);

            yield return null;
        }

        loadingRing.stopLoading = true;
        loadingText.LoadFinish = true;

        yield return null;

        transform.parent.GetComponent<DonDestroyThis>().NowDestroy();
    }

    IEnumerator FadeOutToGameplay()
    {
        GameManager.instance.GotoScene("GamePlay");

        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1.0f; // before fade out .. make sure got alpha pls

        GameplayScene.SetActive(false);

        cg = this.transform.parent.GetComponent<CanvasGroup>();

        yield return new WaitForSeconds(1.25f);

        while (cg.alpha > 0.0f)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, -1.0f, Time.deltaTime * 1.0f);

            yield return null;
        }

        loadingRing.stopLoading = true;
        loadingText.LoadFinish = true;

        yield return null;

        transform.parent.GetComponent<DonDestroyThis>().NowDestroy();
    }
}
