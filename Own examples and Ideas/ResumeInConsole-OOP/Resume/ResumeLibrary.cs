using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume
{
  public class ResumeLibrary
  {
    ///constants
    private const string name = "Tim";
    private const string lastName = "Fischer";
    private readonly DateTime dateOfBirth = new DateTime(1980, 01, 01;
    private const string placeOfBirth = "City";
    private struct StoredAddress
    {
      public static string Street { get => "Street"; }
      public static int HouseNumber { get => 01; }
      public static int PostalCode { get => 12345; }
      public static string City { get => "Berlin"; }
      public override string ToString() =>
        $"{Street} {HouseNumber}" +
        $"\n{PostalCode} {City}";
    }

    ///backing fields
    private StoredAddress _storedAddress = new StoredAddress();
    private string _website = "https://www.comdecon.com/";

    private WorkEntry[] _workExperience = new WorkEntry[10];
    private EduEntry[] _academiaEdu = new EduEntry[7];

    ///constructor
    public ResumeLibrary()
    {
      _workExperience = new WorkEntry[10];
      _academiaEdu = new EduEntry[7];
      _workExperience[0] = GuestLecturer;
      _workExperience[1] = ConferenceSpeakerResearcher;
      _workExperience[2] = FounderOfComDeCon;
      _workExperience[3] = ResearchAssistant;
      _workExperience[4] = InternInterdepartmentalResearch;
      _workExperience[5] = FounderTimsDesigns;
      _workExperience[6] = Intern;
      _workExperience[7] = Tutor;
      _workExperience[8] = WorkingStudent;
      _workExperience[9] = Carpenter;
      _academiaEdu[0] = ArchitectureArchitecturalEngineering;
      _academiaEdu[1] = TimsDesignsAttendedEvents;
      _academiaEdu[2] = ArchitectureAndUrbanDesignStudies;
      _academiaEdu[3] = SemesterAbroad;
      _academiaEdu[4] = ArchitectureStudies;
      _academiaEdu[5] = ConstructionAndBuildingTechnology;
      _academiaEdu[6] = CarpenterApprenticeship;
    }


    ///properties
    public string Name { get => $"{name} {lastName}"; }
    public string Nationality { get => "German"; }
    public string DateOfBirth { get => dateOfBirth.ToString("dd/MM/yyyy"); }
    public string Address { get => _storedAddress.ToString(); }
    public string Website { get => _website; }
    public string LnProfile { get => "https://www.linkedin.com/in/timsdesigns/?locale=en_US"; }
    public string Email { get => "tims.designs@yahoo.com"; }

    #region work
    //Work Experience
    public WorkEntry GuestLecturer
    {
      get
      {
        WorkEntry entry = new WorkEntry(2021)
        {
          City = "Milan",
          Country = "Italy",
          Company = "Politecnico di Milano",
          WorkPosition = "Guest Lecturer",
          Reference = "carloandrea.biraghi@polimi.it - Coordinator | Research Fellow"
        };
        entry.WorkTitles = new string[] { "Applied Mathematics for Architecture" };
        entry.WorkDescriptions = new string[]
        { "Meshes/ Subdivision, fast “Waffling “- Algorithms,",
          "Heuristics (Galapagos and Silvereye),",
          "Structural Analysis (Karamba3D),",
          "Agent based Simulation (Quelea)" };
        return entry;
      }
    }
    public WorkEntry ConferenceSpeakerResearcher
    {
      get
      {
        WorkEntry entry = new WorkEntry(2020, 2021)
        {
          City = "Surrey",
          Country = "United Kingdom",
          Company = "University Surrey",
          WorkPosition = "Conference Speaker/ Researcher",
          Reference = "salvatore.viscuso@polimi.it - Adjunct Professor | Research Fellow"
        };
        entry.WorkTitles =
          new string[] { "\"Responsive Systems in Seismic Computational Design\"" };
        entry.WorkDescriptions = new string[] { "Spatial Structures IASS 2020/2021" };
        return entry;
      }
    }
    public WorkEntry FounderOfComDeCon
    {
      get
      {
        WorkEntry entry = new WorkEntry(2020)
        {
          City = "Berlin / Milan",
          Country = "Germany",
          Company = "ComDeCon",
          WorkPosition = "Founder of ComDeCon - Computational Design Consulting",
          Reference = "www.comdecon.com   -   company website"
        };
        entry.WorkTitles = new string[] {
          "B2B Consulting for Computational Design (CD) Application" };
        entry.WorkDescriptions = new string[] {
          "Software development for Grasshopper, FDM 3D Printing (inhouse)" };
        return entry;
      }
    }
    public WorkEntry ResearchAssistant
    {
      get
      {
        WorkEntry entry = new WorkEntry(2020)
        {
          City = "Milan",
          Country = "Italy",
          Company = "Textiles Hub",
          WorkPosition = "Research Assistant",
          Reference = "alessandra.zanelli@polimi.it   -   Lab Coordinator | Professor"
        };
        entry.WorkTitles = new string[] { "Waycover – Military Applications/ Patent Work" };
        entry.WorkDescriptions = new string[] { "Spatial Structures IASS 2020/2021" };
        return entry;
      }
    }
    public WorkEntry InternInterdepartmentalResearch
    {
      get
      {
        WorkEntry entry = new WorkEntry(2017)
        {
          City = "Milan",
          Country = "Italy",
          Company = "Textiles Hub",
          WorkPosition = "Intern - Interdepartmental Research Laboratory",
          Reference = "alessandra.zanelli@polimi.it   -   Lab Coordinator | Professor"
        };
        entry.WorkTitles = new string[] { "Computational Design" };
        entry.WorkDescriptions = new string[] { "Lab Research/ Software Development - Grasshopper" };
        return entry;
      }
    }
    public WorkEntry FounderTimsDesigns
    {
      get
      {
        WorkEntry entry = new WorkEntry(2015)
        {
          City = "Berlin",
          Country = "Germany",
          Company = "Tims Designs",
          WorkPosition = "Founder - Tims Designs",
        };
        entry.WorkTitles = new string[]
          { "3D Printing, Product Design, Planning, Visualization, Computational Design",
            "\"New Ways to live Venice\" - Competition" };
        return entry;
      }
    }
    public WorkEntry Intern
    {
      get
      {
        WorkEntry entry = new WorkEntry(2015)
        {
          City = "Berlin",
          Country = "Germany",
          Company = "Artis Engineering GmbH",
          WorkPosition = "Intern",
          Reference = "simon@lullin.ch   -   Head of Research and Development 2015"
        };
        entry.WorkTitles = new string[]
          { "R&D Wood engineering & Robotics" };
        return entry;
      }
    }
    public WorkEntry Tutor
    {
      get
      {
        WorkEntry entry = new WorkEntry(2009, 2010)
        {
          City = "Berlin",
          Country = "Germany",
          Company = "Beuth University",
          WorkPosition = "Intern - Interdepartmental Research Laboratory",
          Reference = "holze@beuth-hochschule.de   -   Professor for Computer Aided Design"
        };
        entry.WorkTitles = new string[] { "Archicad and 3D Studio Max" };
        return entry;
      }
    }
    public WorkEntry WorkingStudent
    {
      get
      {
        WorkEntry entry = new WorkEntry(2009)
        {
          City = "Berlin",
          Country = "Germany",
          Company = "oki. architekten GmbH",
          WorkPosition = "Intern - Interdepartmental Research Laboratory",
          Reference = "oki@oki-architekten.de   -   Inhaber"
        };
        entry.WorkTitles = new string[]
          { "Competition, Building Survey, Draft digitalization (Archicad)" };
        return entry;
      }
    }
    public WorkEntry Carpenter
    {
      get
      {
        WorkEntry entry = new WorkEntry(2005, 2007)
        {
          City = "A Hjalla/ Roager/ Ribe",
          Country = "Dennmark/ Faroe Islands",
          Company = "Roager Toemrer & Snedker/ AZV",
          WorkPosition = "Carpenter, Journeyman",
          Reference = "alessandra.zanelli@polimi.it   -   Lab Coordinator | Professor"
        };
        entry.WorkTitles = new string[]
          { "Instructing the apprentices, perform the ordered works, site inspection",
            "concrete piecework, site equipment, carpentry work" };
        return entry;
      }
    }
    #endregion

    #region academiaEdu
    //Academia/ Edu
    public EduEntry ArchitectureArchitecturalEngineering
    {
      get
      {
        EduEntry entry = new EduEntry(2016, 2020)
        {
          Institution = "Politecnico di Milano",
          City = "Milan",
          Country = "Italy",
          EduTitle = "Architecture – Architectural Engineering ADL/ADU",
        };
        entry.EduDescriptions = new string[]
        { "M.Sc. Architecture and Urban Design"
        ,"Intern CD (Textile Hub – Lab Research)"
        , "Research Assistant CD (Waycover – Military Applications)"
        , "Tutor/ Workshop Host – Grasshopper/ ArchiCAD"
        , "EVOLO 2019 – Skyscraper Competition"};
        return entry;
      }
    }
    public EduEntry TimsDesignsAttendedEvents
    {
      get
      {
        EduEntry entry = new EduEntry(2014, 2015)
        {
          Institution = "Tims Designs",
          City = "Berlin",
          Country = "Germany",
          EduTitle = "Tims Designs – Attended Events",
        };
        entry.EduDescriptions = new string[]
        { "Advanced Wood Architecture – Conference"
        ,"Informed Geometries - Workshop, Grasshopper - Workshop"
        , "MECS - Conference, “Build your own 3d Printer” – Workshop"};
        return entry;
      }
    }
    public EduEntry ArchitectureAndUrbanDesignStudies
    {
      get
      {
        EduEntry entry = new EduEntry(2012, 2014)
        {
          Institution = "School of Architecture FHP Potsdam",
          City = "Potsdam",
          Country = "Germany",
          EduTitle = "Architecture and Urban Design Studies",
        };
        entry.EduDescriptions = new string[]
        { "Bachelor of Arts (B.A.)"
        ,"8 Semester, 240 Credits"};
        entry.EduActivities = new string[]
        { "Multidisciplinary Courses: 3D Motion Design (Cinema 4D)"
        , "Grasshopper Workshops"};
        return entry;
      }
    }
    public EduEntry SemesterAbroad
    {
      get
      {
        EduEntry entry = new EduEntry(2013, 2014)
        {
          Institution = "ARCHIP - Architectural Institute in Prague",
          City = "Prague",
          Country = "Czech Republic",
          EduTitle = "Semester Abroad",
        };
        entry.EduDescriptions = new string[]
        { "CIEE - Workshop: Global Architecture and Design - Future Cities"
        ,"8 Semester, 240 Credits"};
        entry.EduActivities = new string[]
        { "Computational Design\n" +
        "(Design Research/ Rhino & Grasshopper/ Maya/ Python/ 3D Printing)"
        , "Product Design (1to1design s.r.o.)"};
        return entry;
      }
    }
    public EduEntry ArchitectureStudies
    {
      get
      {
        EduEntry entry = new EduEntry(2007, 2010)
        {
          Institution = "Beuth University",
          City = "Berlin",
          Country = "Germany",
          EduTitle = "Architecture Studies (Engineering and Construction Design)",
        };
        entry.EduDescriptions = new string[]
        { "Academic Tutor for ArchiCAD and 3D Max"
        ,"Civilian Service (AWO Südost Berlin 2008-09)"};
        return entry;
      }
    }
    public EduEntry ConstructionAndBuildingTechnology
    {
      get
      {
        EduEntry entry = new EduEntry(2006, 2007)
        {
          Institution = "Knobelsdorff-Schule",
          City = "Berlin",
          Country = "Germany",
          EduTitle = "Construction & Building Technology",
        };
        entry.EduDescriptions = new string[]
        { "Advanced Technical College Certificate"};
        return entry;
      }
    }
    public EduEntry CarpenterApprenticeship
    {
      get
      {
        EduEntry entry = new EduEntry(2002,02006)
        {
          Institution = "Knobelsdorff-Schule OSZ Bautechnik I",
          City = "Berlin",
          Country = "Germany",
          EduTitle = "Carpenter Apprenticeship",
        };
        entry.EduDescriptions = new string[]
        { "Journeyman’s Certificate"
        , "Development Aid Work – South Africa"};
        return entry;
      }
    }
    #endregion


    ///public methods
    public override string ToString()
    {
      string readout =
        $"{PersonalInfo()}\n" +
        $"{WorkExperience()}" +
        $"{AcademiaEdu()}\n" +
        $"{PersonalSkillsAndCompetences()}" +
        $"\nBerlin, {DateTime.Now.ToString("dd.MM.yyyy")}";
      return readout;
    }

    ///private methods
    private string PersonalSkillsAndCompetences()
    { return ""; }
    private string AcademiaEdu()
    {
      string output = "";
      foreach (EduEntry entry in _academiaEdu)
        if (entry != null)
          output += entry.ToString() + "\n";
      return $"\nAcademia/ Edu\n\n{output}";
    }
    private string WorkExperience()
    {
      string output = "";
      foreach (WorkEntry entry in _workExperience)
        if (entry != null)
          output += entry.ToString() + "\n";
      return $"\nWork experience\n\n{output}";
    }
    private string PersonalInfo()
    {
      return $"\n\nPersonal Information\n\n" +
        $"Nationality {Nationality}\n" +
        $"Date of Birth {DateOfBirth}\n" +
        $"Place of Birth {placeOfBirth}\n" +
        $"{_website}\n" +
        $"{LnProfile}\n" +
        $"{Email}\n";
    }
  }
}
