using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    public Image InvasionTimerImage;
    public Image HarvesterTimerImage;
    public Image WarriorTimerImage;
    public Image HarvesterButtonImage;
    public Image WarriorButtonImage;
    public Image MuteGame;
    public Sprite MuteGameSprite;
    public Sprite PlaySoundGameSprite;
    public Image PauseGame;
    public Sprite PauseGameSprite;
    public Sprite PlayGameSprite;

    public AudioSource playGameSound;

    public AudioSource spiceCicleSound;
    public AudioSource foodCicleSound;
    public AudioSource buyHarvesterSound;
    public AudioSource buyWarriorSound;
    public AudioSource invasionSound;

    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public GameObject PauseScreen;

    public Button harvesterButton;
    public Button warriorButton;

    public Text resourcesText_1;
    public Text resourcesText_2;
    public Text resourcesText_3;
    public Text nextInvasionCount;
    public Text nextInvasionCicles;
    public Text invasionsCountText;
    public Text totalWarriorsCount;
    public Text totalWarriorsFallCount;
    public Text invasionsCountEnd;
    public Text invasionsCountWin;

    private int harvesterCount; //Число харвестеров
    private int warriorsCount; //Число воинов
    private int spiceCount; //Количество спайса

    private int spicePerHarvester; //Количество добываемого харвестером спайса
    private int spicePerWarriors; //Количество потребляемого спайса воинами

    private int harvesterCost; //Стоимость харвестера
    private int warriorCost; //Стоимость воина

    private float harvesterCreateTime; //Время, которое тратится на создание харвестера
    private float warriorCreateTime; //Время, которое тратится на создание воина
    private float invasionMaxTime; //Таймер нападения
    private float ciclesToNextInvasion;//Число циклов атаки до следующей волны
    private int invasionIncrease; //Увеличение количества нападающих
    private int countNextInvasion; //Количество нападающих в следующей волне

    private float harvesterTimer = -2; //Дефолтное значение таймера найма харвестера
    private float warriorTimer = -2; //Дефолтное значение таймера найма воина
    private float invasionTimer; //Таймер нападения
    [SerializeField] private int InvasionsCount;
    

    public Random random = new Random();
    private int nextIncreaseInvasion;
    private int count;

    private int totalWarriorsCountValue;
    private int totalWarriorsFallCountValue;
    void Start()
    {
        UpdateText();
        SetDefaultValuesOfEnemy();
        SetDefaultValuesOfUnits();
        playGameSound = GetComponent<AudioSource>();
        playGameSound.Play();
        invasionTimer = invasionMaxTime;
    }
    void Update()
    {
        invasionTimer -= Time.deltaTime;
        InvasionTimerImage.fillAmount = invasionTimer / invasionMaxTime;

        if (invasionTimer <= 0 && ciclesToNextInvasion >= 1)
        {
            invasionTimer = invasionMaxTime;
            countNextInvasion = 0;
            ciclesToNextInvasion -= 1;
            count++;
            if (count == 3 && invasionTimer == invasionMaxTime)
            {
                nextIncreaseInvasion = GetRandomValue();
            }
        }

        if (ciclesToNextInvasion < 1 && invasionTimer <= 0)
        {
            invasionIncrease = nextIncreaseInvasion;
            countNextInvasion += invasionIncrease;
            warriorsCount -= countNextInvasion;
            totalWarriorsFallCountValue += countNextInvasion;
            invasionTimer = invasionMaxTime;
            ++InvasionsCount;
            nextIncreaseInvasion = GetRandomValue();
            invasionSound.Play();
        }

        if (HarvestTimer.Tick)
        {
            spiceCount += harvesterCount * spicePerHarvester;
            spiceCicleSound.Play();
        }

        if (EatingTimer.Tick)
        {
            spiceCount -= warriorsCount * spicePerWarriors;
            foodCicleSound.Play();
        }

        if (harvesterTimer > 0)
        {
            harvesterTimer -= Time.deltaTime;
            HarvesterTimerImage.fillAmount = harvesterTimer / harvesterCreateTime;
        }
        else if (harvesterTimer > -1)
        {
            HarvesterTimerImage.fillAmount = 1;
            harvesterButton.interactable = true;
            harvesterCount += 1;
            harvesterTimer = -2;

        }

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            WarriorTimerImage.fillAmount = warriorTimer / warriorCreateTime;
        }

        else if (warriorTimer > -1)
        {
            WarriorTimerImage.fillAmount = 1;
            warriorButton.interactable = true;
            warriorsCount += 1;
            totalWarriorsCountValue += 1;
            warriorTimer = -2;

        }

        if (warriorsCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }

        if (InvasionsCount == 15)
        {
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);
        }

        if (spiceCount - harvesterCost >= 0)
        {
            HarvesterButtonImage.color = Color.green;
        }

        if (spiceCount - warriorCost >= 0)
        {
            WarriorButtonImage.color = Color.green;
        }

        UpdateText();
    }
    private void SetDefaultValuesOfEnemy()
    {
        invasionMaxTime = 12.5f;
        ciclesToNextInvasion = 3;
        invasionIncrease = 0;
        countNextInvasion = 0;
        InvasionsCount = 0;
        nextIncreaseInvasion = 0;
    }
    private void SetDefaultValuesOfUnits()
    {
        harvesterCount = 2;
        warriorsCount = 5;
        spiceCount = 10;
        spicePerHarvester = 4;
        spicePerWarriors = 3;
        harvesterCost = 4;
        warriorCost = 3;
        harvesterCreateTime = 4;
        warriorCreateTime = 1.4f;
        harvesterTimer = -2;
        warriorTimer = -2;
        count = 0;
        totalWarriorsCountValue = 5;
        totalWarriorsFallCountValue = 0;

    }
    public void CreateHarvester()
    {
        if (spiceCount - harvesterCost < 0)
        {
            HarvesterButtonImage.color = Color.red;
            warriorCost -= 1;
        }
        if (spiceCount - harvesterCost >= 0)
        {
            HarvesterButtonImage.color = Color.green;
            spiceCount -= harvesterCost;
            harvesterTimer = harvesterCreateTime;
            harvesterButton.interactable = false;
        }
    }
    public void CreateWarrior()
    {
        if (spiceCount - warriorCost < 0)
        {
            WarriorButtonImage.color = Color.red;
            warriorCost -= 1;
        }

        if (spiceCount - warriorCost >= 0)
        {
            WarriorButtonImage.color = Color.green;
            spiceCount -= warriorCost;
            warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
        }
    }
    private void UpdateText()
    {
        resourcesText_1.text = spiceCount.ToString();
        resourcesText_2.text = warriorsCount.ToString();
        resourcesText_3.text = harvesterCount.ToString();
        nextInvasionCicles.text = ciclesToNextInvasion.ToString();
        nextInvasionCount.text = Convert.ToString(countNextInvasion + nextIncreaseInvasion);
        invasionsCountText.text = InvasionsCount.ToString();
        invasionsCountEnd.text = InvasionsCount.ToString();
        invasionsCountWin.text = InvasionsCount.ToString();
        totalWarriorsCount.text = totalWarriorsCountValue.ToString();
        totalWarriorsFallCount.text = totalWarriorsFallCountValue.ToString();
    }
    public void TryAgain()
    {
        SetDefaultValuesOfEnemy();
        SetDefaultValuesOfUnits();
        UpdateText();
        SetDefaultTimers();
        GameOverScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        SetButtonsActive();
        Time.timeScale = 1;
    }
    private void SetDefaultTimers()
    {
        HarvesterTimerImage.fillAmount = 1;
        WarriorTimerImage.fillAmount = 1;
        HarvesterButtonImage.fillAmount = 1;
        WarriorButtonImage.fillAmount = 1;
    }
    private void SetButtonsActive()
    {
        warriorButton.interactable = true;
        harvesterButton.interactable = true;
    }
    private int GetRandomValue()
    {
        int value = random.Next(0, 3);
        return value;
    }

    public void Pause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            playGameSound.Pause();
            PauseGame.sprite = PlayGameSprite;
           PauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            playGameSound.Play();
            PauseGame.sprite = PauseGameSprite;
            PauseScreen.SetActive(false);
        }
    }

    public void Mute()
    {

        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0f;
            MuteGame.sprite = PlaySoundGameSprite;
        }
        else
        {
            AudioListener.volume = 1f;
            MuteGame.sprite = MuteGameSprite;
        }
    }

    public void BuyHarvesterSoundPlay()
    {
        buyHarvesterSound.Play();
    }

    public void BuyWarriorSoundPlay()
    {
        buyWarriorSound.Play();
    }

    




}
