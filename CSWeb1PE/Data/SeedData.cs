using CSWeb1PE.Models;

namespace CSWeb1PE.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication application)
        {
            using (IServiceScope scope = application.Services.CreateScope())
            {
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (!dbContext.Inschrijvingen.Any())
                {
                    // Student
                    Student student = new Student()
                    {
                        Gebruiker = new Gebruiker()
                        {
                            Email = "daan.vanluijk@student.pxl.be",
                            Naam = "van Luijk",
                            Voornaam = "Daan",
                            TijdelijkeRol = "Geen",
                        },
                    };
                    dbContext.Add(student);

                    // Lector
                    Lector lector = new Lector()
                    {
                        Gebruiker = new Gebruiker()
                        {
                            Email = "kristof.palmaers@pxl.be",
                            Naam = "Palmaers",
                            Voornaam = "Kristof",
                            TijdelijkeRol = "Geen",
                        },
                    };
                    dbContext.Add(lector);

                    // Handboek
                    string naam = "C# Web1";
                    Handboek handboek = new Handboek()
                    {
                        Titel = naam,
                        Kostprijs = 10,
                        UitgifteDatum = DateTime.Parse("01/01/2020"),
                        Afbeelding = "qskjfjqlksjflklqksjf", //TEMP
                    };
                    dbContext.Add(handboek);
                    dbContext.SaveChanges();

                    // Vak
                    Vak vak = new Vak()
                    {
                        VakNaam = naam,
                        Studiepunten = 6,
                        Handboek = handboek,
                    };
                    dbContext.Add(vak);

                    // VakLector
                    VakLector vakLector = new VakLector()
                    {
                        Lector = lector,
                        Vak = vak,
                    };
                    dbContext.Add(vakLector);

                    // AcademieJaar
                    AcademieJaar academieJaar = new AcademieJaar()
                    {
                        StartDatum = DateTime.Parse("20/09/2022"),
                    };
                    dbContext.Add(academieJaar);
                    dbContext.SaveChanges();

                    // Inschrijving
                    Inschrijving inschrijving = new Inschrijving()
                    {
                        Student = student,
                        VakLector = vakLector,
                        AcademieJaar = academieJaar,
                    };
                    dbContext.Add(inschrijving);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
