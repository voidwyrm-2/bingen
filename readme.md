# Bingen
Generates a binary file from a very simple custom file format

**Usage**
First, make a file with the `.plbin`(**Pl**ain text **Bin**ary) extension<br>
Then in it, put the bytes you want to write in the follow format
```
10, 20, 30, 40, 50, 60, 70, 80, ...
```
Newlines can be used to split bytes up into more understandable chunks(don't end lines with commas, though)<br>
Comments are made with `/.` and `./`

Then once you have made your file, run this command(on MacOS/Linux)
```
bingen "[path]"
(or if the executable is in the directory you're in:)
./bingen "[path]"
```

<br>

This is made for MacOS/Linux<br>
I'll probably add a Windows option later
