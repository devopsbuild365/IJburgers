using System;
using Microsoft.EntityFrameworkCore;
using PostService.Entities;

namespace PostService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        SeedData(scope.ServiceProvider.GetRequiredService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();
    
        if (context.Posts.Any())
        {
            Console.WriteLine("Database has been seeded.");
            return; 
        }

        var posts = new List<Post>()
        {
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurthulp: Wie kan mij helpen met boodschappen?",
                Content = "Hallo buurtbewoners! Door een blessure kan ik deze week niet zelf boodschappen doen. Is er iemand die mij zou kunnen helpen? Ik woon aan de Hoofdstraat 25. Graag zou ik woensdagmiddag de boodschappen willen doen. Natuurlijk vergoed ik alle kosten en geef ik een kleine attentie voor de moeite!",
                Author = "Maria van der Berg",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-10),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gratis hulp bij tuinonderhoud voor senioren",
                Content = "Ik ben student en wil graag iets terugdoen voor onze gemeenschap. Ik bied gratis hulp aan bij tuinonderhoud voor senioren in onze buurt. Denk aan onkruid wieden, gras maaien, heggen knippen. Stuur me een berichtje als je hulp nodig hebt!",
                Author = "Tom Jansen",
                CreatedAt = DateTime.UtcNow.AddDays(-8),
                UpdatedAt = DateTime.UtcNow.AddDays(-8),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },     
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gezamenlijke maaltijden voor alleenstaanden",
                Content = "Eet je vaak alleen en vind je dat niet zo gezellig? Iedere donderdagavond organiseren we een gemeenschappelijke maaltijd in het wijkcentrum. Iedereen neemt iets mee en we eten samen. Aanmelden is niet nodig, gewoon komen!",
                Author = "Marijke van der Pol",
                CreatedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtbibliotheek: Boeken ruilen en delen",
                Content = "We hebben een kleine buurtbibliotheek opgezet in het parkje aan de Kerkstraat. Iedereen kan gratis boeken lenen en inbrengen. Er staan al romans, kinderboeken en informatieve boeken. Kom gerust een kijkje nemen!",
                Author = "Peter de Vries",
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                UpdatedAt = DateTime.UtcNow.AddDays(-7),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Kleding ruilbeurs dit weekend",
                Content = "Zaterdag van 10-16 uur organiseren we een kleding ruilbeurs in de gemeenschapszaal. Breng kleding mee die je niet meer draagt en neem mee wat je leuk vindt. Gratis toegang, wel graag van tevoren aanmelden via email.",
                Author = "Sofie Hermans",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Zoek iemand voor hond uitlaten",
                Content = "Door werkomstandigheden kan ik mijn hond Max (golden retriever) niet altijd genoeg uitlaten. Zoek iemand die 2-3x per week een uurtje met hem wil wandelen. Natuurlijk betaal ik hiervoor!",
                Author = "Jan Bakker",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = DateTime.UtcNow.AddDays(-5),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Hulp bij verhuizing aangeboden",
                Content = "Ik heb een busje en wat vrienden die willen helpen. Bied gratis hulp aan bij kleine verhuizingen binnen de stad. Alleen benzinekosten vergoed is genoeg. Stuur een berichtje als je hulp nodig hebt!",
                Author = "Mike van Dijk",
                CreatedAt = DateTime.UtcNow.AddDays(-12),
                UpdatedAt = DateTime.UtcNow.AddDays(-12),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Computer hulp voor senioren",
                Content = "Iedere woensdagmiddag van 14-16 uur help ik gratis senioren met computer-, tablet- en smartphone vragen. In de bibliotheek, zaal 2. Neem je apparaat gerust mee!",
                Author = "Lisa Chen",
                CreatedAt = DateTime.UtcNow.AddDays(-6),
                UpdatedAt = DateTime.UtcNow.AddDays(-6),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtschoonmaak actie zaterdag",
                Content = "Zaterdag 9:00 verzamelen bij het park voor een buurtschoonmaak actie. Handschoenen en zakken worden verstrekt. Na afloop koffie en taart in het wijkcentrum. Samen maken we onze buurt nog mooier!",
                Author = "Gemeente Vrijwilligers",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gratis reparatie café elke maand",
                Content = "Eerste zaterdag van de maand van 13-17 uur is er reparatie café in het wijkcentrum. Breng kapotte spullen mee en wij proberen ze samen te repareren. Gratis service, donaties welkom!",
                Author = "Rob Reparatie",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-15),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Taalles Nederlands voor beginners",
                Content = "Elke dinsdag en donderdag van 19-20:30 geven we gratis Nederlandse taallessen voor beginners. In de bibliotheek, zaal 3. Iedereen is welkom, ook kinderen. Alleen vooraf aanmelden via email.",
                Author = "Taalcafé Vrijwilligers",
                CreatedAt = DateTime.UtcNow.AddDays(-9),
                UpdatedAt = DateTime.UtcNow.AddDays(-9),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Oppas gezocht voor sporadische avonden",
                Content = "Zoek een betrouwbare oppas voor onze 2 kinderen (6 en 9 jaar) voor af en toe een avondje uit. Meestal 19:00-23:00. Kinderen zijn makkelijk en gaan vroeg naar bed. Goede betaling!",
                Author = "Familie Scholten",
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                UpdatedAt = DateTime.UtcNow.AddDays(-4),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Fiets reparatie workshop zondag",
                Content = "Zondag 14:00 in de garage achter het wijkcentrum: leer je eigen fiets repareren! We behandelen lekke banden, remmen afstellen en versnellingen. Breng je eigen fiets mee. Gratis deelname!",
                Author = "Fiets Dokter",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtmoestuin heeft hulp nodig",
                Content = "Onze buurtmoestuin groeit en bloeit, maar we kunnen wel wat extra handjes gebruiken! Vooral voor wieden, zaaien en oogsten. Ervaring niet nodig, enthousiasme wel! Elke zaterdag van 10-12 uur.",
                Author = "Groene Vingers Collectief",
                CreatedAt = DateTime.UtcNow.AddDays(-11),
                UpdatedAt = DateTime.UtcNow.AddDays(-11),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Huiswerkbegeleiding voor kinderen",
                Content = "Iedere maandag en woensdag van 16-18 uur bieden we gratis huiswerkbegeleiding aan voor basisschool kinderen. In de bibliotheek, stil gedeelte. Aanmelden niet nodig, gewoon langskomen!",
                Author = "Onderwijsgevende Vrijwilligers",
                CreatedAt = DateTime.UtcNow.AddDays(-13),
                UpdatedAt = DateTime.UtcNow.AddDays(-13),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Speelgoed ruilmarkt voor kinderen",
                Content = "Donderdag van 15-18 uur speelgoed ruilmarkt op het schoolplein. Kinderen kunnen speelgoed meenemen waar ze uitgespeeld zijn en iets anders uitzoeken. Leuk voor kinderen en goed voor het milieu!",
                Author = "Oudercomité Basisschool",
                CreatedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Kookworkshop gezonde maaltijden",
                Content = "Zaterdag 11:00-15:00 kookworkshop 'Gezond en Goedkoop' in de keuken van het wijkcentrum. Leer 5 gezonde maaltijden maken voor onder de 5 euro per persoon. Inclusief lunch! Kosten: €10 per persoon.",
                Author = "Voedingscoach Anne",
                CreatedAt = DateTime.UtcNow.AddDays(-14),
                UpdatedAt = DateTime.UtcNow.AddDays(-14),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Eerste hulp cursus voor buurtbewoners",
                Content = "Over 2 weken starten we met een eerste hulp cursus voor buurtbewoners. 4 avonden van 19:30-21:30. Kosten €25 per persoon. Na afloop krijg je een officieel certificaat. Inschrijven via email!",
                Author = "Rode Kruis Afdeling",
                CreatedAt = DateTime.UtcNow.AddDays(-16),
                UpdatedAt = DateTime.UtcNow.AddDays(-16),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Senior uitjes organiseren",
                Content = "Ik organiseer leuke uitjes voor senioren in onze buurt: museumbezoeken, wandelingen, theatervoorstellingen. Volgende week gaan we naar het stadspark voor een picknick. Wie heeft zin om mee te gaan?",
                Author = "Uitjes Organisator Els",
                CreatedAt = DateTime.UtcNow.AddHours(-5),
                UpdatedAt = DateTime.UtcNow.AddHours(-5),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurt WhatsApp groep voor noodhulp",
                Content = "We hebben een WhatsApp groep voor directe buurtHulp opgezet. Voor spoedige vragen zoals: 'kan iemand even melk voor me halen?' of 'wie heeft een ladder?'. Stuur me een privé bericht voor de link!",
                Author = "Digitale Buur Coordinator",
                CreatedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            }
        };

        context.AddRange(posts);
        context.SaveChanges();
    }
}