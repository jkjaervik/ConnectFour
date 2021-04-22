using System.Linq;
using ConnectFour.Shared.UI;
using ConnectFour.Shared.Utils;

var textInterface = new GameTextInterface();

//if (args != null && args.Any())
//textInterface.ShowGameBoard(GameSimulator.BuildBoard(args[0]));
//else
//textInterface.ShowGameBoard(GameSimulator.BuildBoard("2334356322454024430302240006556"));
textInterface.StartGameLoop();