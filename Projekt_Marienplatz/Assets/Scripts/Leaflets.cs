using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using static Walker;

public class Leaflets : MonoBehaviour
{
    [System.Serializable]
    public struct Leaflet
    {
        public Leaflet(string spriteName, Gender[] genders, Walker.Job[] jobs, Religion[] religions, CivilStatus[] civilStatuses, PoliticalStance[] politicalStances, Party[] parties)
        {
            SpriteName = spriteName;
            sprite = Resources.Load<Sprite>("leaflets/" + spriteName);
            Genders = genders;
            Jobs = jobs;
            Religions = religions;
            CivilStatuses = civilStatuses;
            PoliticalStances = politicalStances;
            Parties = parties;
        }
        public string SpriteName;
        public Sprite sprite;
        public Gender[] Genders;
        public Job[] Jobs;
        public Religion[] Religions;
        public CivilStatus[] CivilStatuses;
        public PoliticalStance[] PoliticalStances;
        public Party[] Parties;
    }

    [SerializeField]
    public Leaflet[] leafletArray = new Leaflet[25];

    [SerializeField]
    public int currentLeafletIndex = 2;

    SpriteRenderer spriteRenderer;

    public string[] spriteNames = {"017", "019", "022", "026", "040", "045", "052", "053", "054", "058", "062", "069a", "071a", "076", "082", "058", "090", "104", "105", "107", "129a", "132", "152", "155a", "159a" };
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        

        leafletArray[0] = new Leaflet(
            "017",
            new Gender[] { Gender.Male },
            new Job[] { Job.Soldier, Job.Worker },
            new Religion[] { Religion.Atheist, Religion.Catholic, Religion.Protestant, Religion.Jewish },
            new CivilStatus[] { CivilStatus.Married, CivilStatus.Single, CivilStatus.Widowed},
            new PoliticalStance[] {PoliticalStance.Liberal, PoliticalStance.Conservative},
            new Party[] {Party.DDP, Party.WBWB, Party.Zentrum, Party.Buergerpartei}
            );
        leafletArray[1] = new Leaflet(
            "019",
            new Gender[] { Gender.Male },
            new Job[] { Job.Employee, Job.Soldier, Job.Worker, Job.Officer },
            new Religion[] { Religion.Atheist, Religion.Catholic, Religion.Protestant, Religion.Jewish },
            new CivilStatus[] { CivilStatus.Married, CivilStatus.Single, CivilStatus.Widowed },
            new PoliticalStance[] { PoliticalStance.Conservative },
            new Party[] { Party.WBWB, Party.Zentrum, Party.Buergerpartei }
            );
        leafletArray[2] = new Leaflet(
            "022",
            new Gender[] { Gender.Female },
            new Job[] { Job.Employee, Job.Worker, Job.Unemployed },
            new Religion[] { Religion.Atheist, Religion.Catholic, Religion.Protestant, Religion.Jewish },
            new CivilStatus[] { CivilStatus.Married, CivilStatus.Single, CivilStatus.Widowed },
            new PoliticalStance[] { PoliticalStance.Liberal, PoliticalStance.Left },
            new Party[] { Party.KPD, Party.USPD, Party.MSPD}
            );
        leafletArray[3] = new Leaflet(
            "026",
            new Gender[] { Gender.Female, Gender.Male },
            new Job[] { Job.Officer, Job.Worker, Job.Farmer },
            new Religion[] { Religion.Atheist, Religion.Protestant, Religion.Jewish },
            new CivilStatus[] { CivilStatus.Married, CivilStatus.Single, CivilStatus.Widowed },
            new PoliticalStance[] { PoliticalStance.Liberal, PoliticalStance.Left },
            new Party[] { Party.KPD, Party.USPD }
            );
        leafletArray[4] = new Leaflet(
            "040",
            new Gender[] { Gender.Female, Gender.Male },
            new Job[] { Job.Employee, Job.Worker, Job.Farmer },
            new Religion[] { Religion.Atheist, Religion.Jewish, Religion.Protestant},
            new CivilStatus[] { CivilStatus.Married, CivilStatus.Single, CivilStatus.Widowed },
            new PoliticalStance[] { PoliticalStance.Liberal, PoliticalStance.Left },
            new Party[] { Party.USPD, Party.MSPD }
            );



        spriteRenderer.sprite = leafletArray[currentLeafletIndex].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
