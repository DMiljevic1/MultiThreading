Task:

parse these people into appropriate objects -> Project CreatingTxtFile will create txt file with 100 milion lines, each represent object
Display in console rows:
-error rows with red color
-students with grade below 1 with yellow color
-students with green color
-professors with blue color
Write rows into files:
-write all invalid rows into error-rows.txt file
-write all students with grade 1 or below into failed-students.txt file
-write all students with grade above 1 into passed-students.txt file
-write all professor into professors.txt file
write code that is memory and performance optimized.
Notes:
-This code will generate file which is about 5GB's in size.
-Do not attempt to load whole file into memory at once
-Changing colors with Console.ForegroundColor = ConsoleColor.Yellow

For memory optimization I used Producer-Consumer patern and async await. In first thread Producer will read each line of file, parse it into object and put it into SharedBuffer. At the same time using second thread Consumer will take parsed objects from SharedBuffer,
parse them back to text, display them in corresponding color and put them in the corresponding text file.
