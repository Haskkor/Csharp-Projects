﻿using System;

namespace Pong__Open_Classroom_
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Pong game = new Pong())
            {
                game.Run();
            }
        }
    }
#endif
}
