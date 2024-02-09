﻿namespace BlazorAppModeloKlinMilk.Shared
{
    public static class AuthorizationService
    {
        public static bool IsAuthorized { get; private set; }
        public static void SetAuthorization(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}