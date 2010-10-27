Newsletter Signup Demo
Copyright 2010 Nathan Brown
===
This web application that allows a user to sign up for a newsletter, and then optionally unsubscribe.

It was used as a greenfield platform, giving me the opportunity to develop a solution without regard to legacy databases and code.  So, in part, I used it as a learning device, not so much as (rapid application development) RAD.

Building source
===
To build, run build.cmd.

Running
==
It requires a Raven DB instance for data storage.  Run the included exe: .\RavinServer\Raven.Server.exe.  This will launch a service at port 8080.

SQL Express is required to be installed to support the reporting of user activity.


The web application can be launched through Visual Studio's embedded web server (Ctl-F5) or if IIS Express is installed, use the included "LaunchIISExpress.cmd".

The user name is "Admin" and the password is "admin".  Asp Membership authentication is already implemented, to use it, the main SiteModule IoC config class needs adjusted and users would have to be added to the Asp user list.

