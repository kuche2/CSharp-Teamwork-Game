using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using ConsoleExtender;

namespace TeamWork_CSharp2
{
    class Example
    {
        static void Main(string[] args)
        {
            Console.Title = "Space Shooter";
            //var fonts = ConsoleHelper.ConsoleFonts;
            //for (int f = 0; f < fonts.Length; f++)
            //    Console.WriteLine("{0}: X={1}, Y={2}",
            //       fonts[f].Index, fonts[f].SizeX, fonts[f].SizeY);
            ConsoleHelper.SetConsoleFont(0);
            Console.WindowHeight = 117;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.WriteLine();
            //loading();
            playership();
            //spider();
            //Brand();
            Thread.Sleep(1000);
        }

        private static void loading()
        {
            /* Не пипай ако не знаеш какво правиш! :)*/ 
            var projectDirectory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            Image image = Image.FromFile(projectDirectory + "\\player.jpg");
            Console.SetBufferSize((image.Width * 0x4), (image.Height * 0x4));
            FrameDimension Dimension = new FrameDimension(image.FrameDimensionsList[0x0]);
            int FrameCount = image.GetFrameCount(Dimension);
            int Left = Console.WindowLeft, Top = Console.WindowTop;
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            image.SelectActiveFrame(Dimension, 0x0);
            for (int i = 0x0; i < image.Height; i++)
            {
                for (int x = 0x0; x < image.Width; x++)
                {
                    Color Color = ((Bitmap)image).GetPixel(x, i);
                    int Gray = (Color.R + Color.G + Color.B) / 0x3;
                    int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
            }
            Console.SetCursorPosition(Left, Top);
            Console.Read();
        }

        static void spider()
        {
            Console.WriteLine("              --              ");
            Console.WriteLine("              =#:            ");
            Console.WriteLine("             -%#:             ");
            Console.WriteLine("      - -:   +@#=             ");
            Console.WriteLine("     *#@%#%  %##@- -@=*=*    ");
            Console.WriteLine("   :*##@@##* @###- @#####-    ");
            Console.WriteLine("  =@##:  +##:@###:+#@:-+##+*  ");
            Console.WriteLine("  :#=    =##=@###+@#@   -###-");
            Console.WriteLine("   - -*=#=*########==%*   %:  ");
            Console.WriteLine("    %####%%########++##%%:    ");
            Console.WriteLine("  :=##%--###@##@#####++###:  ");
            Console.WriteLine("*@##@-  -@@#########@- -%##+:");
            Console.WriteLine("%##=    @#@########@@#   *###*");
            Console.WriteLine("--+     :#@########@#=    *##*");
            Console.WriteLine("       -+%@#%@##@%@@%      -  ");
            Console.WriteLine("      =#%%@@@####@@@%@%-      ");
            Console.WriteLine("     =##=#@=######%@@%##      ");
            Console.WriteLine("    *#%*-*:%######=%=:%#@     ");
            Console.WriteLine("   %#=-    @######*   -+#=   ");
            Console.WriteLine(" -##@-     %#@##@#+     +#@-  ");
            Console.WriteLine("-==+-      :#@####-      %##: ");
            Console.WriteLine("-          -=####=        :+* ");
            Console.WriteLine("            :###%             ");
            Console.WriteLine("            %####-            ");
            Console.WriteLine("            +#@##:            ");
            Console.WriteLine("            :#+@%             ");
            Console.WriteLine("            :* -*             ");
            Console.WriteLine("             -  -             ");
        }

        static void Brand()
        {
            Console.WriteLine("*****::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("****:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("***::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("**:::::::::::::::::::::::::::::::::::*++*::::::::::::::::::::::::");
            Console.WriteLine("**:::::::::::::::::::::::::::::::::-:***+**::::::::::::::::::::::");
            Console.WriteLine("**::::::::::::::::::::::::::::::::::*+**++**:-:::::::::::::::::::");
            Console.WriteLine("*::::::::::::::::::::::::::*::::::**+==+=:-+*::::::::::::::::::::");
            Console.WriteLine(":::::::::::::::::::***::***::::****++=@=%%%%+*-::::::::::::::::::");
            Console.WriteLine(":::::::::::::::::::******+*::***+=++=%%+%###=--::::::::::::::::::");
            Console.WriteLine(":::::::::::::::-:*+**++**+++*:**++====*++=@#+-:::::::::::::::::::");
            Console.WriteLine("::::::::::::*::*=++****++++++**+=++=%@=**:=#=-:::::::::::::::::::");
            Console.WriteLine("::::::::::::::*++**:::*++++++**:+=%%%##%+::%+-:::::::::::::::::::");
            Console.WriteLine(":::::::::::***++*:**+++===+***:--*+@@###@%%++:-::::::::::::::::::");
            Console.WriteLine(":::::::::::*+++=+*++==%%%=+=+::::*-*%#####@@=--::::::::::::::::::");
            Console.WriteLine("::::::::::::*====++===%%%=+++:*:**::*@#@@@%==*---::::::::::::::::");
            Console.WriteLine("::::::::::**+@%=%===%%%%=====*::*::--+@%=%==+++:-::::::::::::::::");
            Console.WriteLine("::::::::::%##@@##@%%@@@%%=+==+:-:*:::+@%=***::=+:--:-------------");
            Console.WriteLine("::::::::-:@#%=%@##@@@@@%@%%%=+******++%==+:-:*+=+*---:-:---------");
            Console.WriteLine("::::::::*=*:::**=###@@@@%=@#@=+==***+*==%+:-**=%++**-------------");
            Console.WriteLine(":::::::*=+-:::**+%##@@#@%%%##@%%%=++*+%=%=-:**+%+*:+*------------");
            Console.WriteLine(":::::::++:--:****%#####@@@@@###@%@%==%#==%:***+%%+*:+:-----------");
            Console.WriteLine("::::::*+*:::**+++=####@@%%@%@#########@++%=**+=@%=+*+*-----------");
            Console.WriteLine("::::::++*++**+++=%####@@%%%%%%%=%@@@@=+:*##%==%@%==++*-----------");
            Console.WriteLine(":::::*=++=+=++=+%@#@@@@@@@@%===**+**:-:::=##@@@@@@=+%+.----------");
            Console.WriteLine(":::::*@=%%=%%===@@@###@%%@@%=+++*::*+=%=+:=###@@@@%%@+.----------");
            Console.WriteLine("::::-=@@###@@@%%#%*##@@@@@%%%+***+%######%*=##@@#####=.----------");
            Console.WriteLine(":::::%@@#@####@@#=.%#@@@@@@%==+:+##@%==%##%=#####@%%@=.----------");
            Console.WriteLine("::::**::::+#####@:-:##@##@#@%=++#@%=*:*+%#@@####%==+**-----------");
            Console.WriteLine(":::::---:::=###@--:-*##@###@%==@@+++*:::=#@:*##@%=+*:*:----------");
            Console.WriteLine("::::::::***=@@%--:::-:=###@@%+=#%+**+**+%#=..@#@%=+****:---------");
            Console.WriteLine("::::::+*::+%@%:-:::::--@##@@%%%@%+++*++=@#:.:##@%=+++++*---------");
            Console.WriteLine(":::**-::-*+%@=+-::::::-%#@@@%%@%===+*+=%#=.-:###@%==+++=:--------");
            Console.WriteLine("::*+:::::+=@%%=-:::::::%@@@@@@=%=+++==%%#*.--%###@%===%%:--------");
            Console.WriteLine("::*+::::*++@%@=-:::::-:=%%%%%%%%%++=%%%@@:--.=###@@@@@#%---------");
            Console.WriteLine(":::******:*+%@:::::::-:=====%%%%=+===%%%@:---:###@#####@.--------");
            Console.WriteLine(":::***:*::**%=-::::::-*#%%%=%%%%=++++==%#*.--.%########=---------");
            Console.WriteLine(":::***:::**+%:-::::::-:###@==%%%%=+====%#+.--.*####@%%=++:-------");
            Console.WriteLine(":::*****:**+=*::::::::-*####%%%%===++=%@#*.---.@##%+++%%***------");
            Console.WriteLine(":::++*******==*-::::::-:==%@@%%%=+++*+=@#*----.+#%%=+*+%+**------");
            Console.WriteLine(":::+++:::+**+=+:::::::-*==++===%@%=++=%@%=+----:@@@==++==+*:-----");
            Console.WriteLine(":::++*::::*+++=+:::::-:%%%%++++%##%+==##*+@=*-.-@#@%%=++=++:-----");
            Console.WriteLine(":::+=:**:**++==%:-:::-:=**=%=*+=@##%%@#=*==+**:.=#@@@%=+++**-----");
            Console.WriteLine(":::*+***:***+@#%*-::-:++*::+%%+*+#####@*+=+*::+*-%##@@%+****:----");
            Console.WriteLine("::::*+*+*:::+##%+::-:+==+*::+%=++=%@@%++==+****+*.=###%=+++*:----");
            Console.WriteLine(":::*+++=+*::*+##=*--*=+*+=*:*+==+****:*=%=++++++=:.+##*:*++**:---");
            Console.WriteLine(":::*=++*+::+*:+##+.:=+++*+++*+%@=+*::*=#@%====++++-.*%::*+**+:---");
            Console.WriteLine("::::==+*=+=@=+:%@*-+%++***+=*+=@@%=+=%###@=%%==++=*..++++*+**:---");
            Console.WriteLine("::::*+++=@##@+++:-:===+++**++=%@###@####@%%@%==+++*.-%+*==++**:--");
            Console.WriteLine(":::::+=@@@@@@%%@+.+=++++=++=%@###@=*=###@@%%%==+=+:--=++@#%+*+:--");
            Console.WriteLine(":::::*%##@@%%@#@:-+=+*+++=%@@%+*:--..-*@##@%%===**=*-%=@###=:*:--");
            Console.WriteLine(":::::::+@#@@#@+:-*+***+++=@#+-.-------.-+##%%===++%=.=#####=**:--");
            Console.WriteLine(":::::::-:+=%=:---*=****==%#+.-:::-------.:%#%=%%%%=*-.%#@@#%**+--");
            Console.WriteLine(":::::::::-::--::-+=+*:+=%#+.-::::--------..=#@@@%%+**.-##@@%:++--");
            Console.WriteLine("::::::::::::::::-+%%%==%@+--::::-:---------.+##@%%%@+-.*#@@+*=---");
            Console.WriteLine("::::::::::::::::-+%%@@%@+--::::::-----------.*@@=%##*..*@%%%@*.--");
            Console.WriteLine("::::::::::::::::*=%+*@#+--:::::::::-----------*=++=%*..+@==@=.---");
            Console.WriteLine("::::::::::::::::+%=:*@+.:::::::::::----------++*:+++*.-%@@#=-----");
            Console.WriteLine("::::::::::::::::+@@+%@:-::::::::::::--------:++++++=*--:%%*------");
            Console.WriteLine(":::::::::::::::+==####+-::::::::::::--------+=++++++:--.--.------");
            Console.WriteLine("::::::::::::::*===@@@%=:-::::::::::::-------=@%=++==+------------");
            Console.WriteLine("::::::::::::::++%%==%%%::::::::::::::::----.=#@%===%+:-----------");
            Console.WriteLine("::::::::::::::===%+%@@+-:::::::::::::::-----:##@@@%=*:-----------");
            Console.WriteLine(":::::::::::::-=%==+%@@:-:::::::::::::::--:-:.*###@%++:-----------");
            Console.WriteLine(":::::::::::::-+#%%%@#+-::::::::::::::::::----.=#@%==++-----------");
            Console.WriteLine(":::::::::::::-=@%%%#=-::::::::::::::::::::--:.*#%==++=:----------");
            Console.WriteLine(":::::::::::::*====@@:-:::::::::::::::::::::---:@=+++***----------");
            Console.WriteLine(":::::::::::::*+++=@%::::::::::::::::::::::::--:====**:+*---------");
            Console.WriteLine("::::::::::::*+**+**=*-:::::::::::::::::::::-:--+=++***++--:------");
            Console.WriteLine("::::::::::::*++*++*=+::::::::::::::::::::::::-:===+****+*--:-----");
            Console.WriteLine(":::::::::::****::***=*-:::::::::::::::::::::--+++==++**:+*-----::");
            Console.WriteLine(":::::::::::*::*==%=+%+-:::::::::::::::::::::-*=====+++**@#:.::--:");
            Console.WriteLine("::::::::::*+=@%@%%@=%=::::::::::::::::::::::-+=======+++==*--::-:");
            Console.WriteLine("::::::::::+%%%+=*=**@%:::::::::::::::::::::-:%=+=%======+:*%*-:::");
            Console.WriteLine("::::::::::==+=+=+@++#%:::::::::::::::::::::::=@%%@@%%==%%=%#+-:::");
            Console.WriteLine("::::::::::+@@@@@%#@@@+:::::::::::::::::::::::*==%%%%%%%=%%%=:::::");
            Console.WriteLine("::::::::::*+===%%%==*:::::::::::::::::::::::::::***********::::::");
            Console.WriteLine("::::::::::::::::*::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
        }
        static void playership()
        {
            Console.WriteLine("                        --                      ");
            Console.WriteLine("                  :-    %@    -:                ");
            Console.WriteLine("                  %#=   ##   +#%                ");
            Console.WriteLine("                  ##=   ##-  +##-               ");
            Console.WriteLine("                 *##*  *##+  *##+               ");
            Console.WriteLine("                 %##:  @###  -##@               ");
            Console.WriteLine("                 ##*   ####   *##               ");
            Console.WriteLine("                -#%   :#@@#*   =#:              ");
            Console.WriteLine("                =@%   +#=+#%   =#%              ");
            Console.WriteLine("                #@%   @@##%#   =@@-             ");
            Console.WriteLine("               :%@%   @+##%@   =@%*             ");
            Console.WriteLine("               +=@= - *=%##* - =#==             ");
            Console.WriteLine("               ==#=+% *@###+ ==+#=%             ");
            Console.WriteLine("               #+#++% %####% ==+#+#             ");
            Console.WriteLine("               #+#++= %####@ +=*#+#             ");
            Console.WriteLine("               ==@+*+ @%###% ***@=%             ");
            Console.WriteLine("              %@@#+:* %%###= ***#@@%            ");
            Console.WriteLine("             -%%##*:* %@###% :*:##@%:           ");
            Console.WriteLine("             %==@#%@::%%@##=*-@=##==@           ");
            Console.WriteLine("            -++=@=##-:@=@#%%*-##=@=++:          ");
            Console.WriteLine("            %%##@@=#--#%%#%#:-#=@@##%%          ");
            Console.WriteLine("           :###@##=#=:#%@#=#*+#=##@###:         ");
            Console.WriteLine("           *##@###=@#@@=##=@@#@=###@##=         ");
            Console.WriteLine("          +%=%#%=#%%##%=##==##%%#=%#@=%=        ");
            Console.WriteLine("         -#@=#%=@##%##%%@#%=##%@#@%%#%%#*       ");
            Console.WriteLine("         ####%===##%###=@@=###%##%===####       ");
            Console.WriteLine("        *###+++++##=###=@#=@##=##+++++###=      ");
            Console.WriteLine("       -###++@@+=##=@##@#####@=@#%+@@=+###-     ");
            Console.WriteLine("       -#####@###@%+@####@###@+%@###@#####:     ");
            Console.WriteLine("       +####@@%:===-%###=+###@-===:=@@####=     ");
            Console.WriteLine("      +#######: @@@-+##    ##= @@@ -#######=    ");
            Console.WriteLine("     +###@####* =%#=-##    ##-+#%% :####@###=   ");
            Console.WriteLine("    -###@###@-  +=%@ ###  ### =@==  -%###@###:  ");
            Console.WriteLine("   :@#%###@:    **=@ @##  ### =%*+    :@###%##: ");
            Console.WriteLine("  +%@@##@*      :*+= +#:  :#= +=*:      :@##@#%+");
            Console.WriteLine("  =####*        -:+= :#*  :#* *+::        *####=");
            Console.WriteLine("  -%#+            *+  ##  ##- *+-           *#@-");
            Console.WriteLine("                  ::  #%  =#  -:                ");
            Console.WriteLine("                      +:  :=   -                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
        }
    }
}
