Newsletter Signup Demo
Copyright 2010 Nathan Brown <nathan@nkbrown.us>
===
This web application that allows a user to sign up for a newsletter, and then optionally unsubscribe.

It was used as a greenfield platform, giving me the opportunity to develop a solution without regard to legacy databases and code.  So, in part, I used it as a learning device (thus Raven DB)

Building source
===
To build, run build.cmd or load solution into Visual Studio 2010 and build from there.

Running
==
It requires a Raven DB instance for data storage.  Run the included "Launch RavenDB.cmd".  This will launch a service at port 8080 and open the database manager.

SQL Express is required to be installed to support the reporting of user activity.

The web application can be launched through Visual Studio's embedded web server (Ctl-F5).

Or if IIS Express is installed, use the included "LaunchIISExpress.cmd", then the application will launch at http://localhost:8081/.  To view the current subscriptions to the newsletter, go to http://localhost:8081/Subscription.

Future expandability
===
User activity is logged to the SQL Server database file, Reporting.mdf.  This can be viewed through Visual Studio.

The foundation of the application may be more complicated than the typical toy app, but it shouldn't have to change much as the web site application grows.  Dependancy injection, data-store swappability, testability, and logging/reporting are already built in.