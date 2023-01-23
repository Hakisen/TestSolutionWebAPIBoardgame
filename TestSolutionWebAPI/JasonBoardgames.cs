
using Newtonsoft.Json;

namespace TestSolutionWebAPI
{
    //public class JasonBoardgames //not used
    //{
    //}

    public class Rootobject //not needed for Json presentation (without database) in view (Swagger)
    {
        public Boardgame[]? boardgames { get; set; } //not used yet. Produced by VS2022 with "Paste Special -> as Json file.
    }

    public class Boardgame
    {
        //public int Id { get; set; }
        public string? id { get; set; }
        public string? name { get; set; }
        public string? released { get; set; }
        public string? tagline { get; set; }
        public Players? players { get; set; }  //Navigation Property, needed for EF db
        public int age { get; set; }

        public string[]? creators { get; set; }
        public string[]? categories { get; set; }

        //public Creators[]? creators { get; set; } //needed for database, navigation property
        //public Categories[]? categories { get; set; } // -""-             -""-

        //public List<string>? creators { get; set; } alternative for database
        //public List<string>? categories { get; set; } // -""-
    }

    public class Players
    {
        //public int Id { get; set; } //needed for database
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Creators
    {
        //public int Id { get; set; } // needed for database
        public string? Name { get; set; }
    }
    public class Categories
    {
        //public int Id { get; set; } // needed for database
        public string? Category { get; set; }
    }


    //ObjectName jasonText = JsonConvert.DeserializeObject<List<ObjectName>>(myJsonTextFileWebImportedOrOpened);

}


