# Download PS4 Game Update

It is possible to check the PS4 game update pkg directly from the PlayStation servers,  
Providing the **"Title ID"** and **"PS4 HMAC-SHA256 Patch Pkg URL Key"**

Download: [Download PS4 Game Update](https://github.com/DanielSvoboda/download_ps4_game_update/releases)  
- [Windows with interface](https://github.com/DanielSvoboda/download_ps4_game_update/releases/download/V2/download.ps4.game.update.exe)
- [Windows Console](https://github.com/DanielSvoboda/download_ps4_game_update/releases/download/V2/download_ps4_game_update_console.rar) 
- [Linux Console](https://github.com/DanielSvoboda/download_ps4_game_update/releases/download/V2/linux-x64.rar)

![Screenshot 1](https://raw.githubusercontent.com/DanielSvoboda/download_ps4_game_update/main/Print1.png)
![Screenshot 2](https://raw.githubusercontent.com/DanielSvoboda/download_ps4_game_update/main/Print2.png)

# Usage

## Windows

Enter the **"Title ID"** and **"HMAC-SHA256 Patch Pkg URL Key"** into their respective fields.  
Click **"Check Updates"** to retrieve information about the game update.

<br><br>
## Windows Console

1. Open Command Prompt and navigate to the directory where `download_ps4_game_update_console.exe` is located:
```bash
cd path/to/download_ps4_game_update_console
```

2. Run the program with the required arguments:
```bash
download_ps4_game_update_console.exe -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <Title_ID>
```
<br><br>
## Linux Console 

1. Download the `linux-x64.rar` file and extract it to a directory on your Linux machine.
2. Open a terminal and navigate to the directory where `download_ps4_game_update_console` is located:
```bash
cd path/to/linux-x64/download_ps4_game_update
```

3. Make the executable file `download_ps4_game_update_console` executable, if necessary:
```bash
chmod +x download_ps4_game_update_console
```
4. Execute the program with the following command, providing the necessary arguments:
```bash
./download_ps4_game_update_console -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <Title_ID>
```
<br><br><br>
Replace `<HMAC_SHA256_Patch_Pkg_URL_Key>` and `<Title_ID>` with actual values.

Make sure to replace `path/to/download_ps4_game_update_console` and `path/to/linux-x64/download_ps4_game_update` with the actual paths where `download_ps4_game_update_console` executable is located on your Windows and Linux systems respectively.
