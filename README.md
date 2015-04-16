Orc.CrashReporting
======================

This library is used to:
- catch unhandled exceptions
- prepare a support package (optional)
- send the crash report to the support team (optional)

Features
----------

- **Orc.CrashReporting** will catch all unhandled exceptions automatically
- Crash report providers can be added as plugins
- Reports can be sent by email to a designated email address
- Extra messaging providers can also be implemented

Crash reports will contain:
- The exception message
- The users system information (see [Orc.SystemInfo](https://github.com/WildGums/Orc.SystemInfo) for more details)
- All the DLLs that were loaded when the exception occured (as well as their version number)
- Optional message for the user, if they want to add more information before sending the report.

How to add a crash report provider
---------------------------------

All you need to do is implement the **ICrashReportProvider** interface in your project.

```c#
public interface ICrashReportProvider
{
    string Title { get; }
    void SendCrashReport(CrashReport crashReport, string fileToAttach);
}
```

Screenshot
---------------

The error message will look like this:

![Orc.CrashReporting 01](doc/images/Orc.CrashReporting_01.png)

Clicking on the "Show details" button will display more information, and give the user the chance to add extra information before sending the report.

![Orc.CrashReporting 02](doc/images/Orc.CrashReporting_02.png)

The exception details:

![Orc.CrashReporting 03](doc/images/Orc.CrashReporting_03.png)

Multiple messaging providers can be implemented and will be shown in the drop down menu. 

![Orc.CrashReporting 04](doc/images/Orc.CrashReporting_04.png)
