// To ensure console output writes proper Ø's and not O's.
Console.OutputEncoding = System.Text.Encoding.UTF8;

#region Sprint 1
//Incident incidentA = new Incident("Visual Studio 2022", 2, "Fejl40 - brugeren er meget nervøs");
//Incident incidentB = new Incident("Word", 5, "Problemer med at lave indholdsfortegnelse");

////Console.WriteLine("Sprint 1:");
////Console.WriteLine(incidentA);
////Console.WriteLine();
////Console.WriteLine(incidentB);

//IncidentRepository incidents = new IncidentRepository("Zealand Support Center", 28);
//incidents.AddIncident(incidentA);
//incidents.AddIncident(incidentB);

//Console.WriteLine();
//Console.WriteLine(incidents.ToString());
#endregion

#region Sprint 2
//Comment commentA = new Comment("Bruger synes stadig der er for lidt tid", 15);
//Comment commentB = new Comment("Har hjulpet bruger med at få lavet indholdsfortegnelse", 5);

////Console.WriteLine("Sprint 2:");
////Console.WriteLine(commentA);
////Console.WriteLine();
////Console.WriteLine(commentB);

//incidentA.AddComment(commentA);
//incidentB.AddComment(commentB);

////Console.WriteLine(incidentA);
////Console.WriteLine();
////Console.WriteLine(incidentB);

//Comment commentC = new Comment("Damn tiden går", 42);

//incidents.AddCommentToIncident(1, commentC);

//Console.WriteLine(incidents);
#endregion

#region Sprint 3
//double? totalTimeSpent = incidentA.TotalTimeSpent;
//Console.WriteLine("Sprint 3:");
//Console.WriteLine($"Total time spent: {totalTimeSpent} min");
//Console.WriteLine();
//Console.WriteLine(incidents);
#endregion

#region Sprint 4
IncidentRepository incidents = new IncidentRepository("Zealand Support Center", 28);
Supporter supporterA = new Supporter("Lars", "69-420", "C#");
Customer customerA = new Customer("Karen", "313-131", "Enkefrue");
Comment commentA = new Comment("Bruger synes stadig der er for lidt tid", 15, supporterA);
Comment commentC = new Comment("Damn tiden går", 42, supporterA);
Comment commentB = new Comment("Har hjulpet bruger med at få lavet indholdsfortegnelse", 5, supporterA);
Incident incidentA = new Incident("Visual Studio 2022", 2, "Fejl40 - brugeren er meget nervøs", customerA);
Incident incidentB = new Incident("Word", 5, "Problemer med at lave indholdsfortegnelse", customerA);

incidentA.AddComment(commentA);
incidentB.AddComment(commentB);
incidents.AddIncident(incidentA);
incidents.AddIncident(incidentB);
incidents.AddCommentToIncident(1, commentC);

//Console.WriteLine("Sprint 4:");
//Console.WriteLine(incidents);
#endregion

#region Sprint 5
Console.WriteLine("Sprint 4:");
Console.WriteLine($"Open incidents: {incidents.OpenIncidents()}");

incidentB.Close();
Console.WriteLine($"Open incidents: {incidents.OpenIncidents()}");

#endregion