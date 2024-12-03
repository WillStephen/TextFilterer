<h1 align="center">Text filterer</h1>
<hr/>

This program filters text from a given file and displays the result.

## How to run
This is a command-line program that takes one argument: `inputFile`, which should be a path to a file containing some text. There are some text files included in the `Assets` folder.

For example, in a terminal in the same directory as your executable, you can run:
```
.\TextFilterer --inputFile Assets\AliceInWonderland.txt
```

## Future improvements
There are plenty of things that could be added to this project to improve it. In no particular order:

### Logging
The program does log results to the console, but we could do a lot more here - for exampl, we could log:

- progress updates during the filtering - useful for large files
- the number of words filtered out and the number remaining after filtering
- the time taken to run the program

Rather than using `Console.WriteLine` to do this, we could use an injected `ILogger<T>` so that log-ingestion systems like Application Insights can know from where in the code messages originated.
 
### Multithreading
To speed up the process, we could split the filtering using the [Task Parallel Library](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl). Start by splitting the work up into `Task`s which each filter and print a single line of the input file. The catch is that you have to make them print their respective filtered lines in order, otherwise you'd get a jumbled result.

### Higher-level tests
The solution includes unit tests, but adding some integration tests would be a good next step (by 'integration test' I mean a test that checks how all the classes operate together, possibly using e.g. [System.IO.Abstractions](https://github.com/TestableIO/System.IO.Abstractions) to mock the file system). The test could create a file, run the program without any mocking, and check that the printed output is equal to a known expected value.

### More command-line args, or configuration
Right now, the program preserves the punctuation of the input file. So, for the included file `RainInSpain.txt`, the contents `The rain in Spain stays mainly in the plain.` become simply `.` when filtered.

We could change this behaviour to be configurable - perhaps the user wants punctuation marks to be filtered out if the preceding word is also filtered.

The user could pass in a command-line argument, similar to `inputFile`, to configure this behaviour. Alternatively, we could create an `appSettings.json` file and load the JSON configuration within from `Program.cs`, and use that file to enable or disable extra features like this.

### Separate presentation, business logic, and infrastructure layers
To better separate concerns, we could split the project into three smaller projects:

- a **presentation** project containing `Program.cs`, does the setup of the dependency injection container, and performs the top-level execution of the program
- a **business logic** layer which contains the logic to actually filter the words
- an **infrastructure** layer, to handle interfacing with any external systems - reading the input file, saving results to another file or database, etc.

### More result outputters
Currently there's only one implementation of `IResultOutputter`, used to output the result of the filtering: `ConsoleResultOutputter`.

We could add outputters for other systems - for example, an outputter that saves the results to a database, or HTTP POSTs the results to a URL, etc.