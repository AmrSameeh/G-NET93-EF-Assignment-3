using OnlineLearningPlatform.Operations;

Console.WriteLine("==================================");
Console.WriteLine("   ONLINE LEARNING PLATFORM");
Console.WriteLine("==================================");


Console.WriteLine("\n========== CREATE ==========");

CreateOperations.AddInstructor();

CreateOperations.AddCourse();

CreateOperations.AddSeveralStudents();

CreateOperations.EnrollStudent();



Console.WriteLine("\n========== READ ==========");

ReadOperations.FindCourse();

ReadOperations.FilterCourses();

ReadOperations.PrintCategories();

ReadOperations.PrintCourseRoster();




Console.WriteLine("\n========== UPDATE ==========");

UpdateOperations.ChangeCoursePrice();

UpdateOperations.UpdateEnrollmentProgress();

UpdateOperations.PublishCourse();



Console.WriteLine("\n========== DELETE ==========");

DeleteOperations.UnenrollStudent();

DeleteOperations.TryDeleteParentCategory();

DeleteOperations.SafeDeleteCategory();

DeleteOperations.DeleteCourseWithEnrollments();


Console.WriteLine("\n==================================");
Console.WriteLine("       APPLICATION FINISHED");
Console.WriteLine("==================================");

Console.ReadKey();