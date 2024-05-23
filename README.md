# Wuthering Waves FPS Unlocker

Welcome to the Wuthering Waves FPS Unlocker! This program is designed to find and modify the `LocalStorage.db` file for the game **Wuthering Waves**, allowing you to unlock the frame rate for a smoother gaming experience.


## Features

- **Database Connection**: Connects to a specified SQLite database file.
- **JSON Reading**: Reads JSON data from a specific record in the database.
- **JSON Modification**: Updates a specific key-value pair within the JSON.
- **Database Update**: Saves the modified JSON back into the database.
- **User Prompt**: Waits for user input before closing the console to ensure you can review the output.

## How It Works

### Initialization

The program starts by defining the path to the SQLite database file and setting up the connection string.

### Database Connection

It opens a connection to the SQLite database using `SQLiteConnection`.

### JSON Reading

1. **Query Execution**: Executes a `SELECT` query to fetch the JSON value associated with the `GameQualitySetting` key from the `LocalStorage` table.
2. **Data Retrieval**: Reads the JSON data from the result set.

### JSON Modification

1. **Parsing JSON**: Uses `Newtonsoft.Json` to parse the JSON string into a `JObject`.
2. **Updating Value**: Modifies the `KeyCustomFrameRate` value from `60` to `120` within the JSON object.
3. **Serializing JSON**: Converts the modified `JObject` back into a JSON string.

### Database Update

1. **Update Query**: Executes an `UPDATE` query to save the modified JSON back into the `LocalStorage` table.
2. **Confirmation**: Outputs the number of rows affected by the update to confirm the change.


## Usage

To use the Wuthering Waves FPS Unlocker:

1. **Download and Compile**: Clone the repository and compile the source code using a C# compiler or an IDE like Visual Studio.
2. **Run the Program**: Execute the compiled program. The console will display the progress and status messages.
3. **Review Output**: The program will print the original and updated JSON, the number of rows updated, and will wait for you to press a key before closing.

## Contributing

Contributions are welcome! Feel free to submit a pull request or open an issue to discuss any changes or improvements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Acknowledgements

Special thanks to the Wuthering Waves community for their support and feedback.

---

Enjoy your unlocked FPS in Wuthering Waves!

