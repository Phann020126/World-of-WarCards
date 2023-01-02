using static System.Console;
using AST;
using GameProgram;
namespace Visual
{
    class BattleMenu
    {
        public void DisplayOptions()
        {
            CursorVisible = false;
            Console.Clear();
            if (GameManager.CurrentGame.CurrentPlayer.Controller is RandomPlayer)
            {
                DisplayOptionsForIA();
            }
            else
            {
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;
                    if (i == SelectedIndex)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        prefix = "*";
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                        prefix = "";
                    }
                    SetCursorPosition(Console.BufferWidth - 20, Console.BufferHeight - 1 + i * 10);
                    Console.WriteLine($"{prefix}  {currentOption}");

                }
                ResetColor();

                for (int j = 0; j < GameManager.CurrentGame.CurrentPlayer.Cards.Count; j++)
                {
                    Card currentCard = GameManager.CurrentGame.CurrentPlayer.Cards[j];
                    string hexColor;
                    if (j == SelectedCard) continue;
                    hexColor = "#FF50FF";
                    if (currentCard.CurrentColdown > 0)
                    {
                        Draw.DrawCard((currentCard.Name), currentCard.EnergyCostValue, currentCard.CurrentColdown, j, cardWidth, cardHeight, "A9A9A9");
                    }
                    else { Draw.DrawCard((currentCard.Name), currentCard.EnergyCostValue, currentCard.CurrentColdown, j, cardWidth, cardHeight, hexColor); }
                }
                Card selectedCard = GameManager.CurrentGame.CurrentPlayer.Cards[SelectedCard];
                Draw.DrawSelectedCard(selectedCard.Name, selectedCard.Description, SelectedCard>7? 6 : SelectedCard, cardSHeight, cardSWidth);

                ResetColor();
                Draw.DrawPlayerStats(GameManager.CurrentGame.Players);
                Draw.DrawPlayerImage(bottomBorderY);
                Draw.DrawBorders("#FF0000");
                Draw.DrawBordersExtra(midConsole, fifthConsole, bottomBorderY, maxHeight);
                Draw.DrawFloor(bottomBorderY);
            }
        }
        public void DisplayOptionsForIA()
        {
            CursorVisible = false;
            Console.Clear();
            string[] optionsIA = { "JUGAR", "SALIR" };
            for (int i = 0; i < optionsIA.Length; i++)
            {
                string currentOption = optionsIA[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    ForegroundColor = ConsoleColor.Red;
                    prefix = "*";
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    prefix = "";
                }
                SetCursorPosition(Console.BufferWidth - 20, Console.BufferHeight - 1 + i * 10);
                Console.WriteLine($"{prefix}  {currentOption}");

            }

            ResetColor();
            Draw.DrawPlayerStats(GameManager.CurrentGame.Players);
            Draw.DrawPlayerImage(bottomBorderY);
            Draw.DrawBorders("#FF0000");
            Draw.DrawBordersExtra(midConsole, fifthConsole, bottomBorderY, maxHeight);
            Draw.DrawFloor(bottomBorderY);
        }
        public int RunMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    SelectedIndex = SelectedIndex < 0 ? Options.Length - 1 : SelectedIndex;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    SelectedIndex = SelectedIndex >= Options.Length ? 0 : SelectedIndex;
                }
            }
            while (keyPressed != ConsoleKey.Enter && keyPressed != ConsoleKey.Escape);
            if(keyPressed == ConsoleKey.Escape) return 3;
            
            return SelectedIndex;
        }
        public int RunMenuIA()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptionsForIA();
                string[] optionsIA = { "JUGAR", "SALIR" };
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    SelectedIndex = SelectedIndex < 0 ? optionsIA.Length - 1 : SelectedIndex;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    SelectedIndex = SelectedIndex >= optionsIA.Length ? 0 : SelectedIndex;
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
        public int RunCards()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedCard--;
                    SelectedCard = SelectedCard < 0 ? GameManager.CurrentGame.CurrentPlayer.Cards.Count - 1 : SelectedCard;
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedCard++;
                    SelectedCard = SelectedCard >= GameManager.CurrentGame.CurrentPlayer.Cards.Count ? 0 : SelectedCard;
                }
                
            }
            while (keyPressed != ConsoleKey.Enter && keyPressed != ConsoleKey.Escape);
            if(keyPressed == ConsoleKey.Escape) return -1;
            Card toPlay = GameManager.CurrentGame.CurrentPlayer.Cards[SelectedCard];
            Draw.WriteAt("Has seleccionado la carta: " + toPlay.Name, borderLeft, 2, "#8900FF");
            Task.Delay(1000).Wait();
            return SelectedCard;
        }


        #region Variables
        private int SelectedIndex;
        private int SelectedCard;
        private string[] Options;

        List<Player> Players;

        int borderLeft;
        int borderRight;
        int borderWidth;
        int borderHeight;
        int maxWidth;
        int maxHeight;
        int bottomBorderY;
        int topBorderY;
        int midConsole;
        int fifthConsole;
        int cardSHeight;
        int cardSWidth;
        int cardHeight;
        int cardWidth;

        public BattleMenu(string[] options, List<Player> players, int borderLeft, int borderRight, int borderWidth, int borderHeight, int maxWidth, int maxHeight, int bottomBorderY, int topBorderY, int midConsole, int fifthConsole, int cardSHeight, int cardSWidth, int cardHeight, int cardWidth)
        {
            Options = options;
            Players = players;
            this.borderLeft = borderLeft;
            this.borderRight = borderRight;
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
            this.bottomBorderY = bottomBorderY;
            this.topBorderY = topBorderY;
            this.midConsole = midConsole;
            this.fifthConsole = fifthConsole;
            this.cardSHeight = cardSHeight;
            this.cardSWidth = cardSWidth;
            this.cardHeight = cardHeight;
            this.cardWidth = cardWidth;
        }
        #endregion
    
    }
}