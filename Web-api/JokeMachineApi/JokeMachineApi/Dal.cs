using System.Globalization;
namespace JokeMachineApi
{
    public class Dal
    {
        //Make this load from a txt file later on
        //Could have been a method returning jokes aswell
        public static readonly List<Joke> jokes = new List<Joke>()
        {
            new Joke(1,"Alle børnene kom helt sikkert over vejen – Undtagen den lille stakkels Peter. Han manglede blot en meter",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(2,"Hvorfor skulle skyen i skole? – Fordi den skulle lære at regne",new CultureInfo("da-DK"), JokeCategory.Dad),
            new Joke(3,"Hvordan bliver man ekspert i tordenvejr? – Man tager et lynkursus",new CultureInfo("da-DK"), JokeCategory.Dad),
            new Joke(4,"Må jeg gerne spise yoghurt i sofaen? – Far: “Nej put det i en skål?”",new CultureInfo("da-DK"), JokeCategory.Dad),
            new Joke(5,"Hvad gør man hvis AGF binder superligaen? – Slukker for sin Playstation og vender tilbage til det virkelige liv!",new CultureInfo("da-DK"), JokeCategory.Dad),
            new Joke(6,"Hvad ligger nede i en spand, og dagen lang siger den kun dav dav til alle der kommer forbi? – Det er selvfølgelig en spandauer",new CultureInfo("da-DK"), JokeCategory.Dad),
            new Joke(7,"Hvad er ordet som man aldrig vil kalde en sort mand? Det starter med N – Nabo",new CultureInfo("da-DK"), JokeCategory.Dark),
            new Joke(8,"Hvorfor sælger Kims ikke chips i afrika? – Fordi de aldrig er sultne for sjov",new CultureInfo("da-DK"), JokeCategory.Dark),
            new Joke(9,"Perkere er altid det mest venligste folkefærd... – De kommer altid over og spørg ”Har du et problem”?",new CultureInfo("da-DK"), JokeCategory.Dark),
            new Joke(10,"Hvorfor kan negerer ikke svømme? – Fordi de bliver sendt ned med lænker på",new CultureInfo("da-DK"), JokeCategory.Dark),
            new Joke(11,"Hvad kalder man røvhullet på et egern? – En nødudgang",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(12,"Hvad laver edderkoppen når den keder sig? – Den går på nettet",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(13,"Hvorfor kan man aldrig sælge en Zoologisk Have? – Den er for dyr",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(14,"Alle børnene løb over marken – Undtagen Bo, han blev voldtaget af en ko",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(15,"Hvad er det du kalder en nisse som arbejder som en elektriker? – Watt-nisse",new CultureInfo("da-DK"), JokeCategory.Funny),
            new Joke(16,"What do you call the asshole of a squirrel? - An emergency exit",new CultureInfo("en-US"), JokeCategory.Funny),
            new Joke(17,"What does the spider do when it gets bored? - It goes on the web",new CultureInfo("en-US"), JokeCategory.Funny),
            new Joke(18,"What is the word that one will never call a black man? It starts with N - Neighbor",new CultureInfo("en-US"), JokeCategory.Dark),
            new Joke(19,"What would Martin Luther king be if he were white?",new CultureInfo("en-US"), JokeCategory.Dark),
            new Joke(20,"May I eat yogurt on the couch? - Father: No put it in a bowl?",new CultureInfo("en-US"), JokeCategory.Dad),
        };
    }
}
