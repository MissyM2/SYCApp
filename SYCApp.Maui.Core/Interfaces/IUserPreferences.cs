using System;
namespace SYCApp.Maui.Interfaces
{
    public interface IUserPreferences
    {
        bool ContainsKey(string key);
        void Set(string key, bool value);
        void Set(string key, string value);
        bool Get(string key, bool defaultValue);
        string Get(string key, string defaultValue);
    }

}
