# Common Scripts Container
### Description
This is a container for scripts so you can schedule them, run once, or run based on a macro key.

![Image of the Main window](./img/MainForm.png)

![Image of the Add window](./img/AddOneOffScript.png)

### How to use it
1 - Download the release v1.1 and extract it.

2 - Place it in the desired installation path.

3 - Open the App.config file, and change the value of the key '_installationPath_' with the location where it is installed.

4 - Save it and run the app.

### Third-party libraries
- [MetroSet-UI](https://github.com/N-a-r-w-i-n/MetroSet-UI) by [NARWIN](https://github.com/N-a-r-w-i-n/) as a skin for Winforms (sorry for using winforms 😞).
- [globalmousekeyhook](https://github.com/gmamaladze/globalmousekeyhook) by [George Mamaladze](https://github.com/gmamaladze) for the key listener.
- [Quartz.NET](https://github.com/quartznet/quartznet) to manage script execution.
- [Serilog](https://github.com/serilog/serilog) for the logging.
- [AudioDeviceCmdlets](https://github.com/frgnca/AudioDeviceCmdlets) by [frgnca](https://github.com/frgnca) for the Toggle Audio Device script.
