using System;
using System.Collections.Generic;
using TagLib;
using System.IO;
using System.Linq;

namespace classes
{
    public static class Globals
    {
        public static Dictionary<string, Action<string, List<string>>> commandsMap = new ();
        public static List<string> targetFileNames = new ();
        
        static Globals()
        {
            commandsMap["set-author"] = (fileName, args) => setAuthor(fileName, args);
            commandsMap["set-album"] = (fileName, arg) => setAlbum(fileName, arg);
            commandsMap["set-genre"] = (fileName, arg) => setGenre(fileName, arg);
            commandsMap["set-year"] = (fileName, arg) => setYear(fileName, arg);
            commandsMap["set-composers"] = (fileName, arg) => setComposers(fileName, arg);
        }

        private static void setAuthor(string fileName, List<string> args)
        {
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine($"error: file does not exist: {fileName}");
                return;
            }

            try
            {
                TagLib.File file = TagLib.File.Create(fileName);
                file.Tag.Performers = args.ToArray();
                file.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine($"error editing {fileName}: {e.Message}");
            }
            
        }

        private static void setAlbum(string fileName, List<string> args)
        {
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine($"error: file does not exist: {fileName}");
                return;
            }

            try
            {
                TagLib.File file = TagLib.File.Create(fileName);
                file.Tag.Album = args[0];
                file.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine($"error editing {fileName}: {e.Message}");
            }
        }

        private static void setGenre(string fileName, List<string> args)
        {
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine($"error: file does not exist: {fileName}");
                return;
            }
            try
            {
                TagLib.File file = TagLib.File.Create(fileName);
                file.Tag.Genres = args.ToArray();
                file.Save();    
            }
            catch (Exception e)
            {
                Console.WriteLine($"error editing {fileName}: {e.Message}");
            }
        }

        private static void setYear(string fileName, List<string> args)
        {   
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine($"error: file does not exist: {fileName}");
                return;
            }

            try
            {
                int year;
                bool success = int.TryParse(args[0], out year);
                if (success)
                {
                    if (year < 0)
                    {
                        Console.WriteLine("error: year can't be negaitve");
                        return;
                    }

                    TagLib.File file = TagLib.File.Create(fileName);
                    file.Tag.Year = (uint)year;
                    file.Save();
                    return;
                }
                Console.WriteLine($"error: {args[0]} not a valid number for year");    
            }
            catch (Exception e)
            {
                Console.WriteLine($"error editing {fileName}: {e.Message}");
            }
            
        }

        private static void setComposers(string fileName, List<string> args)
        {
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine($"error: file does not exist: {fileName}");
                return;
            }

            try
            {
                TagLib.File file = TagLib.File.Create(fileName);
                file.Tag.Composers = args.ToArray();
                file.Save();    
            }
            catch (Exception e)
            {
                Console.WriteLine($"error editing {fileName}: {e.Message}");
            }
            
        }
    }
}