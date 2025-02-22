# DoubleForSteamLeaderboards

This is just a simple script that stores doubles on a 32bit integer to be used with Steam leaderboards. 
A bit of precision is lost in the big numbers and it only supports integers between 0 and 3.4028e+038 (max value of double)

The way to use this is:
- The player's high score is a double -> convert that to an int with *ConvertIntToDouble*
- Store the int in the leaderboards with Steam API
- For the frontend part of your leaderboards, convert that int back to a neat string with *ConvertIntToStringScore* that will represent the double.
