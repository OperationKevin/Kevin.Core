Kevin.Core
==========

this is the core for Operation Kevin which is the goal to create a cross platform PA like Siri or Google Now.

it currently has 3 interfaces:
* Console https://github.com/OperationKevin/Kevin.Console
* Desktop through GTK https://github.com/OperationKevin/Kevin.Desktop
* Android https://github.com/OperationKevin/Kevin.Android

##plugin Creation
plugins must inherent Plugin
```cs
	public class yourPlugin : Plugin
```
then you must create get Result that will return a result if applicable
```cs
public override Result getResult(string message) {
  if(message == "Who's there?") {
    return new Result(whatToRun);
  }
  return null; //if you dont have any results return null
}

public void whatToRun(string message, Output output) {
	output.send("Me, Kevin"); // Your output
}
```
this will make Kevin say "Me, Kevin" when you say "Who's there?".

for  better results you should use regular expressions e.g.
```cs
Regex.IsMatch (message, @"(?i)who((')?s)?( is)? there\b")
```
which will work if you say "who is there" as well as "whos there" and "who's there"

###more complex plugins
a more complex plugin like knockknock plugin
```cs
public override Result getResult(string mess, KevinCore core) {
	if (Regex.IsMatch (mess, @"(?i)joke\b")) { //if message has "joke"
		return new Result ((string message, Output output) => { //return result
			output.send("ok"); //that when executed will reply "ok"
			output.send("Knock Knock"); //followed by "Knock Knock"
			core.State = "joke:knockknock"; //it will also set kevins state
                                      //so it knows it told "Knock Knock"
		});
	}

	if (Regex.IsMatch (mess, @"(?i)who((')?s)?( is)? there\b") && core.State == "joke:knockknock") {
    //if user says who's there and the state is "joke:knockknock" (kevin said knock knock).
		return new Result ((string message, Output output) => { //return result
			output.send("Orange"); //say orange
			core.State = "joke:orange";
		}, 2); //this last option value set the priority to 2 that means if this result will
           //get priority over results e.g. from the who's there plugin

  return null; //we have no result
  }
```

this will allow for convosation like so
```
You: Who's there
Kevin: Me, Kevin
you: tell me a joke
Kevin: Knock Knock
you: Who's there
Kevin: Orange  \\this time it returns orange due to the higher priority
```
