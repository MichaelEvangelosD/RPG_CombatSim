using System;
using RPG.Utils;

namespace RPG.UserInterface
{
    class UI
    {
        public static string UI_GetPlayerHealth(int value, out int intValue)
        {
            intValue = Utilities.GetPercentage(value);
            string tempStr = "";

            for (int i = 0; i < intValue; i++)
            {
                tempStr += "-";
            }

            return tempStr;
        }
    }
}
