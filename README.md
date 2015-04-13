# Orc.CrashReporting

simple way to hatch unhandled exceptions, prepare support package and inform the support team about the crash

## Features

* no need to handle catch unhandled exceptions. **Orc.CrashReporting** will do it by itself.
* able to provide additional information, which may help to findout the way hoe to solve the problem
* crash report providers can be added as prigins for the **Orc.CrashReporting** 
* implemented email crash provider

## How to add crash report provider

Implement the **ICrashReportProvider** in your project

	public interface ICrashReportProvider
    {
        #region Properties
        string Title { get; }
        #endregion

        #region Methods
        void SendCrashReport(CrashReport crashReport, string fileToAttach);
        #endregion
    }

If you're implementing this interface in separate assembly, then just add reference to it into your main project. 

that's all what you need to make it works.


## Screenshot

that's how the error message loks like:

![Orc.CrashReporting 01](doc/images/Orc.CrashReporting_01.png)

You can see the details and user can provide the description of what he did before error occured.

![Orc.CrashReporting 02](doc/images/Orc.CrashReporting_02.png)

exception detail:

![Orc.CrashReporting 03](doc/images/Orc.CrashReporting_03.png)

User can choose any available crash report provider from drop down menu to send crash report  (or just use the default one by ckicking the button):

![Orc.CrashReporting 04](doc/images/Orc.CrashReporting_04.png)