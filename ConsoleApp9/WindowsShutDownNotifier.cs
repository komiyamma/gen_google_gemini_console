﻿using Microsoft.Win32;
using System;
using System.Threading.Tasks;


partial class HmGoogleGemini
{
    static void WindowsShutDownNotifier()
    {
        SystemEvents.SessionEnding += SystemEvents_SessionEnding;
    }

    private static async void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
    {
        if (e.Reason == SessionEndReasons.SystemShutdown)
        {
            chatSession.Cancel();
            await Task.Delay(100); // ミリ秒単位で待つ時間を指定
            Console.WriteLine("Windowsがシャットダウンしています。ここで必要な操作を行ってください。");
        }
    }

}
