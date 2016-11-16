using UnityEngine;
using System.Collections;
using SmartLocalization;
using UnityEngine.UI;
public class SmartLocal : MonoBehaviour
{
    #region mainmenu
    public Text PlayGame;
    public Text message_1;
    public Text message_2;
    public Text message_3;
    public Text message_4;
    public Text social_score;
    public Text People_Organization;
    public Text Production_Delivery;
    public Text Product_Production_Process_Development;
    public Text Management_Support_Process;
    public Text Supplier_Management;
    public Text Go;
    public int langauage_num;
    public Text stage;
    #endregion
    #region settings
    public Text settings_credit;
    public Text settings_default_settings;
    public Text settings_music;
    public Text settings_sfx;
    public Text settings_english;
    public Text settings_german;
    public Text settings_profilename;
    public Text settings_on;
    public Text settings_off;
    #endregion
    #region badges
    public Text badges_title;
    public Text[] badges_description_final;
    public Text badges_description_1;
    public Text badges_description_2;
    public Text badges_description_3;
    public Text badges_description_4;
    public Text badges_description_5;
    public Text badges_description_6;
    public Text badges_description_7;
    public Text badges_description_8;
    public Text badges_description_1_1;
    public Text badges_description_1_2;
    public Text badges_description_1_3;
    public Text badges_description_2_1;
    public Text badges_description_2_2;
    public Text badges_description_2_3;
    public Text badges_description_3_1;
    public Text badges_description_3_2;
    public Text badges_description_3_3;
    public Text badges_description_4_1;
    public Text badges_description_4_2;
    public Text badges_description_4_3;
    public Text badges_description_5_1;
    public Text badges_description_5_2;
    public Text badges_description_5_3;
    public Text badges_description_6_1;
    public Text badges_description_6_2;
    public Text badges_description_6_3;
    public Text badges_description_7_1;
    public Text badges_description_7_2;
    public Text badges_description_7_3;
    public Text badges_description_8_1;
    public Text badges_description_8_2;
    public Text badges_description_8_3;
    #endregion
    #region Badge tier limits
    //Badge 1
    public const int ARCADEATTEMPTS_EASY = 2;
    public const int ARCADEATTEMPTS_MED = 10;
    public const int ARCADEATTEMPTS_HIGH = 20;

    //Badge 3
    public const int SPEEDRUN_EASY = 40;
    public const int SPEEDRUN_MED = 30;
    public const int SPEEDRUN_HIGH = 20;

    //Badge 4
    public const int CORRECTSINAROW_EASY = 2;
    public const int CORRECTSINAROW_MED = 4;
    public const int CORRECTSINAROW_HIGH = 6;

    //Badge 5
    public const int TOTALPLAYTIME_EASY = 600;         //10 MINS
    public const int TOTALPLAYTIME_MED = 1200;         //20 MINS
    public const int TOTALPLAYTIME_HIGH = 1800;        //30 MINS

    //Badge 7
    public const int ARCADESCORE_EASY = 20;
    public const int ARCADESCORE_MED = 30;
    public const int ARCADESCORE_HIGH = 40;

    //Badge 8
    public const float SHOPPERCENT_EASY = 30.0f;
    public const float SHOPPERCENT_MED = 50.0f;
    public const float SHOPPERCENT_HIGH = 100.0f;

    //Badge 9
    public const int STAGEALLCORRECT_EASY = 1;
    public const int STAGEALLCORRECT_MED = 2;
    public const int STAGEALLCORRECT_HIGH = 3;

    //Badge 10
    public const int CUMULATIVESCORE_EASY = 100;
    public const int CUMULATIVESCORE_MED = 200;
    public const int CUMULATIVESCORE_HIGH = 300;

    #endregion
    #region shop   
    public Text prop_grass;
    public Text prop_trafficlight;
    public Text prop_streetlamp;
    public Text prop_mailbox;
    public Text prop_billboard;
    public Text prop_bicycle;
    public Text prop_busstop;
    public Text prop_bench;
    public Text prop_utilitypole;
    public Text prop_utilitypole_lamp;
    public Text prop_firehydrant;
    public Text prop_tree;
    public Text prop_sign1;
    public Text prop_sign2;
    public Text prop_sign3;
    public Text prop_sign4;
    public Text prop_speedcamera;
    public Text prop_cone;
    public Text prop_pole;
    public Text prop_roadblock1;
    public Text prop_roadblock2;
    public Text prop_trashbin;
    public Text prop_tumbleweed;
    public Text prop_agave;
    public Text prop_yucca;
    public Text prop_bud;
    public Text prop_cactus;
    public Text prop_palmtree;
    public Text prop_rock;
    public Text prop_snowman;
    public Text prop_fence;
    public Text prop_pinetree;
    public Text prop_city;
    public Text prop_desert;
    public Text prop_winter;
    public Text prop_electricitybox;
    public Text prop_streetlamp2;
    public Text prop_streetlamp3;
    public Text prop_streetlamp4;
    public Text prop_streetsign;
    public Text prop_telephonebooth;
    public Text prop_trafficlight2;
    public Text gender_male;
    public Text gender_female;
    public Text gender;
    public Text car;
    public Text car_SUV;
    public Text car_coupe;
    public Text car_sedan;
    public Text Enviroment;
    public Text Enviroment_Winter;
    public Text Enviroment_Desert;
    public Text Enviroment_City;
    public Text tabs_gender;
    public Text tabs_car;
    public Text tabs_environment;
    public Text tabs_props;
    public Text Select;
    public Text Close;
    #endregion
    #region statistics
    public Text statistics_correct;
    public Text statistics_wrong;
    public Text statistics_winstreak;
    public Text statistics_losestreak;
    public Text statistics_highestscore;
    public Text statistics_highestearning;
    public Text statistics_totalplaytime;
    #endregion
    #region ingame
    public Text results;
    public Text earnings;
    public Text conticoins;
    public Text score;
    public Text correct;
    public Text instruction;
    public Text taptocontinue;
    public Text[] sentence;
    private string english;
    private string german;
    #endregion
    public int progress;
    public GameObject statistics;
	// Use this for initialization
    void Start()
    {
        english = "questons";
        german = "questions-DE";

        if (!LanguageManager.HasInstance)
        {
            LanguageManager languageManager = LanguageManager.Instance;
            languageManager.OnChangeLanguage += OnChangeLanguage;
            LanguageManager.Instance.ChangeLanguage("en");
        }
       
        langauage_num = 0;
    }
    /*
	void OnDestroy()
    {
        if(LanguageManager.HasInstance)
        {
            LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
        }
    }*/
	// Update is called once per frame
    void OnChangeLanguage(LanguageManager thisLanguageManager)
    {
        #region settings
        settings_credit.text = thisLanguageManager.GetTextValue("settings_credit");
        settings_default_settings.text = thisLanguageManager.GetTextValue("settings_default_settings");
        settings_music.text = thisLanguageManager.GetTextValue("settings_music");
        settings_sfx.text = thisLanguageManager.GetTextValue("settings_sfx");
        settings_english.text = thisLanguageManager.GetTextValue("settings_english");
        settings_german.text = thisLanguageManager.GetTextValue("settings_german");
        settings_profilename.text = thisLanguageManager.GetTextValue("settings_profilename");
        settings_on.text = thisLanguageManager.GetTextValue("settings_on");
        settings_off.text = thisLanguageManager.GetTextValue("settings_off");
        badges_title.text = thisLanguageManager.GetTextValue("badges_title");
        #endregion
        #region badges
        badges_description_1.text = thisLanguageManager.GetTextValue("badges_description_1");
        if (GameControl.handle.player.arcademodeAttempts < ARCADEATTEMPTS_EASY)
        {
            badges_description_1_1.text = thisLanguageManager.GetTextValue("badges_description_1_1");
        }
        else if (GameControl.handle.player.arcademodeAttempts >= ARCADEATTEMPTS_EASY && GameControl.handle.player.arcademodeAttempts < ARCADEATTEMPTS_MED)
        {
            badges_description_1_2.text = thisLanguageManager.GetTextValue("badges_description_1_2");
        }
        else if (GameControl.handle.player.arcademodeAttempts >= ARCADEATTEMPTS_MED && GameControl.handle.player.arcademodeAttempts < ARCADEATTEMPTS_HIGH)
        {
            badges_description_1_3.text = thisLanguageManager.GetTextValue("badges_description_1_3");
        }
        else
        {
            badges_description_final[0].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        badges_description_2.text = thisLanguageManager.GetTextValue("badges_description_2");
        if (GameControl.handle.player.cumulativeScore < CUMULATIVESCORE_EASY)
        {
            badges_description_2_1.text = thisLanguageManager.GetTextValue("badges_description_2_1");
        }
        else if (GameControl.handle.player.cumulativeScore >= CUMULATIVESCORE_EASY && GameControl.handle.player.cumulativeScore < CUMULATIVESCORE_MED)
        {
            badges_description_2_2.text = thisLanguageManager.GetTextValue("badges_description_2_2");
        }
        else if (GameControl.handle.player.cumulativeScore >= CUMULATIVESCORE_MED && GameControl.handle.player.cumulativeScore < CUMULATIVESCORE_HIGH)
        {
            badges_description_2_3.text = thisLanguageManager.GetTextValue("badges_description_2_3");
        }
        else
        {
            badges_description_final[1].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        
        badges_description_3.text = thisLanguageManager.GetTextValue("badges_description_3");
        if (GameControl.handle.player.speedrunTimer > SPEEDRUN_EASY || GameControl.handle.player.speedrunTimer <= 0)
        {
            badges_description_3_1.text = thisLanguageManager.GetTextValue("badges_description_3_1");
        }
        else if (GameControl.handle.player.speedrunTimer > SPEEDRUN_MED && GameControl.handle.player.speedrunTimer <= SPEEDRUN_EASY)
        {
            badges_description_3_2.text = thisLanguageManager.GetTextValue("badges_description_3_2");
        }
        else if (GameControl.handle.player.speedrunTimer > SPEEDRUN_HIGH && GameControl.handle.player.speedrunTimer <= SPEEDRUN_MED)
        {
            badges_description_3_3.text = thisLanguageManager.GetTextValue("badges_description_3_3");
        }
        else
        {
            badges_description_final[2].text = thisLanguageManager.GetTextValue("badges_description_final");
        }        
        badges_description_4.text = thisLanguageManager.GetTextValue("badges_description_4");
        if (GameControl.handle.player.correctsInARow < CORRECTSINAROW_EASY)
        {
            badges_description_4_1.text = thisLanguageManager.GetTextValue("badges_description_4_1");
        }
        else if (GameControl.handle.player.correctsInARow < CORRECTSINAROW_MED && GameControl.handle.player.correctsInARow >= CORRECTSINAROW_EASY)
        {
            badges_description_4_2.text = thisLanguageManager.GetTextValue("badges_description_4_2");
        }
        else if (GameControl.handle.player.correctsInARow < CORRECTSINAROW_HIGH && GameControl.handle.player.correctsInARow >= CORRECTSINAROW_MED)
        {
            badges_description_4_3.text = thisLanguageManager.GetTextValue("badges_description_4_3");
        }
        else
        {
            badges_description_final[3].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        
        badges_description_5.text = thisLanguageManager.GetTextValue("badges_description_5");
        
        if (GameControl.handle.player.totalPlaytime < TOTALPLAYTIME_EASY)
        {
            badges_description_5_1.text = thisLanguageManager.GetTextValue("badges_description_5_1");
        }
        else if (GameControl.handle.player.totalPlaytime < TOTALPLAYTIME_MED && GameControl.handle.player.totalPlaytime >= TOTALPLAYTIME_EASY)
        {
            badges_description_5_2.text = thisLanguageManager.GetTextValue("badges_description_5_2");
        }
        else if (GameControl.handle.player.totalPlaytime < TOTALPLAYTIME_HIGH && GameControl.handle.player.totalPlaytime >= TOTALPLAYTIME_MED)
        {
            badges_description_5_3.text = thisLanguageManager.GetTextValue("badges_description_5_3");
        }
        else
        {
            badges_description_final[4].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        
        badges_description_6.text = thisLanguageManager.GetTextValue("badges_description_6");
        if (GameControl.handle.player.arcadeScore < ARCADESCORE_EASY)
        {
            badges_description_6_1.text = thisLanguageManager.GetTextValue("badges_description_6_1");
        }
        else if (GameControl.handle.player.arcadeScore < ARCADESCORE_MED && GameControl.handle.player.arcadeScore >= ARCADESCORE_EASY)
        {
            badges_description_6_2.text = thisLanguageManager.GetTextValue("badges_description_6_2");
        }
        else if (GameControl.handle.player.arcadeScore < ARCADESCORE_HIGH && GameControl.handle.player.arcadeScore >= ARCADESCORE_MED)
        {
            badges_description_6_3.text = thisLanguageManager.GetTextValue("badges_description_6_3");
        }
        else
        {
            badges_description_final[5].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        badges_description_7.text = thisLanguageManager.GetTextValue("badges_description_7");
        if (GameControl.handle.player.percentOfItemsUnlocked < SHOPPERCENT_EASY)
        {
        badges_description_7_1.text = thisLanguageManager.GetTextValue("badges_description_7_1");
        }
        else if (GameControl.handle.player.percentOfItemsUnlocked < SHOPPERCENT_MED && GameControl.handle.player.percentOfItemsUnlocked >= SHOPPERCENT_EASY)
        {
        badges_description_7_2.text = thisLanguageManager.GetTextValue("badges_description7_2");
        }
        else if (GameControl.handle.player.percentOfItemsUnlocked < SHOPPERCENT_HIGH && GameControl.handle.player.percentOfItemsUnlocked >= SHOPPERCENT_MED)
        {
            badges_description_7_3.text = thisLanguageManager.GetTextValue("badges_description_7_3");
        }
        else
        {
            badges_description_final[6].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        badges_description_8.text = thisLanguageManager.GetTextValue("badges_description_8");
        if (GameControl.handle.player.numberOfStagesAllCorrect < STAGEALLCORRECT_EASY)
        {
            badges_description_8_1.text = thisLanguageManager.GetTextValue("badges_description_8_1");
        }
        else if (GameControl.handle.player.numberOfStagesAllCorrect < STAGEALLCORRECT_MED && GameControl.handle.player.numberOfStagesAllCorrect >= STAGEALLCORRECT_EASY)
        {
            badges_description_8_2.text = thisLanguageManager.GetTextValue("badges_description_8_2");
        }
        else if (GameControl.handle.player.numberOfStagesAllCorrect < STAGEALLCORRECT_HIGH && GameControl.handle.player.numberOfStagesAllCorrect >= STAGEALLCORRECT_MED)
        {
            badges_description_8_3.text = thisLanguageManager.GetTextValue("badges_description_8_3");
        }
        else
        {
            badges_description_final[7].text = thisLanguageManager.GetTextValue("badges_description_final");
        }
        #endregion
        #region mainmenu
        PlayGame.text = thisLanguageManager.GetTextValue("PlayGame");
        message_1.text = thisLanguageManager.GetTextValue("Message_1");
        message_2.text = thisLanguageManager.GetTextValue("Message_2");
        message_3.text = thisLanguageManager.GetTextValue("Message_3");
        for (int i = 0; i < 5; i++)
        {
            float temp_total = GameControl.handle.Modes[0].Categories[i].gettotalNoStage_Cat() * 10;
            float tried = GameControl.handle.Modes[0].Categories[i].getCorrectCount();

            progress += (int)(tried / temp_total * 100.0f);
        }
        message_4.text = thisLanguageManager.GetTextValue("Message_4") + (progress / 5.0f).ToString("F0") + " %";
        People_Organization.text = thisLanguageManager.GetTextValue("People & Organization");
        Production_Delivery.text = thisLanguageManager.GetTextValue("Production & Delivery");
        Product_Production_Process_Development.text = thisLanguageManager.GetTextValue("Product & Production Process Development");
        Management_Support_Process.text = thisLanguageManager.GetTextValue("Management & Support Process");
        Supplier_Management.text = thisLanguageManager.GetTextValue("Supplier Management");
        Go.text = thisLanguageManager.GetTextValue("go");
        stage.text = thisLanguageManager.GetTextValue("stage");

        #endregion
        #region shop
       prop_city.text = thisLanguageManager.GetTextValue("Prop(city)");
       prop_winter.text = thisLanguageManager.GetTextValue("Prop(winter)");
       prop_desert.text = thisLanguageManager.GetTextValue("Prop(desert)");
       
       prop_agave.text = thisLanguageManager.GetTextValue("prop_agave");
       prop_bench.text = thisLanguageManager.GetTextValue("prop_bench");
       prop_bicycle.text = thisLanguageManager.GetTextValue("prop_bicycle");
       prop_billboard.text = thisLanguageManager.GetTextValue("prop_billboard");
       prop_bud.text = thisLanguageManager.GetTextValue("prop_bud");
       prop_busstop.text = thisLanguageManager.GetTextValue("prop_busstop");
       prop_cactus.text = thisLanguageManager.GetTextValue("prop_cactus");
       prop_cone.text = thisLanguageManager.GetTextValue("prop_cone");
       prop_fence.text = thisLanguageManager.GetTextValue("prop_fence");
       prop_firehydrant.text = thisLanguageManager.GetTextValue("prop_firehydrant");
       prop_grass.text = thisLanguageManager.GetTextValue("prop_grass");
       prop_mailbox.text = thisLanguageManager.GetTextValue("prop_mailbox");
       prop_palmtree.text = thisLanguageManager.GetTextValue("prop_palmtree");
       prop_pinetree.text = thisLanguageManager.GetTextValue("prop_pinetree");
       prop_pole.text = thisLanguageManager.GetTextValue("prop_pole");
       prop_roadblock1.text = thisLanguageManager.GetTextValue("prop_roadblock1");
       prop_roadblock2.text = thisLanguageManager.GetTextValue("prop_roadblock2");
       prop_rock.text = thisLanguageManager.GetTextValue("prop_rock");
       prop_sign1.text = thisLanguageManager.GetTextValue("prop_sign1");
       prop_sign2.text = thisLanguageManager.GetTextValue("prop_sign2");
       prop_sign3.text = thisLanguageManager.GetTextValue("prop_sign3");
       prop_sign4.text = thisLanguageManager.GetTextValue("prop_sign4");
       prop_speedcamera.text = thisLanguageManager.GetTextValue("prop_speedcamera");
       prop_snowman.text = thisLanguageManager.GetTextValue("prop_snowman");
       prop_streetlamp.text = thisLanguageManager.GetTextValue("prop_streetlamp");
       prop_trafficlight.text = thisLanguageManager.GetTextValue("prop_trafficlight");
       prop_trashbin.text = thisLanguageManager.GetTextValue("prop_trashbin");
       prop_tree.text = thisLanguageManager.GetTextValue("prop_tree");
       prop_tumbleweed.text = thisLanguageManager.GetTextValue("prop_tumbleweed");
       prop_utilitypole.text = thisLanguageManager.GetTextValue("prop_utilitypole");
       prop_utilitypole_lamp.text = thisLanguageManager.GetTextValue("prop_utilitypole_lamp");
       prop_yucca.text = thisLanguageManager.GetTextValue("prop_yucca");
       prop_electricitybox.text = thisLanguageManager.GetTextValue("prop_electricitybox");
       prop_streetlamp2.text = thisLanguageManager.GetTextValue("prop_streetlamp2");
       prop_streetlamp3.text = thisLanguageManager.GetTextValue("prop_streetlamp3");
       prop_streetlamp4.text = thisLanguageManager.GetTextValue("prop_streetlamp4");
       prop_streetsign.text = thisLanguageManager.GetTextValue("prop_streetsign");
       prop_telephonebooth.text = thisLanguageManager.GetTextValue("prop_telephonebooth");
       prop_trafficlight2.text = thisLanguageManager.GetTextValue("prop_trafficlight2");
       gender_male.text = thisLanguageManager.GetTextValue("gender_male");
       gender_female.text = thisLanguageManager.GetTextValue("gender_female");
       gender.text = thisLanguageManager.GetTextValue("gender");
       car.text = thisLanguageManager.GetTextValue("Car");
       car_coupe.text = thisLanguageManager.GetTextValue("Coupe");
       car_sedan.text = thisLanguageManager.GetTextValue("Sedan");
       car_SUV.text = thisLanguageManager.GetTextValue("SUV");
       Enviroment_City.text = thisLanguageManager.GetTextValue("city");
       Enviroment_Desert.text = thisLanguageManager.GetTextValue("desert");
       Enviroment_Winter.text = thisLanguageManager.GetTextValue("winter");
       Enviroment.text = thisLanguageManager.GetTextValue("Enviroment");
       tabs_gender.text = thisLanguageManager.GetTextValue("gender");
       tabs_car.text = thisLanguageManager.GetTextValue("Car");
       tabs_environment.text = thisLanguageManager.GetTextValue("Enviroment");
       tabs_props.text = thisLanguageManager.GetTextValue("prop");
       Select.text = thisLanguageManager.GetTextValue("select");
       Close.text = thisLanguageManager.GetTextValue("close");
       social_score.text = thisLanguageManager.GetTextValue("social_score");
        #endregion
        #region statistics
       statistics_correct.text = thisLanguageManager.GetTextValue("statistics_correct");
       statistics_wrong.text = thisLanguageManager.GetTextValue("statistics_wrong");
       statistics_winstreak.text = thisLanguageManager.GetTextValue("statistics_winstreak");
       statistics_losestreak.text = thisLanguageManager.GetTextValue("statistics_losestreak");
       statistics_highestscore.text = thisLanguageManager.GetTextValue("statistics_highestscore");
       statistics_highestearning.text = thisLanguageManager.GetTextValue("statistics_highestearning");
       statistics_totalplaytime.text = thisLanguageManager.GetTextValue("statistics_totalplaytime");
    #endregion
        #region ingame
       results.text = thisLanguageManager.GetTextValue("results");
       earnings.text = thisLanguageManager.GetTextValue("earnings");
       conticoins.text = thisLanguageManager.GetTextValue("conticoins");
       score.text = thisLanguageManager.GetTextValue("score");
       instruction.text = thisLanguageManager.GetTextValue("instruction");
       correct.text = thisLanguageManager.GetTextValue("correct");
       taptocontinue.text = thisLanguageManager.GetTextValue("taptocontinue");
       sentence[0].text = thisLanguageManager.GetTextValue("sentence_1");
       sentence[1].text = thisLanguageManager.GetTextValue("sentence_2");
       sentence[2].text = thisLanguageManager.GetTextValue("sentence_3");    
       PlayerPrefs.SetString("results", results.text);
       PlayerPrefs.SetString("earnings", earnings.text);
       PlayerPrefs.SetString("conticoins", conticoins.text);
       PlayerPrefs.SetString("score", score.text);
       PlayerPrefs.SetString("correct", correct.text);
       PlayerPrefs.SetString("instruction", instruction.text);
       PlayerPrefs.SetString("taptocontinue", taptocontinue.text);
       PlayerPrefs.SetString("sentence1", sentence[0].text);
       PlayerPrefs.SetString("sentence2", sentence[1].text);
       PlayerPrefs.SetString("sentence3", sentence[2].text);
        #endregion
       
    }
    void OnGUI()
    {
        
       
      
        /*
        if(GUILayout.Button("English"))
        {
            LanguageManager.Instance.ChangeLanguage("en");
        }
        if (GUILayout.Button("German"))
        {
            LanguageManager.Instance.ChangeLanguage("de-DE");
        }*/

    }
    public void isEnglish()
    {
        Debug.Log("english");
        LanguageManager.Instance.ChangeLanguage("en");
        langauage_num = 0;
        PlayerPrefs.SetString("language", english);
        statistics.GetComponent<Statistics>().changeCat();
    }
    public void isGerman()
    {
        Debug.Log("german");
        LanguageManager.Instance.ChangeLanguage("de-DE");
        langauage_num = 1;
        PlayerPrefs.SetString("language", german);
        statistics.GetComponent<Statistics>().changeCat();
    }
}
