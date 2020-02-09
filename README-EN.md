# Test Test Automation
## Programs Used In Our Project 
- ASP.NET MVC
- MySQL Workbech
## The Purpose Of Our Project

 <b> 1. There are two types of users in the automation system: Admin and other users. </b>
- Admin user can perform all operations on the system
- Other users, in the relevant period of the relevant department and assigned to the course
he has the right to evaluate the midterm, final and completion exams.
##
 <b> 2. Operations</b>
- Adding users, registration number of users (lecturers), name and surname,
it must have a password. (Update, delete and list can be done.)
- Faculty Add, Update,Delete operations.
- Adding partitions, any partition in the program can be defined. Adding episodes
program gains are added. For example, Information Systems Eng under the Faculty of Technology,
biomedical Eng, etc. (Update, delete and list can be done.)
- Adding term names to the system, 2019-2020 fall semester, 2019-2020 spring semester etc.
identification should be made by nomenclature method. (Update, delete and my list
must be made. Pay attention to the links, especially when deleting them.)
- Adding courses, adding courses to the program. In the process of adding a course, while the name of the course,
the code is added to the learning outcomes (learning outcomes) of the course.(Update, delete and my list
must be made.)
- The course assignment process is the process of assigning courses to the users, that is, the lecturers.
The department is made by selecting semester, course and User Registration number (teacher).
- Listing operations, all kinds of admin user listings (users listings, course
assignments, list of departments, list of courses opened in the relevant department, etc...) operations
you can perform. Exams or courses taught by Department, periodical
to list the types of visa, final and completion exams should be included and those who have been studied
link should be given.(Excel opens the file.)
- Test exam reading process, after the relevant user (instructor) has logged in to the system
then the Department, semester, course and type of exam (midterm,final,Bute))
he should choose. * The text file in his hand should be loaded into the system. (example [sınav.txt](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/sinavsonuclari.txt).)
Then the answer key * must be installed on the system.(example [cevap.txt](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/cevapanahtari.txt)
Students ' exam results should be listed with The evaluate button. These results should also be saved in the excel file.
- Question - based assessment process, which of each student from the test reading process
creates a list of how many Points you get from the question. Each class also
the average in the question is calculated. These generated values in excelin 2.the field is saved.
- Acquisition-based evaluation process, which is added in the course addition process
gains should be listed. It should also be listed in the questions. Every win
the questions that belong should be selected. Average score and gain according to selected questions
success scores must be calculated. Excelin 3.saves field, evaluation 4.saves space.
## To Use The Program
For the use of the program [here] (https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/help.pdf) browse.
## Use Of Code In The Program
<b> the Program works with C# Layered Architecture.< / b>
- [TestSinaviOtomasyon.Common](https://github.com/yemrecoskun/TestSinaviOtomasyonu/tree/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Common) layer with DataTransferObjects created. DTOName.in the cs section, I have defined the variables that may be included in the relevant field. ([örnek](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Common/DataTransferObjects/DTOBolum.cs))
- [TestSinaviOtomasyon.Entity](https://github.com/yemrecoskun/TestSinaviOtomasyonu/tree/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Entity the database is created with the same name as the database. The Common layer calls the layer to this layer, pulling the data from the corresponding area. yapar.([örnek](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Entity/EBolum.cs))
- [TestSinaviOtomasyon.Service](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Service/Service.cs this layer is used to create a new layer.
- [TestSinaviOtomasyon.Globals](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon.Globals/Globals.cs) this layer defines temporary global variables. This layer works independently of the other layer
- [TestSinaviOtomasyon](https://github.com/yemrecoskun/TestSinaviOtomasyonu/blob/master/TestSinaviOtomasyon/TestSinaviOtomasyon/Controllers/HomeController.cs) this layer is the main layer. Here we call the processes in the service by defining the Service code.
