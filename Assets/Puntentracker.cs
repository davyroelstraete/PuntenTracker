using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingData
{
    public string toestel;
    public System.DateTime tijdstip;
    public int duur;
    public float punten;

    public TrainingData(string _toestel, int _duur)
    {
        toestel = _toestel;
        tijdstip = System.DateTime.Now;
        duur = _duur;
        switch (toestel)
        {
            case "crosstrainer":
                punten = duur * Puntentracker.CROSSTRAINER * 0.1f;
                break;
            case "fiets":
                punten = duur * Puntentracker.FIETS *0.1f;
                break;
            case "lopen":
                punten = duur * Puntentracker.LOPEN * 0.1f;
                break;
            case "roeien":
                punten = duur * Puntentracker.ROEIEN * 0.1f;
                break;
            case "wandelen":
                punten = duur * Puntentracker.WANDELEN * 0.1f;
                break;
            case "groepsles":
                punten = duur * Puntentracker.GROEPSLES * 0.1f;
                break;
        }
    }
    public TrainingData(string _toestel, System.DateTime _tijdstip, int _duur, float _punten)
    {
        toestel = _toestel;
        tijdstip = _tijdstip;
        duur = _duur;
        punten = _punten;
    }
    public override string ToString()
    {
        return (toestel + "," + tijdstip.ToString() + "," + duur.ToString() + "," + punten.ToString() + ";");
    }
}

public class Puntentracker : MonoBehaviour
{
    #region datamembers
    //CONSTANTS
    public const float CROSSTRAINER = 2.2f;
    public const float FIETS = 2.0f;
    public const float LOPEN = 2.4f;
    public const float ROEIEN = 2.2f;
    public const float WANDELEN = 1.6f;
    public const float GROEPSLES = 2.4f;

    //general schedule datamembers
    private System.DateTime week1Startdate = System.DateTime.MinValue;
    private System.DateTime week2Startdate = System.DateTime.MinValue;
    private System.DateTime week3Startdate = System.DateTime.MinValue;
    private System.DateTime week4Startdate = System.DateTime.MinValue;
    private System.DateTime week5Startdate = System.DateTime.MinValue;
    private System.DateTime week6Startdate = System.DateTime.MinValue;
    private System.DateTime week7Startdate = System.DateTime.MinValue;
    private System.DateTime week8Startdate = System.DateTime.MinValue;
    private System.DateTime week9Startdate = System.DateTime.MinValue;
    private System.DateTime week10Startdate = System.DateTime.MinValue;

    private float week1goal;
    private float week2goal;
    private float week3goal;
    private float week4goal;
    private float week5goal;
    private float week6goal;
    private float week7goal;
    private float week8goal;
    private float week9goal;
    private float week10goal;

    private float week1score;
    private float week2score;
    private float week3score;
    private float week4score;
    private float week5score;
    private float week6score;
    private float week7score;
    private float week8score;
    private float week9score;
    private float week10score;

    private string trainingDataString1;
    private List<TrainingData> trainingData1;
    private string trainingDataString2;
    private List<TrainingData> trainingData2;
    private string trainingDataString3;
    private List<TrainingData> trainingData3;
    private string trainingDataString4;
    private List<TrainingData> trainingData4;
    private string trainingDataString5;
    private List<TrainingData> trainingData5;
    private string trainingDataString6;
    private List<TrainingData> trainingData6;
    private string trainingDataString7;
    private List<TrainingData> trainingData7;
    private string trainingDataString8;
    private List<TrainingData> trainingData8;
    private string trainingDataString9;
    private List<TrainingData> trainingData9;
    private string trainingDataString10;
    private List<TrainingData> trainingData10;




    //Main panels
    [Header ("Main panels")]
    public GameObject panelSchema;
    public GameObject panelTrainen;
    public GameObject panelOverzicht;
    [Space(5)]

    //Schema panel elements
    [Header("Schema weekpanels")]
    public GameObject panelSchemaWeek1;
    public GameObject panelSchemaWeek2;
    public GameObject panelSchemaWeek3;
    public GameObject panelSchemaWeek4;
    public GameObject panelSchemaWeek5;
    public GameObject panelSchemaWeek6;
    public GameObject panelSchemaWeek7;
    public GameObject panelSchemaWeek8;
    public GameObject panelSchemaWeek9;
    public GameObject panelSchemaWeek10;
    private System.DateTime currentStartingDate = System.DateTime.MinValue;
    [Space(5)]


    //Training panel elements
    [Header("Training elements")]
    public Text textDuration;
    private int currentDuration = 10;
    [Space(5)]

    //overzicht elements
    [Header("Overzicht progressbars")]
    public GameObject progressbar1;
    public GameObject progressbar2;
    public GameObject progressbar3;
    public GameObject progressbar4;
    public GameObject progressbar5;
    public GameObject progressbar6;
    public GameObject progressbar7;
    public GameObject progressbar8;
    public GameObject progressbar9;
    public GameObject progressbar10;
    #endregion


    public void Start()
    {
        LoadScheme();
        ResetAllPlayerprefs();
        LoadOverzicht();
    }

    #region Main panels
    public void ShowSchema()
    {
        panelTrainen.SetActive(false);
        panelOverzicht.SetActive(false);
        panelSchema.SetActive(true);
    }

    public void ShowTrainen()
    {
        panelTrainen.SetActive(true);
        panelOverzicht.SetActive(false);
        panelSchema.SetActive(false);
    }

    public void ShowOverzicht()
    {
        LoadOverzicht();
        panelTrainen.SetActive(false);
        panelOverzicht.SetActive(true);
        panelSchema.SetActive(false);
    }
    #endregion



    #region Schema elements
    private void LoadScheme()
    {
        if (PlayerPrefs.GetInt("GotData") > 0)
        {
            week1Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week1Startdate"));
            week2Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week2Startdate"));
            week3Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week3Startdate"));
            week4Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week4Startdate"));
            week5Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week5Startdate"));
            week6Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week6Startdate"));
            week7Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week7Startdate"));
            week8Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week8Startdate"));
            week9Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week9Startdate"));
            week10Startdate = System.DateTime.Parse(PlayerPrefs.GetString("Week10Startdate"));
            SetupTrainingDates(week1Startdate);

            panelSchemaWeek1.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week1Goal").ToString();
            panelSchemaWeek2.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week2Goal").ToString();
            panelSchemaWeek3.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week3Goal").ToString();
            panelSchemaWeek4.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week4Goal").ToString();
            panelSchemaWeek5.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week5Goal").ToString();
            panelSchemaWeek6.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week6Goal").ToString();
            panelSchemaWeek7.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week7Goal").ToString();
            panelSchemaWeek8.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week8Goal").ToString();
            panelSchemaWeek9.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week9Goal").ToString();
            panelSchemaWeek10.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt("Week10Goal").ToString();

            week1goal = PlayerPrefs.GetInt("Week1Goal");
            week2goal = PlayerPrefs.GetInt("Week2Goal");
            week3goal = PlayerPrefs.GetInt("Week3Goal");
            week4goal = PlayerPrefs.GetInt("Week4Goal");
            week5goal = PlayerPrefs.GetInt("Week5Goal");
            week6goal = PlayerPrefs.GetInt("Week6Goal");
            week7goal = PlayerPrefs.GetInt("Week7Goal");
            week8goal = PlayerPrefs.GetInt("Week8Goal");
            week9goal = PlayerPrefs.GetInt("Week9Goal");
            week10goal = PlayerPrefs.GetInt("Week10Goal");
        }
    }

    private void SetupTrainingDates(System.DateTime _date)
    {
        currentStartingDate = _date;
        panelSchemaWeek1.GetComponentInChildren<Text>().text = "Week 1: van " + _date.ToString("dd/MM/yyyy") + " tot " + _date.AddDays(6).ToString("dd/MM/yyyy");
        panelSchemaWeek2.GetComponentInChildren<Text>().text = "Week 2: van " + _date.AddDays(7).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(13).ToString("dd/MM/yyyy");
        panelSchemaWeek3.GetComponentInChildren<Text>().text = "Week 3: van " + _date.AddDays(14).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(20).ToString("dd/MM/yyyy");
        panelSchemaWeek4.GetComponentInChildren<Text>().text = "Week 4: van " + _date.AddDays(21).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(27).ToString("dd/MM/yyyy");
        panelSchemaWeek5.GetComponentInChildren<Text>().text = "Week 5: van " + _date.AddDays(28).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(34).ToString("dd/MM/yyyy");
        panelSchemaWeek6.GetComponentInChildren<Text>().text = "Week 6: van " + _date.AddDays(35).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(41).ToString("dd/MM/yyyy");
        panelSchemaWeek7.GetComponentInChildren<Text>().text = "Week 7: van " + _date.AddDays(42).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(48).ToString("dd/MM/yyyy");
        panelSchemaWeek8.GetComponentInChildren<Text>().text = "Week 8: van " + _date.AddDays(49).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(55).ToString("dd/MM/yyyy");
        panelSchemaWeek9.GetComponentInChildren<Text>().text = "Week 9: van " + _date.AddDays(56).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(62).ToString("dd/MM/yyyy");
        panelSchemaWeek10.GetComponentInChildren<Text>().text = "Week 10: van " + _date.AddDays(63).ToString("dd/MM/yyyy") + " tot " + _date.AddDays(69).ToString("dd/MM/yyyy");
    }

    public void StartNewTrainingSchedule()
    {
        SetupTrainingDates(System.DateTime.Today);
    }

    public void DayLater()
    {
        SetupTrainingDates(currentStartingDate.AddDays(1));
    }
    public void DayEarlier()
    {
        SetupTrainingDates(currentStartingDate.AddDays(-1));
    }

    private bool SchemaSetupCheck()
    {
        bool ret = true;

        //was a training schema initiated?
        if (currentStartingDate == System.DateTime.MinValue) ret = false;

        //Check for empty fields
        if (panelSchemaWeek1.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek2.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek3.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek4.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek5.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek6.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek7.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek8.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek9.GetComponentInChildren<InputField>().text == "") ret = false;
        else if (panelSchemaWeek10.GetComponentInChildren<InputField>().text == "") ret = false;

        //check if one of the inputs is not a number
        try
        {
            int.Parse(panelSchemaWeek1.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek2.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek3.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek4.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek5.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek6.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek7.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek8.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek9.GetComponentInChildren<InputField>().text);
            int.Parse(panelSchemaWeek10.GetComponentInChildren<InputField>().text);
        }
        catch
        {
            ret = false;
        }

        return ret;
    }

    public void SaveSchema()
    {
        if (SchemaSetupCheck())
        {
            PlayerPrefs.SetInt("GotData", 1);

            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetString("Week" + i.ToString() + "Startdate", currentStartingDate.AddDays((i - 1) * 7).ToString());
            }

            PlayerPrefs.SetInt("Week1Goal", int.Parse(panelSchemaWeek1.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week2Goal", int.Parse(panelSchemaWeek2.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week3Goal", int.Parse(panelSchemaWeek3.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week4Goal", int.Parse(panelSchemaWeek4.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week5Goal", int.Parse(panelSchemaWeek5.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week6Goal", int.Parse(panelSchemaWeek6.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week7Goal", int.Parse(panelSchemaWeek7.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week8Goal", int.Parse(panelSchemaWeek8.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week9Goal", int.Parse(panelSchemaWeek9.GetComponentInChildren<InputField>().text));
            PlayerPrefs.SetInt("Week10Goal", int.Parse(panelSchemaWeek10.GetComponentInChildren<InputField>().text));
        }
    }
    #endregion



    #region Training
    public void ResetAllPlayerprefs()
    {
        PlayerPrefs.SetString("trainingData1", "");
        PlayerPrefs.SetString("trainingData2", "");
        PlayerPrefs.SetString("trainingData3", "");
        PlayerPrefs.SetString("trainingData4", "");
        PlayerPrefs.SetString("trainingData5", "");
        PlayerPrefs.SetString("trainingData6", "");
        PlayerPrefs.SetString("trainingData7", "");
        PlayerPrefs.SetString("trainingData8", "");
        PlayerPrefs.SetString("trainingData9", "");
        PlayerPrefs.SetString("trainingData10", "");
    }
    public void ClearAllTraining()
    {
        trainingData1.Clear();
        trainingData2.Clear();
        trainingData3.Clear();
        trainingData4.Clear();
        trainingData5.Clear();
        trainingData6.Clear();
        trainingData7.Clear();
        trainingData8.Clear();
        trainingData9.Clear();
        trainingData10.Clear();
        WriteTrainingDataString();
        LoadOverzicht();
    }
    public void UndoLastTraining()
    {
        bool removedSomething = false;

        if (trainingData10.Count > 0)
        {
            trainingData10.RemoveAt(trainingData10.Count - 1);
            removedSomething = true;
        }
        else if (trainingData9.Count > 0)
        {
            trainingData9.RemoveAt(trainingData9.Count - 1);
            removedSomething = true;
        }
        else if (trainingData8.Count > 0)
        {
            trainingData8.RemoveAt(trainingData8.Count - 1);
            removedSomething = true;
        }
        else if (trainingData7.Count > 0)
        {
            trainingData7.RemoveAt(trainingData7.Count - 1);
            removedSomething = true;
        }
        else if (trainingData6.Count > 0)
        {
            trainingData6.RemoveAt(trainingData6.Count - 1);
            removedSomething = true;
        }
        else if (trainingData5.Count > 0)
        {
            trainingData5.RemoveAt(trainingData5.Count - 1);
            removedSomething = true;
        }
        else if (trainingData4.Count > 0)
        {
            trainingData4.RemoveAt(trainingData4.Count - 1);
            removedSomething = true;
        }
        else if (trainingData3.Count > 0)
        {
            trainingData3.RemoveAt(trainingData3.Count - 1);
            removedSomething = true;
        }
        else if (trainingData2.Count > 0)
        {
            trainingData2.RemoveAt(trainingData2.Count - 1);
            removedSomething = true;
        }
        else if (trainingData1.Count > 0)
        {
            trainingData1.RemoveAt(trainingData1.Count - 1);
            removedSomething = true;
        }

        if (removedSomething)
        {
            WriteTrainingDataString();
            LoadOverzicht();
        }
    }
    private void WriteTrainingDataString()
    {
        trainingDataString1 = "";
        foreach (TrainingData t in trainingData1)
        {
            trainingDataString1 += t.ToString();
        }
        trainingDataString2 = "";
        foreach (TrainingData t in trainingData2)
        {
            trainingDataString2 += t.ToString();
        }
        trainingDataString3 = "";
        foreach (TrainingData t in trainingData3)
        {
            trainingDataString3 += t.ToString();
        }
        trainingDataString4 = "";
        foreach (TrainingData t in trainingData4)
        {
            trainingDataString4 += t.ToString();
        }
        trainingDataString5 = "";
        foreach (TrainingData t in trainingData5)
        {
            trainingDataString5 += t.ToString();
        }
        trainingDataString6 = "";
        foreach (TrainingData t in trainingData6)
        {
            trainingDataString6 += t.ToString();
        }
        trainingDataString7 = "";
        foreach (TrainingData t in trainingData7)
        {
            trainingDataString7 += t.ToString();
        }
        trainingDataString8 = "";
        foreach (TrainingData t in trainingData8)
        {
            trainingDataString8 += t.ToString();
        }
        trainingDataString9 = "";
        foreach (TrainingData t in trainingData9)
        {
            trainingDataString9 += t.ToString();
        }
        trainingDataString10 = "";
        foreach (TrainingData t in trainingData10)
        {
            trainingDataString10 += t.ToString();
        }

        PlayerPrefs.SetString("trainingData1", trainingDataString1);
        PlayerPrefs.SetString("trainingData2", trainingDataString2);
        PlayerPrefs.SetString("trainingData3", trainingDataString3);
        PlayerPrefs.SetString("trainingData4", trainingDataString4);
        PlayerPrefs.SetString("trainingData5", trainingDataString5);
        PlayerPrefs.SetString("trainingData6", trainingDataString6);
        PlayerPrefs.SetString("trainingData7", trainingDataString7);
        PlayerPrefs.SetString("trainingData8", trainingDataString8);
        PlayerPrefs.SetString("trainingData9", trainingDataString9);
        PlayerPrefs.SetString("trainingData10", trainingDataString10);
    }
    public void DurationIncrease()
    {
        if (currentDuration < 90) currentDuration += 10;
        textDuration.text = currentDuration.ToString();
    }
    public void DurationDecrease()
    {
        if (currentDuration > 10) currentDuration -= 10;
        textDuration.text = currentDuration.ToString();
    }
    private void AddTraining(string _type)
    {

        if (System.DateTime.Now < week2Startdate)
        {
            trainingData1.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week3Startdate)
        {
            trainingData2.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week4Startdate)
        {
            trainingData3.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week5Startdate)
        {
            trainingData4.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week6Startdate)
        {
            trainingData5.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week7Startdate)
        {
            trainingData6.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week8Startdate)
        {
            trainingData7.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week9Startdate)
        {
            trainingData8.Add(new TrainingData(_type, currentDuration));
        }
        else if (System.DateTime.Now < week10Startdate)
        {
            trainingData9.Add(new TrainingData(_type, currentDuration));
        }
        else
        {
            trainingData10.Add(new TrainingData(_type, currentDuration));
        }
    }
    public void AddCrosstrainer()
    {
        AddTraining("crosstrainer");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    public void AddFiets()
    {
        AddTraining("fiets");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    public void AddLopen()
    {
        AddTraining("lopen");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    public void AddRoeien()
    {
        AddTraining("roeien");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    public void AddWandelen()
    {
        AddTraining("wandelen");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    public void AddGroepsles()
    {
        AddTraining("groepsles");
        WriteTrainingDataString();
        ShowOverzicht();
    }
    #endregion



    #region Overzicht
    private void LoadOverzicht()
    {
        trainingDataString1 = PlayerPrefs.GetString("trainingData1");
        trainingData1 = new List<TrainingData>();
        week1score = 0;

        if (trainingDataString1.Length > 0)
        {
            var aRows = trainingDataString1.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[1]), int.Parse(aData[2]), float.Parse(aData[3]));
                    week1score += temp.punten;
                    trainingData1.Add(temp);
                }
            }
        }

        progressbar1.GetComponentInChildren<Text>().text = "Week 1: " + week1score.ToString() + "/" + week1goal.ToString();
        progressbar1.GetComponentInChildren<Image>().fillAmount = week1score / week1goal;



        trainingDataString2 = PlayerPrefs.GetString("trainingData2");
        trainingData2 = new List<TrainingData>();
        week2score = 0;

        if (trainingDataString2.Length > 0)
        {
            var aRows = trainingDataString2.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[2]), int.Parse(aData[2]), float.Parse(aData[3]));
                    week2score += temp.punten;
                    trainingData2.Add(temp);
                }
            }
        }

        progressbar2.GetComponentInChildren<Text>().text = "Week 2: " + week3score.ToString() + "/" + week3goal.ToString();
        progressbar2.GetComponentInChildren<Image>().fillAmount = week3score / week3goal;



        trainingDataString3 = PlayerPrefs.GetString("trainingData3");
        trainingData3 = new List<TrainingData>();
        week3score = 0;

        if (trainingDataString3.Length > 0)
        {
            var aRows = trainingDataString3.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[3]), int.Parse(aData[3]), float.Parse(aData[3]));
                    week3score += temp.punten;
                    trainingData3.Add(temp);
                }
            }
        }

        progressbar3.GetComponentInChildren<Text>().text = "Week 3: " + week3score.ToString() + "/" + week3goal.ToString();
        progressbar3.GetComponentInChildren<Image>().fillAmount = week3score / week3goal;



        trainingDataString4 = PlayerPrefs.GetString("trainingData4");
        trainingData4 = new List<TrainingData>();
        week4score = 0;

        if (trainingDataString4.Length > 0)
        {
            var aRows = trainingDataString4.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[4]), int.Parse(aData[4]), float.Parse(aData[3]));
                    week4score += temp.punten;
                    trainingData4.Add(temp);
                }
            }
        }

        progressbar4.GetComponentInChildren<Text>().text = "Week 4: " + week4score.ToString() + "/" + week4goal.ToString();
        progressbar4.GetComponentInChildren<Image>().fillAmount = week4score / week4goal;



        trainingDataString5 = PlayerPrefs.GetString("trainingData5");
        trainingData5 = new List<TrainingData>();
        week5score = 0;

        if (trainingDataString5.Length > 0)
        {
            var aRows = trainingDataString5.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[5]), int.Parse(aData[5]), float.Parse(aData[3]));
                    week5score += temp.punten;
                    trainingData5.Add(temp);
                }
            }
        }

        progressbar5.GetComponentInChildren<Text>().text = "Week 5: " + week5score.ToString() + "/" + week5goal.ToString();
        progressbar5.GetComponentInChildren<Image>().fillAmount = week5score / week5goal;



        trainingDataString6 = PlayerPrefs.GetString("trainingData6");
        trainingData6 = new List<TrainingData>();
        week6score = 0;

        if (trainingDataString6.Length > 0)
        {
            var aRows = trainingDataString6.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[6]), int.Parse(aData[6]), float.Parse(aData[3]));
                    week6score += temp.punten;
                    trainingData6.Add(temp);
                }
            }
        }

        progressbar6.GetComponentInChildren<Text>().text = "Week 6: " + week6score.ToString() + "/" + week6goal.ToString();
        progressbar6.GetComponentInChildren<Image>().fillAmount = week6score / week6goal;



        trainingDataString7 = PlayerPrefs.GetString("trainingData7");
        trainingData7 = new List<TrainingData>();
        week7score = 0;

        if (trainingDataString7.Length > 0)
        {
            var aRows = trainingDataString7.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[7]), int.Parse(aData[7]), float.Parse(aData[3]));
                    week7score += temp.punten;
                    trainingData7.Add(temp);
                }
            }
        }

        progressbar7.GetComponentInChildren<Text>().text = "Week 7: " + week7score.ToString() + "/" + week7goal.ToString();
        progressbar7.GetComponentInChildren<Image>().fillAmount = week7score / week7goal;



        trainingDataString8 = PlayerPrefs.GetString("trainingData8");
        trainingData8 = new List<TrainingData>();
        week8score = 0;

        if (trainingDataString8.Length > 0)
        {
            var aRows = trainingDataString8.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[8]), int.Parse(aData[8]), float.Parse(aData[3]));
                    week8score += temp.punten;
                    trainingData8.Add(temp);
                }
            }
        }

        progressbar8.GetComponentInChildren<Text>().text = "Week 8: " + week8score.ToString() + "/" + week8goal.ToString();
        progressbar8.GetComponentInChildren<Image>().fillAmount = week8score / week8goal;



        trainingDataString9 = PlayerPrefs.GetString("trainingData9");
        trainingData9 = new List<TrainingData>();
        week9score = 0;

        if (trainingDataString9.Length > 0)
        {
            var aRows = trainingDataString9.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[9]), int.Parse(aData[9]), float.Parse(aData[3]));
                    week9score += temp.punten;
                    trainingData9.Add(temp);
                }
            }
        }

        progressbar9.GetComponentInChildren<Text>().text = "Week 9: " + week9score.ToString() + "/" + week9goal.ToString();
        progressbar9.GetComponentInChildren<Image>().fillAmount = week9score / week9goal;



        trainingDataString10 = PlayerPrefs.GetString("trainingData10");
        trainingData10 = new List<TrainingData>();
        week10score = 0;

        if (trainingDataString10.Length > 0)
        {
            var aRows = trainingDataString10.Split(';');
            foreach (string row in aRows)
            {
                var aData = row.Split(',');

                if (aData.Length == 4)
                {
                    TrainingData temp = new TrainingData(aData[0], System.DateTime.Parse(aData[10]), int.Parse(aData[10]), float.Parse(aData[3]));
                    week10score += temp.punten;
                    trainingData10.Add(temp);
                }
            }
        }

        progressbar10.GetComponentInChildren<Text>().text = "Week 10: " + week10score.ToString() + "/" + week10goal.ToString();
        progressbar10.GetComponentInChildren<Image>().fillAmount = week10score / week10goal;
    }
    #endregion
}
