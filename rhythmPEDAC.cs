/*
PROBLEM:

Create two tables, one for album and one for band
Need a foreign key: Band has many albums, album belongs to one Band.

Create a menu:
Add a new band
 View all the bands
 Add an album for a band
 Let a band go (update isSigned to false)
 Resign a band (update isSigned to true)
 Prompt for a band name and view all their albums
 View all albums ordered by ReleaseDate
 View all bands that are signed
 View all bands that are not signed
 Quit the program


EXAMPLES:

Check rhythm.sql for queries examples

Menu will be similar to our banking app. 

Welcome to the Rhythm Database

ADD BAND
VIEW BANDS
ADD ALBUM
RELEASE BAND
RESIGN BAND
VIEW BAND ALBUMS
VIEW ALBUMS BY RELEASE DATE
VIEW SIGNED BANDS
VIEW UNSIGNED BANDS
QUIT

DATA:
Tables: Bands and Albums

 static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Rhythm Database!");
            var hasQuitTheApplication = false;
            while (hasQuitTheApplication == false)
            {

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
                if (choice == "QUIT")
                {
                    hasQuitTheApplication = true;
                }
            }
        }



*/