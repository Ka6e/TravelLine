using System.ComponentModel;

namespace Fighters.ConsoleUI
{
    public enum MenuActions
    {
        [Description( "Add fighter" )]
        AddFighter = 1,

        [Description( "Show fighters" )]
        ShowFighters = 2,

        [Description( "Play" )]
        Play = 3,

        [Description( "Exit" )]
        Exit = 4
    }
}
