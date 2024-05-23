# Wuthering Waves FPS Unlocker

Welcome to the Wuthering Waves FPS Unlocker! This program is designed to find and modify the `GameUserSettings.ini` file for the game **Wuthering Waves**, allowing you to unlock the frame rate for a smoother gaming experience.

## Features

- **Automatic File Search**: The program searches for the `GameUserSettings.ini` file across all available drives.
- **Keyword Matching**: It specifically looks for directories containing the keyword "Wuthering Waves" to ensure it modifies the correct game settings file.
- **Frame Rate Unlocking**: Once the file is found, it modifies the `FrameRateLimit` setting to `0`, effectively unlocking the frame rate.
- **Read-Only Protection**: After modifying the file, it sets the file to read-only to prevent any accidental changes.

## How It Works

1. **Initialization**: The program starts by defining the target file (`GameUserSettings.ini`) and the keyword for identifying the correct directory (`Wuthering Waves`).

2. **Drive Search**: It iterates through all available drives on your system. For each drive:
    - It checks if the drive is ready (i.e., accessible).
    - It calls the `FindFile` method to search for the target file.

3. **Directory Search**: Within the `FindFile` method:
    - The program recursively searches through all subdirectories.
    - If a directory contains the required keyword (`Wuthering Waves`), it further checks for the target file within that directory.

4. **File Modification**: Once the file is found:
    - It reads the file line by line.
    - It locates the `FrameRateLimit` setting and updates its value to `0`.
    - It writes the updated content back to the file and sets the file to read-only.

5. **Completion**: The program notifies you whether the file was found and modified successfully. If the file is not found, it informs you accordingly.

## Usage

To use the Wuthering Waves FPS Unlocker:

1. **Download and Compile**: Clone the repository and compile the source code using a C# compiler or an IDE like Visual Studio.
2. **Run the Program**: Execute the compiled program. The console will display the progress and status messages.
3. **Check the Results**: If the program successfully finds and modifies the `GameUserSettings.ini` file, it will notify you and set the file to read-only.


## Contributing

Contributions are welcome! Feel free to submit a pull request or open an issue to discuss any changes or improvements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Acknowledgements

Special thanks to the Wuthering Waves community for their support and feedback.

---

Enjoy your unlocked FPS in Wuthering Waves!

