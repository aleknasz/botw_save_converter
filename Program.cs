// Credits
using Core;
using System.Diagnostics;

Console.WriteLine("Breath of the Wild Save Manager by Jordan Marine, fork of https://github.com/WemI0/BOTW_SaveConv, rewritten and updated by Alex\n\n");
Console.Write("Drag and drop your save folder here and press enter: ");
string? input = Console.ReadLine();


if (input != null && Directory.Exists(input)) {
    BotwSave save = new(input, true);

    Console.Write($"\nIdentified {save.SaveType.ConsoleName()} save, convert it to {save.SaveType.Reverse().ConsoleName()}? (Y/n) ");
    string? response = Console.ReadLine();

    if ((response ?? "").ToLower() != "n") {
        Console.Write("\nDrag and drop your save folder output here and press enter: ");
        string? output = Console.ReadLine();


        if (output != null) {
            try {
                Directory.CreateDirectory(output);
                save.ConvertPlatform(output);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSave converted successfully to {save.SaveType.ConsoleName()}: '{output}'");
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex);
            }

            Console.ResetColor();
        }
    }
}
else {
    Console.WriteLine("Please enter a valid folder path.");
}

Console.WriteLine("\nPress enter to exit. . .");
Console.ReadLine();