using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace RhythmsGonnaGetYou
{

    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; }
    }
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public List<Album> Albums { get; set; }
    }
    class RhythmContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }
        // BOILER PLATE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Rhythm");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmContext();
            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);
            // Greet User
            Console.WriteLine("Hello, welcome to the Record Company Database");
            // Create quiting variable
            var hasQuitApplication = false;
            // Loop through Menu
            while (hasQuitApplication == false)
            {
                // Create a Menu prompting for Action
                Console.WriteLine("------------------------------");
                Console.WriteLine("ADD BAND");
                Console.WriteLine("VIEW BANDS");
                Console.WriteLine("ADD ALBUM");
                Console.WriteLine("RELEASE BAND");
                Console.WriteLine("RESIGN BAND");
                Console.WriteLine("VIEW BAND ALBUMS");
                Console.WriteLine("VIEW ALBUMS BY RELEASE DATE");
                Console.WriteLine("VIEW SIGNED BANDS");
                Console.WriteLine("VIEW UNSIGNED BANDS");
                Console.WriteLine("QUIT");
                Console.WriteLine("------------------------------");
                Console.WriteLine("What would you like to do?");
                var choice = Console.ReadLine().ToUpper();
                if (choice == "ADD BAND")
                {
                    Console.WriteLine("What is the new band's name?");
                    var name = Console.ReadLine();
                    Console.WriteLine("What is the new band's country of origin?");
                    var countryOfOrigin = Console.ReadLine();
                    Console.WriteLine("How many members are in the new band?");
                    var numberOfMembers = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the new band's website?");
                    var website = Console.ReadLine();
                    Console.WriteLine("What is the new band's style?");
                    var style = Console.ReadLine();
                    Console.WriteLine("Is the new band signed, true or false?");
                    var isSigned = Boolean.Parse(Console.ReadLine());
                    Console.WriteLine("What is the new band's contact name?");
                    var contactName = Console.ReadLine();
                    Console.WriteLine("What is the new band's contact phone number?");
                    var contactPhoneNumber = Console.ReadLine();
                    var newBand = new Band
                    {
                        Name = name,
                        CountryOfOrigin = countryOfOrigin,
                        NumberOfMembers = numberOfMembers,
                        Website = website,
                        Style = style,
                        IsSigned = isSigned,
                        ContactName = contactName,
                        ContactPhoneNumber = contactPhoneNumber
                    };
                    context.Bands.Add(newBand);
                    context.SaveChanges();
                }
                if (choice == "VIEW BANDS")
                {
                    foreach (var band in bands)
                    {
                        Console.WriteLine($"Name of band: {band.Name}");
                    }
                }
                if (choice == "ADD ALBUM")
                {
                    Console.WriteLine("What is the new album's title?");
                    var title = Console.ReadLine();
                    Console.WriteLine("Is the new album explicit?");
                    var isExplicit = Boolean.Parse(Console.ReadLine());
                    Console.WriteLine("When was the Album released?");
                    var releaseDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("What is the band Id for the new album?");
                    var bandId = int.Parse(Console.ReadLine());
                    var newAlbum = new Album
                    {
                        Title = title,
                        IsExplicit = isExplicit,
                        ReleaseDate = releaseDate,
                        BandId = bandId
                    };
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
                if (choice == "RELEASE BAND")
                {
                    Console.WriteLine("What band would you like to let go?");
                    var fireBand = Console.ReadLine();
                    var existingBandToFire = context.Bands.FirstOrDefault(band => band.Name == fireBand);
                    if (existingBandToFire != null)
                    {
                        existingBandToFire.IsSigned = false;
                    }
                    context.SaveChanges();
                }
                if (choice == "RESIGN BAND")
                {
                    Console.WriteLine("What band would you like to sign?");
                    var signBand = Console.ReadLine();
                    var existingBandToSign = context.Bands.FirstOrDefault(band => band.Name == signBand);
                    if (existingBandToSign != null)
                    {
                        existingBandToSign.IsSigned = true;
                    }
                    context.SaveChanges();
                }
                if (choice == "VIEW BAND ALBUMS")
                {
                    Console.WriteLine("What is the bandId for the albums you want to see?");
                    var request = int.Parse(Console.ReadLine());

                    var albumsToView = albums.Where(album => album.Band.Id == request);
                    foreach (var album in albumsToView)
                    {
                        Console.WriteLine(album.Title);
                    }
                }
                if (choice == "VIEW ALBUMS BY RELEASE DATE")
                {
                    var orderedAlbums = albums.OrderBy(albums => albums.ReleaseDate);
                    foreach (var album in orderedAlbums)
                    {
                        Console.WriteLine(album.Title);
                    }
                }
                if (choice == "VIEW SIGNED BANDS")
                {
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == true)
                        {
                            Console.WriteLine($"{band.Name} is signed");
                        }
                    }
                }
                if (choice == "VIEW UNSIGNED BANDS")
                {
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == false)
                        {
                            Console.WriteLine($"{band.Name} is not signed");
                        }
                    }
                }
                if (choice == "QUIT")
                {
                    hasQuitApplication = true;
                }
            }
        }
    }
}
