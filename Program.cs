﻿using System;

namespace MultiplayerZelda
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ZeldaGameWorld())
                game.Run();
        }        
    }
}
