# Wuthering Waves Editor

Welcome to the Wuthering Waves Editor! This program is designed to read and modify the `LocalStorage.db` file for the game Wuthering Waves, allowing you to customize various settings for a better gaming experience.

## Features

- **Read and Display JSON Data**: The program reads JSON data from the `LocalStorage.db` file and displays it in a user-friendly interface.
- **Edit JSON Values**: Modify any value within the JSON data directly through the interface.
- **Save Changes**: Save the modified JSON data back to the `LocalStorage.db` file.

## How It Works

### Initialization

The program starts by displaying a message box with instructions on how to use it. Then, it provides an interface for you to specify the path to the `LocalStorage.db` file.

### Load JSON Data

1. **Database Connection**: Connects to the SQLite database at the specified path.
2. **Retrieve Data**: Executes a SQL query to retrieve the `GameQualitySetting` JSON data from the `LocalStorage` table.
3. **Display Data**: Parses the JSON data and displays it in a tree view for easy navigation and editing.

### Edit JSON Data

1. **Select Node**: Select a node in the tree view to view and edit its value.
2. **Modify Value**: Enter a new value in the provided text box and save the change.

### Save Changes

1. **Update Database**: Updates the modified JSON data back into the SQLite database.
2. **Confirmation**: Displays a message indicating the number of rows updated.

## Usage

### Prerequisites

- Ensure the game is not running before making any modifications.
- Verify the `LocalStorage.db` path matches your game installation directory (default path is provided).

### Steps

1. **Close the Game**: Ensure Wuthering Waves is not running.
2. **Specify Path**: Make sure the `LocalStorage.db` path matches your game installation. The default installation path is `C:\\Wuthering Waves\\Wuthering Waves Game\\Client\\Saved\\LocalStorage\\LocalStorage.db`.
3. **Avoid Conflicts**: Ensure the `LocalStorage.db` file is not in use by any other process.
4. **Modify Values**: Use the editor to modify the desired JSON values.
5. **Save Changes**: Save the modifications and restart the game.
6. **Support**: If you appreciated this tool, please star the project on GitHub and leave suggestions in the issues section.

## Contributing

Contributions are welcome! Feel free to submit a pull request or open an issue to discuss any changes or improvements.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgements

Special thanks to the Wuthering Waves community for their support and feedback.

Enjoy customizing your Wuthering Waves experience with the Wuthering Waves Editor!
