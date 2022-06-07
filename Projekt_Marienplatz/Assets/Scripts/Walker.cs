using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walker : MonoBehaviour
{
    GameObject waypointsObject;
    WayPoints waypointsScript;

    GameObject camObject;
    Cam camScript;

    GameObject player;
    Player playerScript;
    float reachOfPlayer = 22f;
    public float distFromPlayer;

    public bool hasReceivedLeaflet = false;

    UnityEngine.AI.NavMeshAgent agent;

    public enum Gender {Female, Male}
    public enum Job { Employee = 0, Worker = 1, Unemployed = 2, Officer = 3, Farmer = 4, Capitalist = 5, Soldier = 6}
    public enum Religion {Catholic, Protestant, Jewish, Atheist}
    public enum CivilStatus {Single, Married, Widowed, Orphaned}
    public enum PoliticalStance {Liberal, Conservative}
    public static string[] namesFemale = {"Ursula", "Ilse", "Hildegard", "Gerda", "Ingeborg", "Irmgard", "Helga", "Gertrud", "Lieselotte", "Edith", "Erika", "Elfriede", "Gisela", "Elisabeth", "Ruth", "Anneliese", "Margarete", "Margot", "Erna", "Herta", "Maria", "Inge", "Anna", "Käthe", "Waltraud", "Ingrid", "Charlotte", "Eva", "Martha", "Else", "Irma", "Lisa", "Marianne", "Annemarie", "Frida", "Hannelore", "Karla", "Elli", "Anni", "Helene", "Lotte", "Christa", "Christel", "Hedwig", "Johanna", "Luise", "Hilde", "Wilma", "Irene", "Dorothea", "Renate", "Anita", "Marie", "Ingeburg", "Vera", "Rosemarie", "Jutta", "Elsa", "Grete", "Emma", "Rita", "Ellen", "Klara", "Thea", "Marga", "Anne", "Ella", "Emmi", "Hannah", "Elsbeth", "Lydia", "Olga", "Katharina", "Agnes", "Magda", "Brigitte", "Dora", "Paula", "Eleonore", "Hilda", "Alice", "Edeltraud", "Hella", "Berta", "Sonja", "Magdalena", "Sigrid", "Margareta", "Lilli", "Gretchen", "Rosa", "Gertraud", "Barbara", "Magdalene", "Brunhilde", "Meta", "Wally", "Traute" };
    public static string[] namesMale = {"Hans", "Günther", "Karl", "Heinz", "Werner", "Gerhard", "Walther", "Kurt", "Horst", "Helmut", "Herbert", "Ernst", "Rudolph", "Willi", "Rolf", "Erich", "Heinrich", "Otto", "Wilhelm", "Alfred", "Hermann", "Paul", "Erwin", "Wolfgang", "Klaus", "Fritz", "Friedrich", "Harald", "Franz", "Georg", "Peter", "Egon", "Bruno", "Gerd", "Harry", "Johannes", "Richard", "Jürgen", "Bernhard", "Josef", "Johann", "Joachim", "Sigfried", "Manfred", "Robert", "Albert", "Adolph", "Lothar", "Max", "Gustav", "Ewald", "Reinhold", "Martin", "Arthur", "Henri", "Karlheinz", "Edgar", "Rudi", "Ulrich", "Reinhard", "Waldemar", "Emil", "Arnold", "Diedrich", "Arno", "Eberhard", "Theodor", "Erhard", "Dieter", "Alexander", "Edmund", "Eduard", "Hugo", "Uwe", "Konrad", "Alfons", "Ludwig", "August", "Hubert", "Oskar", "Wilfried", "Anton", "Norbert", "Christian", "Gottfried", "Victor", "Fred", "Leo", "Bodo", "Michael", "Johnny", "Berthold", "Ralph", "Jakob", "Alois", "Ferdinand", "Alwin", "John", "Julius", "Jan" };
    public static Job[] JobList = { Job.Farmer, Job.Worker, Job.Employee, Job.Officer, Job.Capitalist, Job.Soldier };
    public enum Party {KPD, USPD, MSPD, DDP, WBWB, Zentrum, Buergerpartei}

    public string firstName;
    public Gender gender;
    public float education;
    public int age;
    public Job job;
    public bool isWarDisabled;
    public Religion religion;
    public CivilStatus civilStatus;
    public bool isParent;
    public int politicalStance;

    public Party[] partyAffiliation;

    GameObject bodyObject;
    GameObject outlineObject;
    SpriteRenderer bodySprite;
    SpriteRenderer outlineSprite;

    [SerializeField]
    Sprite[] characterSpritesMale = new Sprite[7];
    [SerializeField]
    Sprite[] characterSpritesFemale = new Sprite[6];
    


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        waypointsObject = GameObject.Find("WayPoints");
        waypointsScript = waypointsObject.GetComponent<WayPoints>();

        camObject = GameObject.Find("Main Camera");
        camScript = camObject.GetComponent<Cam>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        agent.destination = waypointsScript.getRandomDestination();

        bodyObject = transform.Find("Body").gameObject;
        outlineObject = transform.Find("Outline").gameObject;
        bodySprite = bodyObject.GetComponent<SpriteRenderer>();
        outlineSprite = outlineObject.GetComponent<SpriteRenderer>();

        generateCharacterTraits();
        generateCharacterAppearance();
    }

    // Update is called once per frame
    void Update()
    {
        tryInteractingWithPlayer();
    }

    public bool isAtDestination()
    {
        if( Vector2.SqrMagnitude(transform.position - agent.destination) < 5f )
        {
            return true;
        }
        return false;
    }

    public bool isUnseen()
    {
        return !camScript.isInCameraBounds(transform.position);
    }

    void generateCharacterTraits()
    {
      // IMPORTANT //
      //This will generate normal distributed random floats given the mean and standard deviation of the distribution
      float box_muller(float mean, float stdDev){
        float u1 = 1.0f - Random.value;
        float u2 = 1.0f - Random.value;
        float randStdNorm = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        float randNorm = mean + stdDev * randStdNorm;
        return randNorm;
      }

      // Gender
        if (Random.Range(0, 2) == 0)
        {
            gender = Gender.Female;
            firstName = namesFemale[Random.Range(0, namesFemale.Length)];
        }
        else
        {
            gender = Gender.Male;
            firstName = namesMale[Random.Range(0, namesMale.Length)];
        }

        // Religion
        // Example case: People of jewish religion had better access to education, thus the distribution works in favour of a high education.
        // Also the political stance is leaned more to the left

        if (Random.Range(0, 5) == 0)
        {
            religion = Religion.Jewish;
            education = box_muller(7f, 2f);
            politicalStance = Mathf.RoundToInt(box_muller(2f, 4f));
            int rand = Mathf.RoundToInt(box_muller(4f, 2f));
            if(rand > JobList.Length -1){
              rand = JobList.Length - 1;
            };
            job = JobList[rand];
        }
        else
        {
            religion = Religion.Catholic; //oder Religion.Protestant
            education = box_muller(0f, 5f);
            politicalStance = Mathf.RoundToInt(box_muller(5f, 5f));
            job = JobList[Random.Range(0,6)];
        }




    }

    void generateCharacterAppearance()
    {
        int jobInt = (int) job;
        if (gender == Gender.Female)
        {
            outlineSprite.sprite = bodySprite.sprite = characterSpritesFemale[jobInt];
        }
        else if (gender == Gender.Male)
        {
            outlineSprite.sprite = bodySprite.sprite = characterSpritesMale[jobInt];
        }
        bodySprite.color = Color.white;
        outlineSprite.color = Color.black;
    }

    void tryInteractingWithPlayer()
    {
        distFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distFromPlayer <= reachOfPlayer && (!playerScript.isTalkingToWalker || playerScript.talkingWaker == gameObject))
        {
            agent.isStopped = true;
            //bodySprite.color = Color.yellow;
            outlineSprite.enabled = true;
            playerScript.isTalkingToWalker = true;
            playerScript.talkingWaker = gameObject;
        }
        else
        {
            if(playerScript.talkingWaker == gameObject)
            {
                playerScript.isTalkingToWalker = false;
                playerScript.talkingWaker = null;
            }
            agent.isStopped = false;
            //this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            outlineSprite.enabled = false;
        }
    }


    public int rewardLeaflet()
    {
        // need to implement reward function. Always returns 1 or 0 for now.
        if (!hasReceivedLeaflet)
        {
            hasReceivedLeaflet = true;
            return 1;
        }
        return 0;
    }
}
