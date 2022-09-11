// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ExecuteHierarhyOfTasks();
Thread.Sleep(10000);
Console.ReadLine();


Task ExecuteHierarhyOfTasks()
{
    var taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.AttachedToParent);
    var e = taskFactory.StartNew(() => DisplayAndWait('E'));
    var f = taskFactory.StartNew(() => DisplayAndWait('F'));
    var g = taskFactory.StartNew(() => DisplayAndWait('G'));
    var h = taskFactory.StartNew(() => DisplayAndWait('H'));

    var b = taskFactory.StartNew(() => DisplayAndWait('B'));
    var c = taskFactory.ContinueWhenAll(new Task[] { f, g }, _ => DisplayAndWait('C'));
    var d = taskFactory.StartNew(() => DisplayAndWait('D'));

    var a = taskFactory.ContinueWhenAll(new Task[] { b, c, d }, _ => DisplayAndWait('A'));

    return a;
}

void DisplayAndWait(char character)
{
    Thread.Sleep(1000);
    Console.WriteLine(character);
}