﻿namespace V2ex.Blazor.Services;
public class AppConstants
{
    public static bool IsDebug
    {
        get
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }

    public const string BlazorHybridHost = "0.0.0.0";

    public const string GithubRepository = "https://github.com/rwecho/V2ex.Maui.git";
}
