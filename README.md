# PS4 pkg update

It is possible to check the PS4 game update pkg directly from the PlayStation servers,  
Providing the **"Title ID"** and **"PS4 HMAC-SHA256 Patch Pkg URL Key"**

Download: [PS4 pkg update](https://github.com/DanielSvoboda/ps4_pkg_update/releases)  
- [Windows with interface](https://github.com/DanielSvoboda/ps4_pkg_update/releases/download/V2.1/ps4_pkg_update.exe)
- [Windows Console](https://github.com/DanielSvoboda/ps4_pkg_update/releases/download/V2.1/ps4_pkg_update_console-Windows.rar) 
- [Linux Console](https://github.com/DanielSvoboda/ps4_pkg_update/releases/download/V2.1/ps4_pkg_update_console-Linux-x64.rar)
- [Python](https://github.com/DanielSvoboda/ps4_pkg_update/releases/download/V2.1/ps4_pkg_update.py)

![Screenshot 1](https://raw.githubusercontent.com/DanielSvoboda/ps4_pkg_update/main/Print1.png)
![Screenshot 2](https://raw.githubusercontent.com/DanielSvoboda/ps4_pkg_update/main/Print2.png)

# Usage

## Windows

Enter the **"Title ID"** and **"HMAC-SHA256 Patch Pkg URL Key"** into their respective fields.  
Click **"Check Updates"** to retrieve information about the game update.

<br><br>
## Windows Console

1. Open Command Prompt and navigate to the directory where `ps4_pkg_update_console.exe` is located:
```bash
cd path/to/ps4_pkg_update_console
```

2. Run the program with the required arguments:
```bash
ps4_pkg_update_console.exe -key <HMAC-SHA256 Patch Pkg URL Key> -title <Title_ID>
```
<br><br>
## Python

1. Open a terminal and navigate to the directory where `ps4_pkg_update_update.py` is located:
```bash
cd path/to/ps4_pkg_update
```
4. Execute the program with the following command, providing the necessary arguments:
```bash
python ps4_pkg_update.py -key <HMAC-SHA256 Patch Pkg URL Key> -title <Title_ID>
```

<br><br>
## Linux Console 

1. Download the `linux-x64.rar` file and extract it to a directory on your Linux machine.
2. Open a terminal and navigate to the directory where `ps4_pkg_update_console` is located:
```bash
cd path/to/linux-x64/ps4_pkg_update
```

3. Make the executable file `ps4_pkg_update_console` executable, if necessary:
```bash
chmod +x ps4_pkg_update_console
```
4. Execute the program with the following command, providing the necessary arguments:
```bash
./ps4_pkg_update_console -key <HMAC-SHA256 Patch Pkg URL Key> -title <Title_ID>
```
<br><br><br>
Replace `<HMAC-SHA256 Patch Pkg URL Key>` and `<Title_ID>` with actual values.

Make sure to replace `path/to/ps4_pkg_update_console` and `path/to/linux-x64/ps4_pkg_update` with the actual paths where `ps4_pkg_update_console` executable is located on your Windows and Linux systems respectively.
