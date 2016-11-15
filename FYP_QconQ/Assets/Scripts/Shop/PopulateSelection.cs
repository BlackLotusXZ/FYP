using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulateSelection : MonoBehaviour
{
    public GameObject Content;
    public GameObject PrefabButton;
    public GameObject ShowCasePreview;
    public RawImage Display;
    public bool isClearPlayerPref;
    public GameObject smartlocalize;
    //Mainly for badges
    public float totalNoOfItems, totalUnlocked, percentOfItemsUnlocked;
    //public float percentOfItemsUnlocked;

    // Use this for initialization
    void Start()
    {
        if (isClearPlayerPref == true)
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {
            //If first time dont load
            if (!PlayerPrefs.HasKey("FirstTime"))
            {
                Debug.Log("Delete All");
                PlayerPrefs.DeleteAll();
                SaveContent();
            }
            //else load
            else
            {
                Debug.Log("content loaded");
                LoadContent();
                //PlayerPrefs.DeleteAll();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateItemNumbers();
    }
    
    public void ReloadContent(int type)
    {
        //Remove Whatever Crap There Is In The ContentHolder
        foreach (Transform Child in Content.transform)
        {
            Destroy(Child.gameObject);
        }

        foreach (Transform Category in ShowCasePreview.transform)
        {
            if (Category.GetComponent<ItemInfo>().type == (ItemInfo.ShowCase)type)
            {
                //Repopulate ContentHolder
                foreach (Transform Child in Category.transform)
                {
                    // clone the button and position properly
                    GameObject clone = Instantiate(PrefabButton) as GameObject;
                   
                    //Assign Clone With ShowCaseItemCategoryChild's Name
                    clone.GetComponent<ItemInfo>().name = (Child.transform.name);

                    //Assign Clone With ShowCaseItemCategoryChild's Sprite
                    clone.GetComponent<Image>().sprite = Child.GetComponent<ItemInfo>().Icon;

                    //Assign Clone's ItemInfo Sprite With Child's ItemInfo's Sprite
                    clone.GetComponent<ItemInfo>().Icon = Child.GetComponent<ItemInfo>().Icon;

                    //Assign Clone's ItemInfo type with Child's ItemInfo's type
                    clone.GetComponent<ItemInfo>().type = Child.GetComponent<ItemInfo>().type;

                    //Assign ContentHodler As Clone's Parent
                    clone.transform.SetParent(Content.transform);

                    //Set Scale To Uniform 1 to Ease Calculation
                    clone.transform.localScale = new Vector3(1, 1, 1);

                    //Set Rotate -90 if LandScape
                    if (GameObject.Find("OrientationController").GetComponent<OrientationControl>().isLandScape == true)
                    {
                        clone.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                 
                    if (Child.GetComponent<ItemInfo>().Selected == true)
                    {
                        clone.GetComponent<Image>().color = new Color(clone.GetComponent<Image>().color.r, clone.GetComponent<Image>().color.g, clone.GetComponent<Image>().color.b, 0.5f);
                    }

                    //Activate Clone
                    clone.SetActive(true);

                    //Set Function Call When clone's OnClick Triggered
                    clone.GetComponent<Button>().onClick.AddListener(() => ItemTapped(clone));

                    clone.GetComponent<Button>().onClick.AddListener(() => Display.GetComponent<DisplayControl>().ExpandDisplay());
                    clone.GetComponent<Button>().onClick.AddListener(() => Display.GetComponent<DisplayControl>().FadeOut());
                }
            }
        }
      
    }

    void ItemTapped(GameObject Clone)
    {
        //Loop Through ShowCasePreview
        foreach (Transform Child in ShowCasePreview.transform)
        {
            //Search For The Item's Category
            if (Child.GetComponent<ItemInfo>().type == Clone.GetComponent<ItemInfo>().type)
            {
                //Loop Through The Item's Category
                foreach (Transform item in Child.transform)
                {
                    //If Item Is The One That We Are Looking For
                    if (item.name == Clone.GetComponent<ItemInfo>().name)
                    {
                        //This Is Where All The Work Is Being Done
                        string temp_tag = "";
                        string temp_name = "";
                        //Set Item's Active To True
                        item.gameObject.SetActive(true);
                        if(item.tag == "Prop(City)")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().prop_city.text;
                            #region city
                            if (item.name == "Grass")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_grass.text;
                            }
                            else if (item.name == "Trash Bin")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_trashbin.text;
                            }
                            else if (item.name == "Road Block1")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_roadblock1.text;
                            }
                            else if (item.name == "Road Block2")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_roadblock2.text;
                            }
                            else if (item.name == "Pole")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_pole.text;
                            }
                            else if (item.name == "Cone")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_cone.text;
                            }
                            else if (item.name == "Sign1")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_sign1.text;
                            }
                            else if (item.name == "Sign2")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_sign2.text;
                            }
                            else if (item.name == "Sign3")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_sign3.text;
                            }
                            else if (item.name == "Sign4")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_sign4.text;
                            }
                            else if (item.name == "Tree")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_tree.text;
                            }
                            else if (item.name == "FireHydrant")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_firehydrant.text;
                            }
                            else if (item.name == "Utility Pole")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_utilitypole.text;
                            }
                            else if (item.name == "Utility Pole_Lamp")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_utilitypole_lamp.text;
                            }
                            else if (item.name == "Bench")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_bench.text;
                            }
                            else if (item.name == "Bus Stop")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_busstop.text;
                            }
                            else if (item.name == "Bicycle")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_bicycle.text;
                            }
                            else if (item.name == "Billboard")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_billboard.text;
                            }
                            else if (item.name == "Mailbox")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_mailbox.text;
                            }
                            else if (item.name == "Speed Camera")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_speedcamera.text;
                            }
                            else if (item.name == "Street Lamp")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_streetlamp.text;
                            }
                            else if (item.name == "Traffic Light")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_trafficlight.text;
                            }
                            else if (item.name == "Electricity box")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_electricitybox.text;
                            }
                            else if (item.name == "Street lamp 2")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_streetlamp2.text;
                            }
                            else if (item.name == "Street lamp 3")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_streetlamp3.text;
                            }
                            else if (item.name == "Street lamp 4")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_streetlamp4.text;
                            }
                            else if (item.name == "Street sign")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_streetsign.text;
                            }
                            else if (item.name == "telephone booth")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_telephonebooth.text;
                            }
                            else if (item.name == "trafficlight2")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_trafficlight2.text;
                            }
                            #endregion
                        }
                        else if (item.tag == "Prop(Winter)")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().prop_winter.text;
                            #region winter
                            if (item.name == "Snowman")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_snowman.text;
                            }
                            else if (item.name == "PineTree")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_pinetree.text;
                            }
                            else if (item.name == "Fence End")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_fence.text;
                            }
                            #endregion
                        }
                        else if (item.tag == "Prop(Desert)")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().prop_desert.text;
                            #region desert
                            if (item.name == "Tumble Weed")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_tumbleweed.text;
                            }
                            else if (item.name == "Agave")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_agave.text;
                            }
                            else if (item.name == "Yucca")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_yucca.text;
                            }
                            else if (item.name == "Bud")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_bud.text;
                            }
                            else if (item.name == "Cactus")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_cactus.text;
                            }
                            else if (item.name == "Palm Tree")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_palmtree.text;
                            }
                            else if (item.name == "Rock")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().prop_rock.text;
                            }
#endregion
                        }
                        else if (item.tag == "Gender")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().gender.text;
                            #region avatar
                            if (item.name == "Male Avatar")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().gender_male.text;
                            }
                            else
                                temp_name = smartlocalize.GetComponent<SmartLocal>().gender_female.text;
                            #endregion

                        }
                        else if(item.tag == "Car")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().car.text;
                            #region car
                            if(item.name == "SUV")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().car_SUV.text;
                            }
                            else if (item.name == "Sedan")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().car_sedan.text;
                            }
                            else if (item.name == "Coupe")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().car_coupe.text;
                            }
#endregion
                        }
                        else if (item.tag == "Environment")
                        {
                            temp_tag = smartlocalize.GetComponent<SmartLocal>().Enviroment.text;
                            if (item.name == "City Base")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().Enviroment_City.text;
                            }
                            else if (item.name == "Desert Base")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().Enviroment_Desert.text;
                            }
                            else if (item.name == "Winter Base")
                            {
                                temp_name = smartlocalize.GetComponent<SmartLocal>().Enviroment_Winter.text;
                            }
                        }
                        //Set Display's Name To Item's Name

                        Display.GetComponent<DisplayControl>().DisplayItemInfo(temp_tag, temp_name, item.GetComponent<ItemInfo>().Price);
                        //If Item Is Not Locked
                        if (item.GetComponent<ItemInfo>().Locked == false)
                        {
                            Display.GetComponent<DisplayControl>().UnlockDisplay();
                            Display.GetComponent<DisplayControl>().EnableSelect();
                        }
                        //If Item Is Locked
                        else
                        {
                            Display.GetComponent<DisplayControl>().LockDisplay();
                            Display.GetComponent<DisplayControl>().DisableSelect();
                        }
                    }
                    else
                    {
                        //Set Item's Active To False
                        item.gameObject.SetActive(false);
                    }
                }
            }
            else 
            {
                //Loop Through The Item's Category
                foreach (Transform item in Child.transform)
                {
                    //Set All Objects Active To False
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

    public void EditGridLayoutRow(int NumberOfRow)
    {
        Content.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedRowCount;
        Content.GetComponent<GridLayoutGroup>().constraintCount = NumberOfRow;
    }

    public void EditGridLayoutColumn(int NumberOfColumn)
    {
        Content.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        Content.GetComponent<GridLayoutGroup>().constraintCount = NumberOfColumn;
    }

    public void EditCellSizeX(int CellSizeX)
    {
        Content.GetComponent<GridLayoutGroup>().cellSize = new Vector2(CellSizeX, Content.GetComponent<GridLayoutGroup>().cellSize.y);
    }

    public void EditCellSizeY(int CellSizeY)
    {
        Content.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Content.GetComponent<GridLayoutGroup>().cellSize.x, CellSizeY);
    }

    public void SaveContent()
    {
        PlayerPrefs.SetInt("FirstTime",0);
        Debug.Log(" Shop Items' Information Saved! :D");

        string SelectedKey = "";
        string LockedKey = "";

        //Loop Through Categories in ShowCasePreview
        foreach(Transform Category in ShowCasePreview.transform)
        {
            //Check Category Type & Set PlayerPrefKey
            switch (Category.GetComponent<ItemInfo>().type)
            {
                case ItemInfo.ShowCase.Gender:
                    {
                        SelectedKey = "GenderS ";
                        LockedKey = "GenderL ";
                        break;
                    }
                case ItemInfo.ShowCase.Car:
                    {
                        SelectedKey = "CarS ";
                        LockedKey = "CarL ";
                        break;
                    }
                case ItemInfo.ShowCase.Environment:
                    {
                        SelectedKey = "EnvironmentS ";
                        LockedKey = "EnvironmentL ";
                        break;
                    }
                case ItemInfo.ShowCase.Props:
                    {
                        SelectedKey = "PropsS ";
                        LockedKey = "PropsL ";
                        break;
                    }
            }

            foreach (Transform Child in Category)
            {
                //Check Child's Current Variables & Set PlayerPref's String As: Category + Child's ID

                if (Child.GetComponent<ItemInfo>().Selected == true)
                {
                    Debug.Log("***"+ Child.name);
                    PlayerPrefs.SetInt(SelectedKey + Child.name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(SelectedKey + Child.name, 0);
                }

                if (Child.GetComponent<ItemInfo>().Locked == true)
                {
                    PlayerPrefs.SetInt(LockedKey + Child.name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(LockedKey + Child.name, 0);
                }
            }
           
        }
    }

    public void LoadContent()
    {
        Debug.Log("Shop Items' Information Loaded :D");
        string SelectedKey = "";
        string LockedKey = "";

        foreach (Transform Category in ShowCasePreview.transform)
        {
             switch (Category.GetComponent<ItemInfo>().type)
            {
                case ItemInfo.ShowCase.Gender:
                    {
                        SelectedKey = "GenderS ";
                        LockedKey = "GenderL ";
                        break;
                    }
                case ItemInfo.ShowCase.Car:
                    {
                        SelectedKey = "CarS ";
                        LockedKey = "CarL ";
                        break;
                    }
                case ItemInfo.ShowCase.Environment:
                    {
                        SelectedKey = "EnvironmentS ";
                        LockedKey = "EnvironmentL ";
                        break;
                    }
                case ItemInfo.ShowCase.Props:
                    {
                        SelectedKey = "PropsS ";
                        LockedKey = "PropsL ";
                        break;
                    }
            }

            foreach(Transform Child in Category)
            {
                //Load PlayerPref For Select 
                if(PlayerPrefs.GetInt(SelectedKey + Child.name) == 1)
                {
                    Child.GetComponent<ItemInfo>().Selected = true;
                }
                else
                {
                    Child.GetComponent<ItemInfo>().Selected = false;
                }
                //Load PlayerPref For Locked
                if (PlayerPrefs.GetInt(LockedKey + Child.name) == 1)
                {
                    Child.GetComponent<ItemInfo>().Locked = true;
                }
                else
                {
                    Child.GetComponent<ItemInfo>().Locked = false;
                }
            }
        }
    }

    public void EvaluateItemNumbers()
    {
        totalNoOfItems = totalUnlocked = percentOfItemsUnlocked = 0;
        
        //Loop for each category
        foreach (Transform Category in ShowCasePreview.transform)
        {
            //Children in each category
            foreach (Transform Child in Category)
            {
                totalNoOfItems++;
                if (!Child.GetComponent<ItemInfo>().Locked)
                {
                    totalUnlocked++;
                }
            }
        }

        percentOfItemsUnlocked = totalUnlocked / totalNoOfItems * 100;
        GameControl.handle.player.percentOfItemsUnlocked = percentOfItemsUnlocked;
    }
}
