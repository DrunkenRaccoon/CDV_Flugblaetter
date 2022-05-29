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
    float reachOfPlayer = 22f;
    public float distFromPlayer;

    UnityEngine.AI.NavMeshAgent agent;

    public enum Gender {Female, Male}
    public enum Job {Unemployed, Farmer, Worker, Employee, Officer, Capitalist, Soldier}
    public enum Religion {Catholic, Protestant, Jewish, Atheist}
    public enum CivilStatus {Single, Married, Widowed, Orphaned}
    public enum PoliticalStance {Liberal, Conservative}
    public static string[] namesFemale = {"Ursula", "Ilse", "Hildegard", "Gerda", "Ingeborg", "Irmgard", "Helga", "Gertrud", "Lieselotte", "Edith", "Erika", "Elfriede", "Gisela", "Elisabeth", "Ruth", "Anneliese", "Margarete", "Margot", "Erna", "Herta", "Maria", "Inge", "Anna", "Käthe", "Waltraud", "Ingrid", "Charlotte", "Eva", "Martha", "Else", "Irma", "Lisa", "Marianne", "Annemarie", "Frida", "Hannelore", "Karla", "Elli", "Anni", "Helene", "Lotte", "Christa", "Christel", "Hedwig", "Johanna", "Luise", "Hilde", "Wilma", "Irene", "Dorothea", "Renate", "Anita", "Marie", "Ingeburg", "Vera", "Rosemarie", "Jutta", "Elsa", "Grete", "Emma", "Rita", "Ellen", "Klara", "Thea", "Marga", "Anne", "Ella", "Emmi", "Hannah", "Elsbeth", "Lydia", "Olga", "Katharina", "Agnes", "Magda", "Brigitte", "Dora", "Paula", "Eleonore", "Hilda", "Alice", "Edeltraud", "Hella", "Berta", "Sonja", "Magdalena", "Sigrid", "Margareta", "Lilli", "Gretchen", "Rosa", "Gertraud", "Barbara", "Magdalene", "Brunhilde", "Meta", "Wally", "Traute" };
    public static string[] namesMale = {"Hans", "Günther", "Karl", "Heinz", "Werner", "Gerhard", "Walther", "Kurt", "Horst", "Helmut", "Herbert", "Ernst", "Rudolph", "Willi", "Rolf", "Erich", "Heinrich", "Otto", "Wilhelm", "Alfred", "Hermann", "Paul", "Erwin", "Wolfgang", "Klaus", "Fritz", "Friedrich", "Harald", "Franz", "Georg", "Peter", "Egon", "Bruno", "Gerd", "Harry", "Johannes", "Richard", "Jürgen", "Bernhard", "Josef", "Johann", "Joachim", "Sigfried", "Manfred", "Robert", "Albert", "Adolph", "Lothar", "Max", "Gustav", "Ewald", "Reinhold", "Martin", "Arthur", "Henri", "Karlheinz", "Edgar", "Rudi", "Ulrich", "Reinhard", "Waldemar", "Emil", "Arnold", "Diedrich", "Arno", "Eberhard", "Theodor", "Erhard", "Dieter", "Alexander", "Edmund", "Eduard", "Hugo", "Uwe", "Konrad", "Alfons", "Ludwig", "August", "Hubert", "Oskar", "Wilfried", "Anton", "Norbert", "Christian", "Gottfried", "Victor", "Fred", "Leo", "Bodo", "Michael", "Johnny", "Berthold", "Ralph", "Jakob", "Alois", "Ferdinand", "Alwin", "John", "Julius", "Jan" };

    public enum Party {KPD, USPD, MSPD, DDP, WBWB, Zentrum, Buergerpartei}

    public string firstName;
    public Gender gender;
    public int age;
    public Job job;
    public bool isWarDisabled;
    public Religion religion;
    public CivilStatus civilStatus;
    public bool isParent;
    public PoliticalStance politicalStance;

    public Party[] partyAffiliation;


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
        
        agent.destination = waypointsScript.getRandomDestination();

        generateCharacterTraits();
    }

    // Update is called once per frame
    void Update()
    {
        distFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if ( Vector2.Distance(transform.position, player.transform.position) <= reachOfPlayer)
        {
            agent.isStopped = true;
            this.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            agent.isStopped = false;
            this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

    public bool isAtDestination()
    {
        if( Vector2.SqrMagnitude(transform.position - agent.destination) < 3f )
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
    }
}
